using System.Windows.Forms;

namespace SoundRecorder
{
    partial class MainWindow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWindow));
            this.menuMain = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fileToolStripSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.baseTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.listPreviousRecordings = new System.Windows.Forms.ListView();
            this.columnFileName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnDuration = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnCreated = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.recordingTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.waveformTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.leftChannelPictureBox = new System.Windows.Forms.PictureBox();
            this.rightChannelPictureBox = new System.Windows.Forms.PictureBox();
            this.buttonPanel = new System.Windows.Forms.Panel();
            this.pauseButton = new System.Windows.Forms.Button();
            this.stopButton = new System.Windows.Forms.Button();
            this.recordButton = new System.Windows.Forms.Button();
            this.menuMain.SuspendLayout();
            this.baseTableLayoutPanel.SuspendLayout();
            this.recordingTableLayoutPanel.SuspendLayout();
            this.waveformTableLayoutPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.leftChannelPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rightChannelPictureBox)).BeginInit();
            this.buttonPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuMain
            // 
            this.menuMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuMain.Location = new System.Drawing.Point(0, 0);
            this.menuMain.Name = "menuMain";
            this.menuMain.Size = new System.Drawing.Size(540, 24);
            this.menuMain.TabIndex = 0;
            this.menuMain.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.settingsToolStripMenuItem,
            this.fileToolStripSeparator,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            this.settingsToolStripMenuItem.Size = new System.Drawing.Size(116, 22);
            this.settingsToolStripMenuItem.Text = "Settings";
            this.settingsToolStripMenuItem.Click += new System.EventHandler(this.settingsToolStripMenuItem_Click);
            // 
            // fileToolStripSeparator
            // 
            this.fileToolStripSeparator.Name = "fileToolStripSeparator";
            this.fileToolStripSeparator.Size = new System.Drawing.Size(113, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(116, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click_1);
            // 
            // baseTableLayoutPanel
            // 
            this.baseTableLayoutPanel.ColumnCount = 1;
            this.baseTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.baseTableLayoutPanel.Controls.Add(this.listPreviousRecordings, 0, 1);
            this.baseTableLayoutPanel.Controls.Add(this.recordingTableLayoutPanel, 0, 0);
            this.baseTableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.baseTableLayoutPanel.Location = new System.Drawing.Point(0, 24);
            this.baseTableLayoutPanel.Name = "baseTableLayoutPanel";
            this.baseTableLayoutPanel.RowCount = 2;
            this.baseTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.baseTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.baseTableLayoutPanel.Size = new System.Drawing.Size(540, 492);
            this.baseTableLayoutPanel.TabIndex = 1;
            // 
            // listPreviousRecordings
            // 
            this.listPreviousRecordings.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnFileName,
            this.columnDuration,
            this.columnCreated});
            this.listPreviousRecordings.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listPreviousRecordings.Location = new System.Drawing.Point(3, 249);
            this.listPreviousRecordings.Name = "listPreviousRecordings";
            this.listPreviousRecordings.Size = new System.Drawing.Size(534, 240);
            this.listPreviousRecordings.TabIndex = 0;
            this.listPreviousRecordings.UseCompatibleStateImageBehavior = false;
            this.listPreviousRecordings.View = System.Windows.Forms.View.Details;
            this.listPreviousRecordings.SelectedIndexChanged += new System.EventHandler(this.listPreviousRecordings_SelectedIndexChanged);
            // 
            // columnFileName
            // 
            this.columnFileName.Text = "File Name";
            this.columnFileName.Width = 259;
            // 
            // columnDuration
            // 
            this.columnDuration.Text = "Duration";
            this.columnDuration.Width = 125;
            // 
            // columnCreated
            // 
            this.columnCreated.Text = "Created";
            this.columnCreated.Width = 146;
            // 
            // recordingTableLayoutPanel
            // 
            this.recordingTableLayoutPanel.ColumnCount = 1;
            this.recordingTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 48.39286F));
            this.recordingTableLayoutPanel.Controls.Add(this.waveformTableLayoutPanel, 0, 0);
            this.recordingTableLayoutPanel.Controls.Add(this.buttonPanel, 0, 1);
            this.recordingTableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.recordingTableLayoutPanel.Location = new System.Drawing.Point(0, 3);
            this.recordingTableLayoutPanel.Margin = new System.Windows.Forms.Padding(0, 3, 0, 3);
            this.recordingTableLayoutPanel.Name = "recordingTableLayoutPanel";
            this.recordingTableLayoutPanel.RowCount = 2;
            this.recordingTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.recordingTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 49F));
            this.recordingTableLayoutPanel.Size = new System.Drawing.Size(540, 240);
            this.recordingTableLayoutPanel.TabIndex = 1;
            // 
            // waveformTableLayoutPanel
            // 
            this.waveformTableLayoutPanel.ColumnCount = 1;
            this.waveformTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.waveformTableLayoutPanel.Controls.Add(this.leftChannelPictureBox, 0, 0);
            this.waveformTableLayoutPanel.Controls.Add(this.rightChannelPictureBox, 0, 1);
            this.waveformTableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.waveformTableLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.waveformTableLayoutPanel.Margin = new System.Windows.Forms.Padding(0);
            this.waveformTableLayoutPanel.Name = "waveformTableLayoutPanel";
            this.waveformTableLayoutPanel.RowCount = 2;
            this.waveformTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.waveformTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.waveformTableLayoutPanel.Size = new System.Drawing.Size(540, 191);
            this.waveformTableLayoutPanel.TabIndex = 0;
            // 
            // leftChannelPictureBox
            // 
            this.leftChannelPictureBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.leftChannelPictureBox.Location = new System.Drawing.Point(0, 0);
            this.leftChannelPictureBox.Margin = new System.Windows.Forms.Padding(0);
            this.leftChannelPictureBox.Name = "leftChannelPictureBox";
            this.leftChannelPictureBox.Size = new System.Drawing.Size(540, 95);
            this.leftChannelPictureBox.TabIndex = 0;
            this.leftChannelPictureBox.TabStop = false;
            // 
            // rightChannelPictureBox
            // 
            this.rightChannelPictureBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rightChannelPictureBox.Location = new System.Drawing.Point(0, 95);
            this.rightChannelPictureBox.Margin = new System.Windows.Forms.Padding(0);
            this.rightChannelPictureBox.Name = "rightChannelPictureBox";
            this.rightChannelPictureBox.Size = new System.Drawing.Size(540, 96);
            this.rightChannelPictureBox.TabIndex = 1;
            this.rightChannelPictureBox.TabStop = false;
            // 
            // buttonPanel
            // 
            this.buttonPanel.Controls.Add(this.pauseButton);
            this.buttonPanel.Controls.Add(this.stopButton);
            this.buttonPanel.Controls.Add(this.recordButton);
            this.buttonPanel.Location = new System.Drawing.Point(3, 194);
            this.buttonPanel.Name = "buttonPanel";
            this.buttonPanel.Size = new System.Drawing.Size(225, 43);
            this.buttonPanel.TabIndex = 1;
            // 
            // pauseButton
            // 
            this.pauseButton.Dock = System.Windows.Forms.DockStyle.Left;
            this.pauseButton.Location = new System.Drawing.Point(150, 0);
            this.pauseButton.Name = "pauseButton";
            this.pauseButton.Size = new System.Drawing.Size(75, 43);
            this.pauseButton.TabIndex = 2;
            this.pauseButton.Text = "Pause";
            this.pauseButton.UseVisualStyleBackColor = true;
            this.pauseButton.Click += new System.EventHandler(this.pauseButton_Click);
            // 
            // stopButton
            // 
            this.stopButton.Dock = System.Windows.Forms.DockStyle.Left;
            this.stopButton.Location = new System.Drawing.Point(75, 0);
            this.stopButton.Name = "stopButton";
            this.stopButton.Size = new System.Drawing.Size(75, 43);
            this.stopButton.TabIndex = 1;
            this.stopButton.Text = "Stop";
            this.stopButton.UseVisualStyleBackColor = true;
            this.stopButton.Click += new System.EventHandler(this.stopButton_Click);
            // 
            // recordButton
            // 
            this.recordButton.Dock = System.Windows.Forms.DockStyle.Left;
            this.recordButton.Location = new System.Drawing.Point(0, 0);
            this.recordButton.Name = "recordButton";
            this.recordButton.Size = new System.Drawing.Size(75, 43);
            this.recordButton.TabIndex = 0;
            this.recordButton.Text = "Record";
            this.recordButton.UseVisualStyleBackColor = true;
            this.recordButton.Click += new System.EventHandler(this.recordButton_Click);
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(540, 516);
            this.Controls.Add(this.baseTableLayoutPanel);
            this.Controls.Add(this.menuMain);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuMain;
            this.Name = "MainWindow";
            this.Text = "Sound Recorder";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainWindow_FormClosing);
            this.menuMain.ResumeLayout(false);
            this.menuMain.PerformLayout();
            this.baseTableLayoutPanel.ResumeLayout(false);
            this.recordingTableLayoutPanel.ResumeLayout(false);
            this.waveformTableLayoutPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.leftChannelPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rightChannelPictureBox)).EndInit();
            this.buttonPanel.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuMain;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator fileToolStripSeparator;
        private System.Windows.Forms.TableLayoutPanel baseTableLayoutPanel;
        private System.Windows.Forms.ListView listPreviousRecordings;
        private System.Windows.Forms.ColumnHeader columnFileName;
        private System.Windows.Forms.ColumnHeader columnDuration;
        private System.Windows.Forms.ColumnHeader columnCreated;
        private System.Windows.Forms.TableLayoutPanel recordingTableLayoutPanel;
        private System.Windows.Forms.TableLayoutPanel waveformTableLayoutPanel;
        private System.Windows.Forms.PictureBox leftChannelPictureBox;
        private System.Windows.Forms.PictureBox rightChannelPictureBox;
        private System.Windows.Forms.Panel buttonPanel;
        private System.Windows.Forms.Button pauseButton;
        private System.Windows.Forms.Button stopButton;
        private System.Windows.Forms.Button recordButton;
    }
}

