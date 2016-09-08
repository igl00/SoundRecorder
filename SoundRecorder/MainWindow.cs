using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Text;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Forms;

using CSCore;  // WaveFormat, WaveFormatExtensible
using CSCore.CoreAudioAPI;  // MMDeviceEnumerator, DataFlow
using CSCore.Codecs.WAV;
using CSCore.MediaFoundation;
using CSCore.SoundIn;  //WasapiCapture, WasapiLoopbackCapture
using CSCore.Streams;
using Microsoft.WindowsAPICodePack.Shell;
using Microsoft.WindowsAPICodePack.Shell.PropertySystem;


namespace SoundRecorder
{
    public partial class MainWindow : Form
    {
        private int CaptureMode = (int)CaptureModeOptions.LoopbackCapture;

        private string _captureDeviceGUID;
        private Codec _writeCodec;
        private string _writeDir;
        
        private MMDevice _selectedDevice;
        private WasapiCapture _soundIn;
        private IWriteable _writer;
        private IWaveSource _finalSource;
        private RecordingVisualization _visualization;
        private LevelsVisualization _levelsVisualization = new LevelsVisualization();
        private PeakMeter _peakMeter;

        private int _sortColumn = -1;

        // Icon Font
        private Font _iconFont;
        
        // Focused Item in Previous Recordings
        private string _focusedPreviousRecording;

        public MMDevice SelectedDevice
        {
            get { return _selectedDevice; }
            set
            {
                _selectedDevice = value;
                if (value != null)
                    recordButton.Enabled = true;
            }
        }

        public MainWindow()
        {
            InitializeComponent();

            // Load in the user settings.
            LoadSettings();

            // Restore the dimensions of the window from the last session.
            RestoreWindow();

            // Make sure the write directory is set to something and the folder exists.
            CheckWriteDirectory();

            // Set the selected recording device from the settings file.
            SetCaptureDevice();

            // Set the initial button state
            // Disable record button if no recording device is initialized.
            InitializeIconFont();

            recordButton.Font = this._iconFont;
            pauseButton.Font = this._iconFont;
            stopButton.Font = this._iconFont;

            if (SelectedDevice == null)
            {
                recordButton.Enabled = false;
            }
            else
            {
                this.stopButton.Enabled = false;
                this.pauseButton.Enabled = false;
            }

            // Show the recent files in the output directory
            DisplayRecentFiles();
        }

        public void LoadSettings()
        {
            // Load user settings
            this._captureDeviceGUID = Properties.Settings.Default.inputDevice;
            this._writeDir = Properties.Settings.Default.writeDir;
            this._writeCodec = (Codec) Properties.Settings.Default.writeCodec;
        }

        public void RestoreWindow()
        {
            // Restore window settings
            var width = Properties.Settings.Default.mainWindow_width;
            var height = Properties.Settings.Default.mainWindow_height;

            if (width > 0 && height > 0)
            {
                this.Width = width;
                this.Height = height;
            }

            this.WindowState = (FormWindowState)Properties.Settings.Default.mainWindow_state;
        }

        public void CheckWriteDirectory()
        {
            // Set the write directory
            if (_writeDir == "")
            {
                _writeDir = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "Recordings");
                Properties.Settings.Default.writeDir = _writeDir;
                Properties.Settings.Default.Save();
            }

            if (!Directory.Exists(_writeDir))
            {
                try
                {
                    Directory.CreateDirectory(_writeDir);
                }
                catch (System.ArgumentException e)
                {
                    // TODO: Need to understand the correct procedure here.
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
            StopCapture();
            SaveSettings();
        }

        public void InitializeIconFont()
        {
            // FROM: http://stackoverflow.com/questions/1297264/using-custom-fonts-on-a-label-on-winforms
            //Create your private font collection object.
            PrivateFontCollection privateFontCollection = new PrivateFontCollection();

            //Select your font from the resources.
            //My font here is "fontawesome.ttf"
            int fontLength = Properties.Resources.fontawesome.Length;

            // create a buffer to read in to
            byte[] fontdata = Properties.Resources.fontawesome;

            // create an unsafe memory block for the font data
            IntPtr data = Marshal.AllocCoTaskMem(fontLength);

            // copy the bytes to the unsafe memory block
            Marshal.Copy(fontdata, 0, data, fontLength);

            // pass the font to the font collection
            privateFontCollection.AddMemoryFont(data, fontLength);

            // free up the unsafe memory
            Marshal.FreeCoTaskMem(data);

            this._iconFont = new Font(privateFontCollection.Families[0], 14);
        }

        private void InitializeVisualization()
        {
            var screens = Screen.AllScreens;
            var maxWidth = 600; // Default in case no screen is plugged in.

            foreach (var screen in screens)
            {
                maxWidth = screen.Bounds.Width;
            }

            this._visualization = new RecordingVisualization(maxWidth);
        }

        public void SetCaptureDevice()
        {
            using (var deviceRenderEnumerator = new MMDeviceEnumerator())
            using (var inputRenderDevices = deviceRenderEnumerator.EnumAudioEndpoints(DataFlow.Render, DeviceState.Active))
            using (var inputCaptureDevices = deviceRenderEnumerator.EnumAudioEndpoints(DataFlow.Capture, DeviceState.Active))
            {

                foreach (var device in inputRenderDevices)
                {
                    if (device.DeviceID == this._captureDeviceGUID)
                    {
                        this.SelectedDevice = device;
                        this.CaptureMode = (int)CaptureModeOptions.LoopbackCapture;
                    }
                }

                foreach (var device in inputCaptureDevices)
                {
                    if (device.DeviceID == this._captureDeviceGUID)
                    {
                        this.SelectedDevice = device;
                        this.CaptureMode = (int)CaptureModeOptions.Capture;
                    }
                }
            }

            if (this._selectedDevice != null)
            {
                this.recordButton.Enabled = true;
            }
        }

        private void StartCapture(string fileName)
        {
            // Check to make sure the recording device is selected and recording isn't already in progress
            if (SelectedDevice == null || (_soundIn != null && _soundIn.RecordingState == RecordingState.Recording))
            {
                return;
            }
            else if (_soundIn != null && _soundIn.RecordingState == RecordingState.Stopped)
            {
                _soundIn.Start();
                this.recordButton.Enabled = false;
                return;
            }


            if (CaptureMode == (int)CaptureModeOptions.Capture)
                _soundIn = new WasapiCapture();
            else
                _soundIn = new WasapiLoopbackCapture();

            _soundIn.Device = SelectedDevice;
            _soundIn.Initialize();

            var soundInSource = new SoundInSource(_soundIn);
            var singleBlockNotificationStream = new SingleBlockNotificationStream(soundInSource.ToSampleSource());
            _finalSource = singleBlockNotificationStream.ToWaveSource();


            var bitRate = Properties.Settings.Default.bitrate;

            // MP3 Write
            if (_writeCodec == Codec.MP3)
            {
                _writer = MediaFoundationEncoder.CreateMP3Encoder(soundInSource.ToStereo().WaveFormat, fileName, bitRate);
            }

            // AAC Write
            if (_writeCodec == Codec.AAC)
            {
                _writer = MediaFoundationEncoder.CreateAACEncoder(soundInSource.ToStereo().WaveFormat, fileName, bitRate);
            }

            // WMA Write
            if (_writeCodec == Codec.WMA)
            {
                _writer = MediaFoundationEncoder.CreateWMAEncoder(soundInSource.ToStereo().WaveFormat, fileName, bitRate);
            }

            // Wave Writer
            if (_writeCodec == Codec.WAV)
            {
                _writer = new WaveWriter(fileName, _finalSource.WaveFormat);
            }

            byte[] buffer = new byte[_finalSource.WaveFormat.BytesPerSecond / 2];

            soundInSource.DataAvailable += (s, e) =>
            {
                int read;
                while ((read = _finalSource.Read(buffer, 0, buffer.Length)) > 0)
                    _writer.Write(buffer, 0, read);
            };
            
            singleBlockNotificationStream.SingleBlockRead += SingleBlockNotificationStreamOnSingleBlockRead;

            this.recordButton.Enabled = false;
            // Create a new peak meter for the source
            this._peakMeter = new PeakMeter(soundInSource.ToSampleSource());

            // Start recording
            _soundIn.Start();
        }

        private void StopCapture()
        {
            if (_soundIn != null)
            {
                _soundIn.Stop();
                _soundIn.Dispose();
                _soundIn = null;
                _finalSource.Dispose();

                if (_writer is IDisposable)
                    ((IDisposable)_writer).Dispose();

                // Dispose of the peakmeter
                this._peakMeter.Dispose();

                recordButton.Enabled = true;
            }
        }

        private void SingleBlockNotificationStreamOnSingleBlockRead(object sender, SingleBlockReadEventArgs e)
        {
            _visualization.AddSamples(e.Left, e.Right);  // TODO: Should this be spun up in a thread? If so how will the order be maintained?
            _levelsVisualization.AddSamples(e.Left, e.Right);
        }

        public string GetDateSuffix(int day)
        {
            switch (day)
            {
                case 1: return "st";
                case 2: return "nd";
                case 3: return "rd";
                default: return "th";
            }
        }

        private void recordButton_Click(object sender, EventArgs e)
        {
            var extension = _writeCodec.ToString().ToLower();
            var timeStamp = DateTime.Now.ToString("yyyy-MM-dd dddd h꞉mm꞉ss tt");
            var fileName = String.Format("{0}.{1}", timeStamp, extension);

            StartCapture(Path.Combine(this._writeDir, fileName));

            // Created fresh here to get the new screen dimensions in case of mulitple monitor setup.
            InitializeVisualization();

            this.recordButton.Enabled = false;
            this.stopButton.Enabled = true;
            this.pauseButton.Enabled = true;
        }

        private void stopButton_Click(object sender, EventArgs e)
        {
            StopCapture();
            DisplayRecentFiles();

            this.recordButton.Enabled = true;
            this.stopButton.Enabled = false;
            this.pauseButton.Enabled = false;
        }

        private void pauseButton_Click(object sender, EventArgs e)
        {
            // kj is amazing.
            if (_soundIn != null)
            {
                if (_soundIn.RecordingState == RecordingState.Recording)
                {
                    _soundIn.Stop();
                    this.recordButton.Enabled = true;
                }
                else
                {
                    _soundIn.Start();
                    this.recordButton.Enabled = false;
                }
            }
            
        }

        private void aboutToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            var form = new AboutWindows();
            form.Show();
        }
        
        private void DisplayRecentFiles()
        {
            this.listPreviousRecordings.Items.Clear();

            var extensions = new List<string> {".mp3", ".wav", ".flac", ".aac", ".ac3", ".wma"};  // TODO: Load formats from Codec Enum?
            var files = Directory.GetFiles(_writeDir, "*.*", SearchOption.AllDirectories)
                 .Where(s => extensions.Any(e => s.ToLower().EndsWith(e)));

            foreach (var file in files)
            {
                var path = Path.GetFileName(file);
                var length = "";
                var created = File.GetCreationTime(file).ToString();

                // Get the duration using the WindowsAPICodePack
                ShellObject audioFile = ShellObject.FromParsingName(file);
                var duration = GetWindowsAPIDurationValue(audioFile.Properties.GetProperty(SystemProperties.System.Media.Duration));
                length = TimeSpan.FromMilliseconds(duration).ToString(@"hh\:mm\:ss");

                var listItem = new ListViewItem(new[] { path, length, created }) { Tag = file };
                this.listPreviousRecordings.Items.Add(listItem);
            }
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

        private static double GetWindowsAPIDurationValue(IShellProperty value)
        {
            if (value == null || value.ValueAsObject == null)
            {
                return 0;
            }
            // Divide the value by 10000 to convert it into a timespan using FromMilliseconds
            return Convert.ToDouble(value.ValueAsObject.ToString()) / 10000;
        }

        public enum CaptureModeOptions
        {
            Capture,
            LoopbackCapture
        }

        private void visualUpdateTimer_Tick(object sender, EventArgs e)
        {
            if (this._visualization != null)
            {
                // Update main visualization
                // TODO: how intesive is this?
                var visualizationImage = this.visualizationPictureBox.Image;
                this.visualizationPictureBox.Image = _visualization.Draw(visualizationPictureBox.Width, visualizationPictureBox.Height);

                visualizationImage?.Dispose();
            }
        }

        private void resetWindowSizeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
            this.Width = Properties.Settings.Default.mainWindow_defaultWidth;
            this.Height = Properties.Settings.Default.mainWindow_defaultHeight;
        }

        private void listPreviousRecordings_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Process.Start("explorer.exe", Path.Combine(this._writeDir, this.listPreviousRecordings.SelectedItems[0].Text));
            }
        }

        private void listPreviousRecordings_MouseDown(object sender, MouseEventArgs e)
        {
            var hitInfo = listPreviousRecordings.HitTest(e.Location);

            if (e.Button == MouseButtons.Right)
            {
                if (hitInfo.Location == ListViewHitTestLocations.Label)
                {
                    previousRecordingsContextMenu.Show(Cursor.Position);
                }
                else
                {
                    previousRecordingsRefreshMenu.Show(Cursor.Position);
                }
            }
        }

        private void listPreviousRecordings_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            // Determine whether the column is the same as the last column clicked.
            if (e.Column != _sortColumn)
            {
                // Set the sort column to the new column.
                _sortColumn = e.Column;
                // Set the sort order to ascending by default.
                this.listPreviousRecordings.Sorting = SortOrder.Ascending;
            }
            else
            {
                // Determine what the last sort order was and change it.
                if (this.listPreviousRecordings.Sorting == SortOrder.Ascending)
                    this.listPreviousRecordings.Sorting = SortOrder.Descending;
                else
                    this.listPreviousRecordings.Sorting = SortOrder.Ascending;
            }

            // Call the sort method to manually sort.
            this.listPreviousRecordings.Sort();
            // Set the ListViewItemSorter property to a new ListViewItemComparer
            // object.
            this.listPreviousRecordings.ListViewItemSorter = new ListViewItemComparer(e.Column, this.listPreviousRecordings.Sorting);

        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start("explorer.exe", Path.Combine(this._writeDir, this.listPreviousRecordings.FocusedItem.Text));
        }

        private void renameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            listPreviousRecordings.FocusedItem.BeginEdit();
        }

        private void openFolderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start("explorer.exe", this._writeDir);
        }

        private void listPreviousRecordings_beforeLabelEdit(object sender, System.Windows.Forms.LabelEditEventArgs e)
        {
            // Using focusedItem to set the string as the e.Label is empty.
            this._focusedPreviousRecording = this.listPreviousRecordings.FocusedItem.Text;
        }
        
        private void listPreviousRecordings_afterLabelEdit(object sender, System.Windows.Forms.LabelEditEventArgs e)
        {
            if (e.Label != null && this._focusedPreviousRecording != e.Label)
            {
                // Check to make sure the new filename has an extension
                var fileExtension = e.Label.Split(new string[] {"."}, StringSplitOptions.RemoveEmptyEntries);

                if (fileExtension.Length < 2)
                {
                    MessageBox.Show("File needs to have an extension! e.g. '.mp3'",
                        "Sound Recorder: Rename Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    e.CancelEdit = true;
                    return;
                }

                // Check to make sure the filename has an accepted extension and then try rename the file.
                if (Enum.IsDefined(typeof(Codec), fileExtension[fileExtension.Length - 1].ToUpper()))
                {
                    try
                    {
                        System.IO.File.Move(Path.Combine(this._writeDir, this._focusedPreviousRecording),
                            Path.Combine(this._writeDir, e.Label));
                    }
                    catch (System.IO.IOException)
                    {
                        MessageBox.Show("Maybe a file with that name already exists?",
                            "Sound Recorder: Rename Error",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                        e.CancelEdit = true;
                        return;
                    }
                    catch (System.NotSupportedException)
                    {
                        MessageBox.Show("Did you use an unsupported character? e.g. ':' ", 
                            "Sound Recorder: Rename Error", 
                            MessageBoxButtons.OK, 
                            MessageBoxIcon.Error);
                        e.CancelEdit = true;
                        return;
                    }
                }
                else
                {
                    MessageBox.Show("Extension must be of type: 'mp3', 'wav', 'wma', or 'aac'.", // TODO: List these from the codecs enum.
                        "Sound Recorder: Rename Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    e.CancelEdit = true;
                    return;
                }
            }
        }

        private void refreshToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DisplayRecentFiles();
        }

        /// <summary>
        /// Controls how often the levels image is updated.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void levelsUpdateTimer_Tick(object sender, EventArgs e)
        {
            // Draw the levels image
            var levelsImage = this.levelsVisualizationPictureBox.Image;
            this.levelsVisualizationPictureBox.Image = this._levelsVisualization.Draw(this.levelsVisualizationPictureBox.Width, this.visualizationPictureBox.Height);

            levelsImage?.Dispose();
        }
    }
}

// Implements the manual sorting of items by column.
// Taken from: https://msdn.microsoft.com/en-us/library/ms996467.aspx
// Implements the manual sorting of items by columns.
class ListViewItemComparer : IComparer
{
    private int col;
    private SortOrder order;
    public ListViewItemComparer()
    {
        col = 0;
        order = SortOrder.Ascending;
    }
    public ListViewItemComparer(int column, SortOrder order)
    {
        col = column;
        this.order = order;
    }
    public int Compare(object x, object y)
    {
        int returnVal;
        if (col == 2)
        {
            // Determine whether the type being compared is a date type.
            try
            {
                // Parse the two objects passed as a parameter as a DateTime.
                System.DateTime firstDate = DateTime.Parse(((ListViewItem)x).SubItems[col].Text);
                System.DateTime secondDate = DateTime.Parse(((ListViewItem)y).SubItems[col].Text);
                // Compare the two dates.
                returnVal = DateTime.Compare(firstDate, secondDate);
            }
            // If neither compared object has a valid date format, compare
            // as a string.
            catch
            {
                // Compare the two items as a string.
                returnVal = String.Compare(((ListViewItem)x).SubItems[col].Text, ((ListViewItem)y).SubItems[col].Text);
            }
        }
        else
        {
            // Compare the two items as a string.
            returnVal = String.Compare(((ListViewItem)x).SubItems[col].Text, ((ListViewItem)y).SubItems[col].Text);
        }

        // Determine whether the sort order is descending.
        if (order == SortOrder.Descending)
            // Invert the value returned by String.Compare.
            returnVal *= -1;
        return returnVal;
    }
}
