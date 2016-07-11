using System.Windows.Forms;

namespace SoundRecorder
{
    partial class SettingsWindow
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.saveFolderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.settingsWindowTableLayout = new System.Windows.Forms.TableLayoutPanel();
            this.acceptCancelFlowLayout = new System.Windows.Forms.FlowLayoutPanel();
            this.acceptButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.settingsTableLayout = new System.Windows.Forms.TableLayoutPanel();
            this.outputDirGroupBox = new System.Windows.Forms.GroupBox();
            this.outputDirTableLayout = new System.Windows.Forms.TableLayoutPanel();
            this.outputDirBrowseButton = new System.Windows.Forms.Button();
            this.saveDirectoryTextBox = new System.Windows.Forms.TextBox();
            this.inputDeviceGroupBox = new System.Windows.Forms.GroupBox();
            this.inputDeviceTableLayout = new System.Windows.Forms.TableLayoutPanel();
            this.inputDeviceComboBox = new System.Windows.Forms.ComboBox();
            this.inputDeviceRefreshButton = new System.Windows.Forms.Button();
            this.recordingFormatGroupBox = new System.Windows.Forms.GroupBox();
            this.recordingFormatTableLayout = new System.Windows.Forms.TableLayoutPanel();
            this.recordingFormatSettingsButton = new System.Windows.Forms.Button();
            this.recordingFormatComboBox = new System.Windows.Forms.ComboBox();
            this.settingsWindowTableLayout.SuspendLayout();
            this.acceptCancelFlowLayout.SuspendLayout();
            this.settingsTableLayout.SuspendLayout();
            this.outputDirGroupBox.SuspendLayout();
            this.outputDirTableLayout.SuspendLayout();
            this.inputDeviceGroupBox.SuspendLayout();
            this.inputDeviceTableLayout.SuspendLayout();
            this.recordingFormatGroupBox.SuspendLayout();
            this.recordingFormatTableLayout.SuspendLayout();
            this.SuspendLayout();
            // 
            // saveFolderBrowserDialog
            // 
            this.saveFolderBrowserDialog.HelpRequest += new System.EventHandler(this.saveFolderBrowserDialog_HelpRequest);
            // 
            // settingsWindowTableLayout
            // 
            this.settingsWindowTableLayout.ColumnCount = 1;
            this.settingsWindowTableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.settingsWindowTableLayout.Controls.Add(this.acceptCancelFlowLayout, 0, 1);
            this.settingsWindowTableLayout.Controls.Add(this.settingsTableLayout, 0, 0);
            this.settingsWindowTableLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.settingsWindowTableLayout.Location = new System.Drawing.Point(0, 0);
            this.settingsWindowTableLayout.Name = "settingsWindowTableLayout";
            this.settingsWindowTableLayout.RowCount = 2;
            this.settingsWindowTableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 88.06451F));
            this.settingsWindowTableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.93548F));
            this.settingsWindowTableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.settingsWindowTableLayout.Size = new System.Drawing.Size(464, 311);
            this.settingsWindowTableLayout.TabIndex = 0;
            // 
            // acceptCancelFlowLayout
            // 
            this.acceptCancelFlowLayout.Controls.Add(this.acceptButton);
            this.acceptCancelFlowLayout.Controls.Add(this.cancelButton);
            this.acceptCancelFlowLayout.Dock = System.Windows.Forms.DockStyle.Right;
            this.acceptCancelFlowLayout.Location = new System.Drawing.Point(299, 276);
            this.acceptCancelFlowLayout.Name = "acceptCancelFlowLayout";
            this.acceptCancelFlowLayout.Size = new System.Drawing.Size(162, 32);
            this.acceptCancelFlowLayout.TabIndex = 5;
            // 
            // acceptButton
            // 
            this.acceptButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.acceptButton.Location = new System.Drawing.Point(3, 3);
            this.acceptButton.Name = "acceptButton";
            this.acceptButton.Size = new System.Drawing.Size(75, 23);
            this.acceptButton.TabIndex = 0;
            this.acceptButton.Text = "OK";
            this.acceptButton.UseVisualStyleBackColor = true;
            this.acceptButton.Click += new System.EventHandler(this.acceptButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(84, 3);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 1;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // settingsTableLayout
            // 
            this.settingsTableLayout.ColumnCount = 1;
            this.settingsTableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.settingsTableLayout.Controls.Add(this.outputDirGroupBox, 0, 0);
            this.settingsTableLayout.Controls.Add(this.inputDeviceGroupBox, 0, 1);
            this.settingsTableLayout.Controls.Add(this.recordingFormatGroupBox, 0, 2);
            this.settingsTableLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.settingsTableLayout.Location = new System.Drawing.Point(3, 3);
            this.settingsTableLayout.Name = "settingsTableLayout";
            this.settingsTableLayout.RowCount = 4;
            this.settingsTableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 55F));
            this.settingsTableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 55F));
            this.settingsTableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 55F));
            this.settingsTableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.settingsTableLayout.Size = new System.Drawing.Size(458, 267);
            this.settingsTableLayout.TabIndex = 6;
            // 
            // outputDirGroupBox
            // 
            this.outputDirGroupBox.Controls.Add(this.outputDirTableLayout);
            this.outputDirGroupBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.outputDirGroupBox.Location = new System.Drawing.Point(3, 3);
            this.outputDirGroupBox.Name = "outputDirGroupBox";
            this.outputDirGroupBox.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.outputDirGroupBox.Size = new System.Drawing.Size(452, 49);
            this.outputDirGroupBox.TabIndex = 7;
            this.outputDirGroupBox.TabStop = false;
            this.outputDirGroupBox.Text = "Output Directory";
            // 
            // outputDirTableLayout
            // 
            this.outputDirTableLayout.ColumnCount = 2;
            this.outputDirTableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.outputDirTableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.outputDirTableLayout.Controls.Add(this.outputDirBrowseButton, 0, 0);
            this.outputDirTableLayout.Controls.Add(this.saveDirectoryTextBox, 0, 0);
            this.outputDirTableLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.outputDirTableLayout.Location = new System.Drawing.Point(3, 16);
            this.outputDirTableLayout.Name = "outputDirTableLayout";
            this.outputDirTableLayout.RowCount = 1;
            this.outputDirTableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.outputDirTableLayout.Size = new System.Drawing.Size(446, 30);
            this.outputDirTableLayout.TabIndex = 0;
            // 
            // outputDirBrowseButton
            // 
            this.outputDirBrowseButton.AutoSize = true;
            this.outputDirBrowseButton.Location = new System.Drawing.Point(369, 3);
            this.outputDirBrowseButton.Name = "outputDirBrowseButton";
            this.outputDirBrowseButton.Size = new System.Drawing.Size(74, 23);
            this.outputDirBrowseButton.TabIndex = 3;
            this.outputDirBrowseButton.Text = "Browse";
            this.outputDirBrowseButton.UseVisualStyleBackColor = true;
            this.outputDirBrowseButton.Click += new System.EventHandler(this.browseButton_Click);
            // 
            // saveDirectoryTextBox
            // 
            this.saveDirectoryTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.saveDirectoryTextBox.Location = new System.Drawing.Point(3, 3);
            this.saveDirectoryTextBox.Name = "saveDirectoryTextBox";
            this.saveDirectoryTextBox.Size = new System.Drawing.Size(360, 20);
            this.saveDirectoryTextBox.TabIndex = 2;
            this.saveDirectoryTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.saveDirectoryTextBox_KeyDown);
            // 
            // inputDeviceGroupBox
            // 
            this.inputDeviceGroupBox.Controls.Add(this.inputDeviceTableLayout);
            this.inputDeviceGroupBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.inputDeviceGroupBox.Location = new System.Drawing.Point(3, 58);
            this.inputDeviceGroupBox.Name = "inputDeviceGroupBox";
            this.inputDeviceGroupBox.Size = new System.Drawing.Size(452, 49);
            this.inputDeviceGroupBox.TabIndex = 8;
            this.inputDeviceGroupBox.TabStop = false;
            this.inputDeviceGroupBox.Text = "Input Device";
            // 
            // inputDeviceTableLayout
            // 
            this.inputDeviceTableLayout.ColumnCount = 2;
            this.inputDeviceTableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.inputDeviceTableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.inputDeviceTableLayout.Controls.Add(this.inputDeviceComboBox, 0, 0);
            this.inputDeviceTableLayout.Controls.Add(this.inputDeviceRefreshButton, 1, 0);
            this.inputDeviceTableLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.inputDeviceTableLayout.Location = new System.Drawing.Point(3, 16);
            this.inputDeviceTableLayout.Name = "inputDeviceTableLayout";
            this.inputDeviceTableLayout.RowCount = 1;
            this.inputDeviceTableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.inputDeviceTableLayout.Size = new System.Drawing.Size(446, 30);
            this.inputDeviceTableLayout.TabIndex = 0;
            // 
            // inputDeviceComboBox
            // 
            this.inputDeviceComboBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.inputDeviceComboBox.FormattingEnabled = true;
            this.inputDeviceComboBox.Location = new System.Drawing.Point(3, 3);
            this.inputDeviceComboBox.Name = "inputDeviceComboBox";
            this.inputDeviceComboBox.Size = new System.Drawing.Size(360, 21);
            this.inputDeviceComboBox.TabIndex = 1;
            this.inputDeviceComboBox.SelectedIndexChanged += new System.EventHandler(this.deviceComboBox_SelectedIndexChanged);
            // 
            // inputDeviceRefreshButton
            // 
            this.inputDeviceRefreshButton.Location = new System.Drawing.Point(369, 3);
            this.inputDeviceRefreshButton.Name = "inputDeviceRefreshButton";
            this.inputDeviceRefreshButton.Size = new System.Drawing.Size(74, 23);
            this.inputDeviceRefreshButton.TabIndex = 2;
            this.inputDeviceRefreshButton.Text = "Refresh";
            this.inputDeviceRefreshButton.UseVisualStyleBackColor = true;
            // 
            // recordingFormatGroupBox
            // 
            this.recordingFormatGroupBox.Controls.Add(this.recordingFormatTableLayout);
            this.recordingFormatGroupBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.recordingFormatGroupBox.Location = new System.Drawing.Point(3, 113);
            this.recordingFormatGroupBox.Name = "recordingFormatGroupBox";
            this.recordingFormatGroupBox.Size = new System.Drawing.Size(452, 49);
            this.recordingFormatGroupBox.TabIndex = 9;
            this.recordingFormatGroupBox.TabStop = false;
            this.recordingFormatGroupBox.Text = "Recording Format";
            // 
            // recordingFormatTableLayout
            // 
            this.recordingFormatTableLayout.ColumnCount = 2;
            this.recordingFormatTableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.recordingFormatTableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.recordingFormatTableLayout.Controls.Add(this.recordingFormatSettingsButton, 1, 0);
            this.recordingFormatTableLayout.Controls.Add(this.recordingFormatComboBox, 0, 0);
            this.recordingFormatTableLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.recordingFormatTableLayout.Location = new System.Drawing.Point(3, 16);
            this.recordingFormatTableLayout.Name = "recordingFormatTableLayout";
            this.recordingFormatTableLayout.RowCount = 1;
            this.recordingFormatTableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.recordingFormatTableLayout.Size = new System.Drawing.Size(446, 30);
            this.recordingFormatTableLayout.TabIndex = 0;
            // 
            // recordingFormatSettingsButton
            // 
            this.recordingFormatSettingsButton.Location = new System.Drawing.Point(369, 3);
            this.recordingFormatSettingsButton.Name = "recordingFormatSettingsButton";
            this.recordingFormatSettingsButton.Size = new System.Drawing.Size(74, 23);
            this.recordingFormatSettingsButton.TabIndex = 0;
            this.recordingFormatSettingsButton.Text = "Settings";
            this.recordingFormatSettingsButton.UseVisualStyleBackColor = true;
            // 
            // recordingFormatComboBox
            // 
            this.recordingFormatComboBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.recordingFormatComboBox.FormattingEnabled = true;
            this.recordingFormatComboBox.Location = new System.Drawing.Point(3, 3);
            this.recordingFormatComboBox.Name = "recordingFormatComboBox";
            this.recordingFormatComboBox.Size = new System.Drawing.Size(360, 21);
            this.recordingFormatComboBox.TabIndex = 1;
            // 
            // SettingsWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(464, 311);
            this.Controls.Add(this.settingsWindowTableLayout);
            this.MinimumSize = new System.Drawing.Size(480, 350);
            this.Name = "SettingsWindow";
            this.Text = "SettingsWindow";
            this.settingsWindowTableLayout.ResumeLayout(false);
            this.acceptCancelFlowLayout.ResumeLayout(false);
            this.settingsTableLayout.ResumeLayout(false);
            this.outputDirGroupBox.ResumeLayout(false);
            this.outputDirTableLayout.ResumeLayout(false);
            this.outputDirTableLayout.PerformLayout();
            this.inputDeviceGroupBox.ResumeLayout(false);
            this.inputDeviceTableLayout.ResumeLayout(false);
            this.recordingFormatGroupBox.ResumeLayout(false);
            this.recordingFormatTableLayout.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.FolderBrowserDialog saveFolderBrowserDialog;
        private System.Windows.Forms.TableLayoutPanel settingsWindowTableLayout;
        private System.Windows.Forms.FlowLayoutPanel acceptCancelFlowLayout;
        private System.Windows.Forms.Button acceptButton;
        private System.Windows.Forms.Button cancelButton;
        private TableLayoutPanel settingsTableLayout;
        private GroupBox outputDirGroupBox;
        private TableLayoutPanel outputDirTableLayout;
        private Button outputDirBrowseButton;
        private TextBox saveDirectoryTextBox;
        private GroupBox inputDeviceGroupBox;
        private GroupBox recordingFormatGroupBox;
        private TableLayoutPanel inputDeviceTableLayout;
        private ComboBox inputDeviceComboBox;
        private Button inputDeviceRefreshButton;
        private TableLayoutPanel recordingFormatTableLayout;
        private Button recordingFormatSettingsButton;
        private ComboBox recordingFormatComboBox;
    }
}