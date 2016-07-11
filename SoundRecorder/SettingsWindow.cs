using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CSCore.CoreAudioAPI;
using CSCore.Win32;
using CSCore.Codecs.WAV;
using CSCore.Streams;

namespace SoundRecorder
{
    public partial class SettingsWindow : Form
    {
        private string _writeDir;
        private MMDeviceCollection _inputRenderDevices;
        private MMDeviceCollection _inputCaptureDevices;
        private string _inputDevice;

        public SettingsWindow()
        {
            InitializeComponent();

            // Add the input devices to the input devices combo box
            RefreshDevices();

            this._writeDir = Properties.Settings.Default.writeDir;
            this._inputDevice = Properties.Settings.Default.inputDevice;

            // Set fields to current saved values.

            // Write Directory
            saveDirectoryTextBox.Text = _writeDir;

            // Input device
            RefreshDevices();
            SelectCurrentInputDevice();

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

        private void saveFolderBrowserDialog_HelpRequest(object sender, EventArgs e)
        {
            
        }

        private void acceptButton_Click(object sender, EventArgs e)
        {
            // Save all fields to the settings
            Properties.Settings.Default.writeDir = _writeDir;
            Properties.Settings.Default.inputDevice = _inputDevice;

            // Update the current capture device in the main window
            var parentForm = (MainWindow)this.Owner;
            if (parentForm != null)
            {
                parentForm.SetCaptureDevice();
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
                    Console.WriteLine(device);
                    deviceDictonary.Add(device.DeviceID, device.FriendlyName);
                }

                foreach (var device in inputCaptureDevices)
                {
                    Console.WriteLine(device);
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
            this.inputDeviceComboBox.SelectedItem = this._inputDevice;
        }

        private void deviceComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            this._inputDevice = ((KeyValuePair<string, string>)this.inputDeviceComboBox.SelectedItem).Key;
        }
    }
}
