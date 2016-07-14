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
        private Codec _writeCodec;
        private string _inputDevice;

        private MMDeviceCollection _inputRenderDevices;
        private MMDeviceCollection _inputCaptureDevices;


        public SettingsWindow()
        {
            InitializeComponent();

            // Load the input devices before the settings as loading them will update the index chane in the combo box.
            RefreshDevices();

            // Load the available codecs into the combo box
            this.recordingFormatComboBox.DataSource = Enum.GetValues(typeof(Codec));

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
            this._writeCodec = (Codec) Properties.Settings.Default.writeCodec;

            // Set the write directory to the saved value
            this.saveDirectoryTextBox.Text = this._writeDir;

            //Load the user selected codec in
            this.recordingFormatComboBox.SelectedItem = this._writeCodec;
        }

        public void SaveSettings()
        {
            // Save all fields to the settings
            Properties.Settings.Default.writeDir = this._writeDir;
            Properties.Settings.Default.inputDevice = this._inputDevice;
            Properties.Settings.Default.writeCodec = (int) this._writeCodec; 

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
            if (parentForm != null)
            {
                parentForm.LoadSettings();
            }

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
            using (var inputRenderDevices = deviceRenderEnumerator.EnumAudioEndpoints(DataFlow.Render, DeviceState.Active))
            using (var inputCaptureDevices = deviceRenderEnumerator.EnumAudioEndpoints(DataFlow.Capture, DeviceState.Active))
            {

                foreach (var device in inputRenderDevices)
                {
                    deviceDictonary.Add(device.DeviceID, device.FriendlyName);
                }

                foreach (var device in inputCaptureDevices)
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
            Enum.TryParse<Codec>(this.recordingFormatComboBox.SelectedValue.ToString(), out this._writeCodec);
        }
    }
}
