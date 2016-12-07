using System;
using System.IO;
using System.Windows.Forms;
using CSCore.CoreAudioAPI;
using CSCore.Streams;

using SoundRecorder.Visualizations;


namespace SoundRecorder
{
    public partial class MainWindow : Form
    {
        private CaptureDevice _captureDevice;
        private Recorder _recorder;
        private string _writeDir;

        // Visualizations
        private AudioMeter _audioMeter;
        private Visualization _levelsVisualization = new Levels();
        private Visualization _mainVisualization = new SimpleWaveform();

        // Button tracking
        private RecordingState _buttonState = RecordingState.Stopped;

        // Button animation states
        private bool _pausedBlink;


        public MainWindow()
        {
            InitializeComponent();

            // Restore the dimensions of the window from the last session.
            RestoreWindow();

            // Load in the user settings.
            LoadSettings();

            // Set the initial button state
            SetButtonState(_buttonState);

            // Show the recent files in the output directory
            this.previousRecordings.DisplayRecentFiles();
        }

        /// <summary>
        /// Load any general settings from the programs settings file
        /// e.g. the write directory
        /// </summary>
        public void LoadSettings()
        {
            // Write Directory
            this._writeDir = Properties.Settings.Default.writeDir;
            this.previousRecordings.writeDir = this._writeDir;
            CheckWriteDirectory();

            // Capture Device
            var inputDeviceGUID = Properties.Settings.Default.inputDevice;
            try
            {
                _captureDevice = new CaptureDevice(inputDeviceGUID);
                _audioMeter = AudioMeter.FromDevice(_captureDevice.Device);
                _recorder?.Dispose(); // Get rid of the old recorder.
                _recorder = new Recorder(_captureDevice.Device, _captureDevice.CaptureMode);
                _recorder.NotificationStream.SingleBlockRead += UpdateMainVisualization;
            }
            catch (Exception) {}
        }

        private void RestoreWindow()
        {
            // Restore window settings
            var width = Properties.Settings.Default.mainWindow_width;
            var height = Properties.Settings.Default.mainWindow_height;

            if (width > 0 && height > 0)
            {
                this.Width = width;
                this.Height = height;
            }

            this.WindowState = (FormWindowState) Properties.Settings.Default.mainWindow_state;
        }

        private void UpdateMainVisualization(object sender, SingleBlockReadEventArgs e)
        {
            this._mainVisualization?.AddSamples(e.Left, e.Right);
        }

        private void CheckWriteDirectory()
        {
            // Set the write directory
            if (this._writeDir == "")
            {
                this._writeDir = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "Recordings");
                Properties.Settings.Default.writeDir = this._writeDir;
                Properties.Settings.Default.Save();
            }

            if (!Directory.Exists(this._writeDir))
            {
                try
                {
                    Directory.CreateDirectory(this._writeDir);
                }
                catch (Exception e)
                {
                    MessageBox.Show("An error occured while creating the save folder: " + e, "Save Directory Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        public void SaveSettings()
        {
            Properties.Settings.Default.mainWindow_width = this.Width;
            Properties.Settings.Default.mainWindow_height = this.Height;
            Properties.Settings.Default.mainWindow_state = (int) this.WindowState;

            Properties.Settings.Default.Save();
        }

        public void MainWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Make sure the capture has stopped when the window is closed
            this._recorder?.StopCapture();
            this._recorder?.Dispose();
            SaveSettings();
        }

        private void SetButtonState(RecordingState state)
        {
            switch ( (int) state )
            {
                case (int) RecordingState.Stopped:
                    {
                        this._buttonState = RecordingState.Stopped;
                        this.buttonAnimationTimer.Enabled = false;
                        this.AnimatePauseButton(); // Ensure the paused button is returned to its normal color

                        this.recordButton.Enabled = true;
                        this.stopButton.Enabled = false;
                        this.pauseButton.Enabled = false;
                        break;
                    }
                case (int) RecordingState.Paused:
                    {
                        this._buttonState = RecordingState.Paused;
                        this.buttonAnimationTimer.Enabled = true;

                        this.recordButton.Enabled = true;
                        this.stopButton.Enabled = true;
                        this.pauseButton.Enabled = false;
                        break;
                    }
                case (int) RecordingState.Recording:
                    {
                        this._buttonState = RecordingState.Recording;
                        this.buttonAnimationTimer.Enabled = false;
                        this.AnimatePauseButton(); // Ensure the paused button is returned to its normal color

                        this.recordButton.Enabled = false;
                        this.stopButton.Enabled = true;
                        this.pauseButton.Enabled = true;
                        break;
                    }
            }
        }

        private void AnimatePauseButton()
        {
            // Pause Button Animation
            if (this._buttonState == RecordingState.Paused)
            {
                if (!this._pausedBlink)
                {
                    this.pauseButton.Image = Properties.Resources.pause_button_24;
                    this._pausedBlink = true;
                }
                else
                {
                    this.pauseButton.Image = Properties.Resources.pause_button_faded_24;
                    this._pausedBlink = false;
                }
            }
            // Turn off the blink if the paused button isn't active
            else if (!this._pausedBlink)
            {
                this.pauseButton.Image = Properties.Resources.pause_button_24;
                this._pausedBlink = true;
            }
        }

        private void recordButton_Click(object sender, EventArgs e)
        {
            // Check to make sure the recording device is selected and recording isn't already in progress
            if (this._recorder == null || !this._recorder.ReadyToRecord())
            {
                MessageBox.Show("Please select a recording device in File>Settings", "Recording Device Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else if (this._recorder.Recording())
            {
                return;
            }
            else if (this._recorder.Paused())
            {
                this._recorder.ResumePausedCapture();
                SetButtonState(RecordingState.Recording);
                return;
            }

            // Fetch recording preferences
            var fileName = Path.Combine(this._writeDir, DateTime.Now.ToString("yyyy-MM-dd dddd h꞉mm꞉ss tt"));
            var bitrate = Properties.Settings.Default.bitrate;
            var codec = (AvailableCodecs) Properties.Settings.Default.writeCodec;
            var channels = Channels.Stereo;

            // Start recording
            this._recorder.StartCapture(fileName, codec, bitrate, channels);

            SetButtonState(RecordingState.Recording);
        }

        private void stopButton_Click(object sender, EventArgs e)
        {
            if (_recorder != null)
            {
                _recorder.StopCapture();
                previousRecordings.DisplayRecentFiles();
                SetButtonState(RecordingState.Stopped);
            }
        }

        private void pauseButton_Click(object sender, EventArgs e)
        {
            if (_recorder != null)
            {
                _recorder.PauseCapture();
                SetButtonState(RecordingState.Paused);
            }
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = new AboutWindows();
            form.Show();
        }
        
        private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = new SettingsWindow();
            form.Show(this);
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // TODO: Wait or force close any running threads.
            this.Close();
        }

        private void resetWindowSizeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
            this.Width = Properties.Settings.Default.mainWindow_defaultWidth;
            this.Height = Properties.Settings.Default.mainWindow_defaultHeight;
        }

        private void refreshToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.previousRecordings.DisplayRecentFiles();
        }

        private void refreshRecentFilesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.previousRecordings.DisplayRecentFiles();
        }

        /// <summary>
        /// Controls how often the levels image is updated.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void levelsUpdateTimer_Tick(object sender, EventArgs e)
        {
            // Fetch and add the peak samples
            var samples = this._audioMeter?.GetChannelsPeakValues();

            if (_audioMeter != null)  // TODO: Channels!
            {
                // TODO: Audio meter not working on stereo mix or microphone input.
                // TODO: Add support for different channel configurations. e.g. mono
                this._levelsVisualization.AddSamples(samples[0], samples[1]);

                // TODO: Peak scale seems off
                Console.WriteLine(samples[0]);
            }

            // Draw the levels image
            var levelsImage = this.levelsVisualizationPictureBox.Image;
            this.levelsVisualizationPictureBox.Image = this._levelsVisualization.Draw(this.levelsVisualizationPictureBox.Width, this.visualizationPictureBox.Height);

            levelsImage?.Dispose();
        }

        private void visualUpdateTimer_Tick(object sender, EventArgs e)
        {
            if (this._mainVisualization != null)
            {
                // Update main visualization
                // TODO: how intesive is this?
                var visualizationImage = this.visualizationPictureBox.Image;
                this.visualizationPictureBox.Image = _mainVisualization.Draw(visualizationPictureBox.Width, visualizationPictureBox.Height);

                visualizationImage?.Dispose();
            }
        }

        private void buttonAnimationTimer_Tick(object sender, EventArgs e)
        {
            AnimatePauseButton();
        }
    }
}

