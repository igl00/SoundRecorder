using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using CSCore.CoreAudioAPI;

namespace SoundRecorder
{
    public partial class SettingsWindow : Form
    {
        private string _writeDir;
        private AvailableCodecs _writeAvailableCodecs;
        private string _inputDevice;

        private MMDeviceCollection _inputRenderDevices;
        private MMDeviceCollection _inputCaptureDevices;


        public SettingsWindow()
        {
            InitializeComponent();

            // Load the input devices before the settings as loading them will update the index chane in the combo box.
            RefreshDevices();

            // Load the available codecs into the combo box
            this.recordingFormatComboBox.DataSource = Enum.GetValues(typeof(AvailableCodecs));

            // Load the saved settings. Stored in C:\Users\<USER>\AppData\Local\<COMPANY NAME>\
            LoadSettings();

            // Add the input devices to the input devices combo box
            SelectCurrentInputDevice();
        }

        public void LoadSettings()
        {
            // Fetch the saved settings
            this._writeDir = Properties.Settings.Default.writeDir;
            this._inputDevice = Properties.Settings.Default.inputDevice;
            this._writeAvailableCodecs = (AvailableCodecs) Properties.Settings.Default.writeCodec;

            // Set the write directory to the saved value
            this.saveDirectoryTextBox.Text = this._writeDir;

            //Load the user selected availableCodecs in
            this.recordingFormatComboBox.SelectedItem = this._writeAvailableCodecs;
        }

        public void SaveSettings()
        {
            // Save all fields to the settings
            Properties.Settings.Default.writeDir = this._writeDir;
            Properties.Settings.Default.inputDevice = this._inputDevice;
            Properties.Settings.Default.writeCodec = (int) this._writeAvailableCodecs; 

            Properties.Settings.Default.Save();
        }

        private void ChooseFolder()
        {
            // TODO: Start at currently selected folder?

            if (saveFolderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                _writeDir = saveFolderBrowserDialog.SelectedPath;
                saveDirectoryTextBox.Text = saveFolderBrowserDialog.SelectedPath;
            }
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void acceptButton_Click(object sender, EventArgs e)
        {
            SaveSettings();

            // Load the updated settings into the main window.
            var parentForm = (MainWindow)this.Owner;
            parentForm?.LoadSettings();

            this.Close();
        }

        private void saveDirectoryTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (!Directory.Exists(saveDirectoryTextBox.Text))
                {
                    saveDirectoryTextBox.Text = _writeDir;
                }
            }
        }

        private void browseButton_Click(object sender, EventArgs e)
        {
            ChooseFolder();
        }

        private void RefreshDevices()
        {
            Dictionary<string, string> deviceDictonary = new Dictionary<string, string>();

            using (var deviceRenderEnumerator = new MMDeviceEnumerator())
            using (var devices = deviceRenderEnumerator.EnumAudioEndpoints(DataFlow.All, DeviceState.Active))
            {
                foreach (var device in devices)
                {
                    deviceDictonary.Add(device.DeviceID, device.FriendlyName);
                }
                this.inputDeviceComboBox.DataSource = new BindingSource(deviceDictonary, null);
                this.inputDeviceComboBox.DisplayMember = "Value";
                this.inputDeviceComboBox.ValueMember = "Key";
            }
        }

        private void SelectCurrentInputDevice()
        {
            if (this._inputDevice == "")
            {
                return;
            }

            foreach (var item in this.inputDeviceComboBox.Items)
            {
                var key = ((KeyValuePair<string, string>)item).Key;

                if (key == this._inputDevice)
                {
                    this.inputDeviceComboBox.SelectedItem = item;
                    break;
                }
            }
        }

        private void deviceComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            this._inputDevice = ((KeyValuePair<string, string>)this.inputDeviceComboBox.SelectedItem).Key;
        }

        private void recordingFormatComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            Enum.TryParse<AvailableCodecs>(this.recordingFormatComboBox.SelectedValue.ToString(), out this._writeAvailableCodecs);
        }

        private void recordingFormatSettingsButton_Click(object sender, EventArgs e)
        {
            if (this.recordingFormatComboBox.SelectedValue.ToString() == AvailableCodecs.MP3.ToString())
            {
                Console.Out.WriteLine("MP3!");
            }
            if (this.recordingFormatComboBox.SelectedValue.ToString() == AvailableCodecs.AAC.ToString())
            {
                Console.Out.WriteLine("AAC!");
            }
            if (this.recordingFormatComboBox.SelectedValue.ToString() == AvailableCodecs.WAV.ToString())
            {
                MessageBox.Show("There are no settings for WAV recording", "Sound Recorder", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            if (this.recordingFormatComboBox.SelectedValue.ToString() == AvailableCodecs.WMA.ToString())
            {
                Console.Out.WriteLine("WMA!");
            }
        }
    }
}
