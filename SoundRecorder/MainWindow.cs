using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using CSCore;  // WaveFormat, WaveFormatExtensible
using CSCore.CoreAudioAPI;  // MMDeviceEnumerator, DataFlow
using CSCore.Win32;  // PropertyKey
using System.Runtime.InteropServices;  // Marshal

using CSCore.Codecs;
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
        //Change this to CaptureMode.Capture to capture a microphone,...
        private int CaptureMode = (int)CaptureModeOptions.LoopbackCapture;

        private MMDevice _selectedDevice;
        private WasapiCapture _soundIn;
        private IWriteable _writer;
        private IWaveSource _finalSource;
        private string _writeDir;

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

            // Set the write directory
            _writeDir = Properties.Settings.Default.writeDir;
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

            // Set the selected recording device from the settings file.
            SetCaptureDevice();

            // Check whether or not a recording device is selected.
            // If none is selected grey out the record button.
            if (SelectedDevice == null)
            {
                recordButton.Enabled = false;
            }

            // Show the recent files in the output directory
            DisplayRecentFiles();
        }

        public void MainWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Make sure the capture has stopped when the window is closed
            StopCapture();
        }

        public void SetCaptureDevice()
        {
            var captureDeviceId = Properties.Settings.Default.inputDevice;

            using (var deviceRenderEnumerator = new MMDeviceEnumerator())
            using (
                var inputRenderDevices = deviceRenderEnumerator.EnumAudioEndpoints(DataFlow.Render, DeviceState.Active))
            using (
                var inputCaptureDevices = deviceRenderEnumerator.EnumAudioEndpoints(DataFlow.Capture, DeviceState.Active)
                )
            {

                foreach (var device in inputRenderDevices)
                {
                    if (device.DeviceID == captureDeviceId)
                    {
                        this.SelectedDevice = device;
                        this.CaptureMode = (int)CaptureModeOptions.LoopbackCapture;
                    }
                }

                foreach (var device in inputCaptureDevices)
                {
                    if (device.DeviceID == captureDeviceId)
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
            if (SelectedDevice == null)
                return;

            if (CaptureMode == (int)CaptureModeOptions.Capture)
                _soundIn = new WasapiCapture();
            else
                _soundIn = new WasapiLoopbackCapture();

            _soundIn.Device = SelectedDevice;
            _soundIn.Initialize();

            var soundInSource = new SoundInSource(_soundIn);
            var singleBlockNotificationStream = new SingleBlockNotificationStream(soundInSource.ToSampleSource());
            _finalSource = singleBlockNotificationStream.ToWaveSource();
            _writer = new WaveWriter(fileName, _finalSource.WaveFormat);

            byte[] buffer = new byte[_finalSource.WaveFormat.BytesPerSecond / 2];

            soundInSource.DataAvailable += (s, e) =>
            {
                int read;
                while ((read = _finalSource.Read(buffer, 0, buffer.Length)) > 0)
                    _writer.Write(buffer, 0, read);
            };

            singleBlockNotificationStream.SingleBlockRead += SingleBlockNotificationStreamOnSingleBlockRead;

            this.recordButton.Enabled = false;

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

                recordButton.Enabled = true;
            }
        }

        private void SingleBlockNotificationStreamOnSingleBlockRead(object sender, SingleBlockReadEventArgs e)
        {
            //_graphVisualization.AddSamples(e.Left, e.Right);
        }

        private void recordButton_Click(object sender, EventArgs e)
        {
            StartCapture(Path.Combine(this._writeDir, DateTime.Now.ToString("yyyyMMddHHmmssffff") + ".wav"));
        }

        private void stopButton_Click(object sender, EventArgs e)
        {
            StopCapture();
            DisplayRecentFiles();
        }

        private void pauseButton_Click(object sender, EventArgs e)
        {

        }

        private void aboutToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            var form = new AboutWindows();
            form.Show();
        }
        
        private void DisplayRecentFiles()
        {
            this.listPreviousRecordings.Items.Clear();

            var extensions = new List<string> {".mp3", ".wav", ".flac", ".aac", ".ac3", ".wma"};  // The file formats supported by CSCore
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
            this.Close();
        }

        private void listPreviousRecordings_SelectedIndexChanged(object sender, EventArgs e)
        {

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
    }
}
