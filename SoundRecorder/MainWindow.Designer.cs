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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWindow));
            this.menuMain = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.resetWindowSizeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
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
            this.buttonPanel = new System.Windows.Forms.Panel();
            this.pauseButton = new System.Windows.Forms.Button();
            this.stopButton = new System.Windows.Forms.Button();
            this.recordButton = new System.Windows.Forms.Button();
            this.visualizationPictureBox = new System.Windows.Forms.PictureBox();
            this.visualUpdateTimer = new System.Windows.Forms.Timer(this.components);
            this.menuMain.SuspendLayout();
            this.baseTableLayoutPanel.SuspendLayout();
            this.recordingTableLayoutPanel.SuspendLayout();
            this.buttonPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.visualizationPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // menuMain
            // 
            this.menuMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuMain.Location = new System.Drawing.Point(0, 0);
            this.menuMain.Name = "menuMain";
            this.menuMain.Size = new System.Drawing.Size(544, 24);
            this.menuMain.TabIndex = 0;
            this.menuMain.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.settingsToolStripMenuItem,
            this.resetWindowSizeToolStripMenuItem,
            this.fileToolStripSeparator,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            this.settingsToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
            this.settingsToolStripMenuItem.Text = "Settings";
            this.settingsToolStripMenuItem.Click += new System.EventHandler(this.settingsToolStripMenuItem_Click);
            // 
            // resetWindowSizeToolStripMenuItem
            // 
            this.resetWindowSizeToolStripMenuItem.Name = "resetWindowSizeToolStripMenuItem";
            this.resetWindowSizeToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
            this.resetWindowSizeToolStripMenuItem.Text = "Reset Window Size";
            this.resetWindowSizeToolStripMenuItem.Click += new System.EventHandler(this.resetWindowSizeToolStripMenuItem_Click);
            // 
            // fileToolStripSeparator
            // 
            this.fileToolStripSeparator.Name = "fileToolStripSeparator";
            this.fileToolStripSeparator.Size = new System.Drawing.Size(169, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
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
            this.baseTableLayoutPanel.Size = new System.Drawing.Size(544, 492);
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
            this.listPreviousRecordings.Size = new System.Drawing.Size(538, 240);
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
            this.recordingTableLayoutPanel.Controls.Add(this.buttonPanel, 0, 1);
            this.recordingTableLayoutPanel.Controls.Add(this.visualizationPictureBox, 0, 0);
            this.recordingTableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.recordingTableLayoutPanel.Location = new System.Drawing.Point(0, 3);
            this.recordingTableLayoutPanel.Margin = new System.Windows.Forms.Padding(0, 3, 0, 3);
            this.recordingTableLayoutPanel.Name = "recordingTableLayoutPanel";
            this.recordingTableLayoutPanel.RowCount = 2;
            this.recordingTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.recordingTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 49F));
            this.recordingTableLayoutPanel.Size = new System.Drawing.Size(544, 240);
            this.recordingTableLayoutPanel.TabIndex = 1;
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
            // visualizationPictureBox
            // 
            this.visualizationPictureBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.visualizationPictureBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.visualizationPictureBox.Location = new System.Drawing.Point(0, 0);
            this.visualizationPictureBox.Margin = new System.Windows.Forms.Padding(0);
            this.visualizationPictureBox.Name = "visualizationPictureBox";
            this.visualizationPictureBox.Size = new System.Drawing.Size(544, 191);
            this.visualizationPictureBox.TabIndex = 2;
            this.visualizationPictureBox.TabStop = false;
            // 
            // visualUpdateTimer
            // 
            this.visualUpdateTimer.Enabled = true;
            this.visualUpdateTimer.Interval = 40;
            this.visualUpdateTimer.Tick += new System.EventHandler(this.visualUpdateTimer_Tick);
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(544, 516);
            this.Controls.Add(this.baseTableLayoutPanel);
            this.Controls.Add(this.menuMain);
            this.Icon = Properties.Resources.SoundRecorderIcon;
            this.MainMenuStrip = this.menuMain;
            this.MinimumSize = new System.Drawing.Size(380, 380);
            this.Name = "MainWindow";
            this.Text = "Sound Recorder";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainWindow_FormClosing);
            this.menuMain.ResumeLayout(false);
            this.menuMain.PerformLayout();
            this.baseTableLayoutPanel.ResumeLayout(false);
            this.recordingTableLayoutPanel.ResumeLayout(false);
            this.buttonPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.visualizationPictureBox)).EndInit();
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
        private System.Windows.Forms.Panel buttonPanel;
        private System.Windows.Forms.Button pauseButton;
        private System.Windows.Forms.Button stopButton;
        private System.Windows.Forms.Button recordButton;
        private PictureBox visualizationPictureBox;
        private Timer visualUpdateTimer;
        private ToolStripMenuItem resetWindowSizeToolStripMenuItem;
    }
}

