using System.Windows.Forms;
using Microsoft.WindowsAPICodePack.Shell;

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
            this.menuMain = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.refreshRecentFilesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.resetWindowSizeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fileToolStripSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.visualUpdateTimer = new System.Windows.Forms.Timer(this.components);
            this.recordingTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.visualizationPictureBox = new System.Windows.Forms.PictureBox();
            this.buttonsLevelsLayout = new System.Windows.Forms.TableLayoutPanel();
            this.buttonPanel = new System.Windows.Forms.Panel();
            this.pauseButton = new System.Windows.Forms.Button();
            this.stopButton = new System.Windows.Forms.Button();
            this.recordButton = new System.Windows.Forms.Button();
            this.levelsVisualizationPictureBox = new System.Windows.Forms.PictureBox();
            this.baseTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.previousRecordingsContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.renameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openFolderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.previousRecordingsRefreshMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.refreshToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.levelsUpdateTimer = new System.Windows.Forms.Timer(this.components);
            this.buttonAnimationTimer = new System.Windows.Forms.Timer(this.components);
            this.previousRecordings = new SoundRecorder.PreviousRecordings();
            this.menuMain.SuspendLayout();
            this.recordingTableLayoutPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.visualizationPictureBox)).BeginInit();
            this.buttonsLevelsLayout.SuspendLayout();
            this.buttonPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.levelsVisualizationPictureBox)).BeginInit();
            this.baseTableLayoutPanel.SuspendLayout();
            this.previousRecordingsContextMenu.SuspendLayout();
            this.previousRecordingsRefreshMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuMain
            // 
            this.menuMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuMain.Location = new System.Drawing.Point(0, 0);
            this.menuMain.Name = "menuMain";
            this.menuMain.Size = new System.Drawing.Size(527, 24);
            this.menuMain.TabIndex = 0;
            this.menuMain.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.settingsToolStripMenuItem,
            this.toolStripSeparator1,
            this.refreshRecentFilesToolStripMenuItem,
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
            this.settingsToolStripMenuItem.Size = new System.Drawing.Size(178, 22);
            this.settingsToolStripMenuItem.Text = "Settings";
            this.settingsToolStripMenuItem.Click += new System.EventHandler(this.settingsToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(175, 6);
            // 
            // refreshRecentFilesToolStripMenuItem
            // 
            this.refreshRecentFilesToolStripMenuItem.Name = "refreshRecentFilesToolStripMenuItem";
            this.refreshRecentFilesToolStripMenuItem.Size = new System.Drawing.Size(178, 22);
            this.refreshRecentFilesToolStripMenuItem.Text = "Refresh Recent Files";
            this.refreshRecentFilesToolStripMenuItem.Click += new System.EventHandler(this.refreshRecentFilesToolStripMenuItem_Click);
            // 
            // resetWindowSizeToolStripMenuItem
            // 
            this.resetWindowSizeToolStripMenuItem.Name = "resetWindowSizeToolStripMenuItem";
            this.resetWindowSizeToolStripMenuItem.Size = new System.Drawing.Size(178, 22);
            this.resetWindowSizeToolStripMenuItem.Text = "Reset Window Size";
            this.resetWindowSizeToolStripMenuItem.Click += new System.EventHandler(this.resetWindowSizeToolStripMenuItem_Click);
            // 
            // fileToolStripSeparator
            // 
            this.fileToolStripSeparator.Name = "fileToolStripSeparator";
            this.fileToolStripSeparator.Size = new System.Drawing.Size(175, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(178, 22);
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
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // visualUpdateTimer
            // 
            this.visualUpdateTimer.Enabled = true;
            this.visualUpdateTimer.Interval = 40;
            this.visualUpdateTimer.Tick += new System.EventHandler(this.visualUpdateTimer_Tick);
            // 
            // recordingTableLayoutPanel
            // 
            this.recordingTableLayoutPanel.ColumnCount = 1;
            this.recordingTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 48.39286F));
            this.recordingTableLayoutPanel.Controls.Add(this.visualizationPictureBox, 0, 0);
            this.recordingTableLayoutPanel.Controls.Add(this.buttonsLevelsLayout, 0, 1);
            this.recordingTableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.recordingTableLayoutPanel.Location = new System.Drawing.Point(0, 3);
            this.recordingTableLayoutPanel.Margin = new System.Windows.Forms.Padding(0, 3, 0, 0);
            this.recordingTableLayoutPanel.Name = "recordingTableLayoutPanel";
            this.recordingTableLayoutPanel.RowCount = 2;
            this.recordingTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.recordingTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 49F));
            this.recordingTableLayoutPanel.Size = new System.Drawing.Size(527, 243);
            this.recordingTableLayoutPanel.TabIndex = 1;
            // 
            // visualizationPictureBox
            // 
            this.visualizationPictureBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.visualizationPictureBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.visualizationPictureBox.Location = new System.Drawing.Point(0, 0);
            this.visualizationPictureBox.Margin = new System.Windows.Forms.Padding(0);
            this.visualizationPictureBox.Name = "visualizationPictureBox";
            this.visualizationPictureBox.Size = new System.Drawing.Size(527, 194);
            this.visualizationPictureBox.TabIndex = 2;
            this.visualizationPictureBox.TabStop = false;
            // 
            // buttonsLevelsLayout
            // 
            this.buttonsLevelsLayout.ColumnCount = 2;
            this.buttonsLevelsLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 226F));
            this.buttonsLevelsLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.buttonsLevelsLayout.Controls.Add(this.buttonPanel, 0, 0);
            this.buttonsLevelsLayout.Controls.Add(this.levelsVisualizationPictureBox, 1, 0);
            this.buttonsLevelsLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonsLevelsLayout.Location = new System.Drawing.Point(2, 197);
            this.buttonsLevelsLayout.Margin = new System.Windows.Forms.Padding(2, 3, 3, 0);
            this.buttonsLevelsLayout.Name = "buttonsLevelsLayout";
            this.buttonsLevelsLayout.RowCount = 1;
            this.buttonsLevelsLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.buttonsLevelsLayout.Size = new System.Drawing.Size(522, 46);
            this.buttonsLevelsLayout.TabIndex = 3;
            // 
            // buttonPanel
            // 
            this.buttonPanel.Controls.Add(this.pauseButton);
            this.buttonPanel.Controls.Add(this.stopButton);
            this.buttonPanel.Controls.Add(this.recordButton);
            this.buttonPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonPanel.Location = new System.Drawing.Point(0, 0);
            this.buttonPanel.Margin = new System.Windows.Forms.Padding(0);
            this.buttonPanel.Name = "buttonPanel";
            this.buttonPanel.Size = new System.Drawing.Size(226, 46);
            this.buttonPanel.TabIndex = 2;
            // 
            // pauseButton
            // 
            this.pauseButton.Dock = System.Windows.Forms.DockStyle.Left;
            this.pauseButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pauseButton.Image = global::SoundRecorder.Properties.Resources.pause_button_24;
            this.pauseButton.Location = new System.Drawing.Point(150, 0);
            this.pauseButton.Name = "pauseButton";
            this.pauseButton.Size = new System.Drawing.Size(75, 46);
            this.pauseButton.TabIndex = 2;
            this.pauseButton.UseVisualStyleBackColor = true;
            this.pauseButton.Click += new System.EventHandler(this.pauseButton_Click);
            // 
            // stopButton
            // 
            this.stopButton.Dock = System.Windows.Forms.DockStyle.Left;
            this.stopButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.stopButton.Image = global::SoundRecorder.Properties.Resources.stop_button_24;
            this.stopButton.Location = new System.Drawing.Point(75, 0);
            this.stopButton.Name = "stopButton";
            this.stopButton.Size = new System.Drawing.Size(75, 46);
            this.stopButton.TabIndex = 1;
            this.stopButton.UseVisualStyleBackColor = true;
            this.stopButton.Click += new System.EventHandler(this.stopButton_Click);
            // 
            // recordButton
            // 
            this.recordButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.recordButton.Dock = System.Windows.Forms.DockStyle.Left;
            this.recordButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.recordButton.ForeColor = System.Drawing.Color.Brown;
            this.recordButton.Image = global::SoundRecorder.Properties.Resources.record_button_24;
            this.recordButton.Location = new System.Drawing.Point(0, 0);
            this.recordButton.Name = "recordButton";
            this.recordButton.Size = new System.Drawing.Size(75, 46);
            this.recordButton.TabIndex = 0;
            this.recordButton.UseVisualStyleBackColor = true;
            this.recordButton.Click += new System.EventHandler(this.recordButton_Click);
            // 
            // levelsVisualizationPictureBox
            // 
            this.levelsVisualizationPictureBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.levelsVisualizationPictureBox.Location = new System.Drawing.Point(226, 0);
            this.levelsVisualizationPictureBox.Margin = new System.Windows.Forms.Padding(0);
            this.levelsVisualizationPictureBox.MaximumSize = new System.Drawing.Size(350, 0);
            this.levelsVisualizationPictureBox.Name = "levelsVisualizationPictureBox";
            this.levelsVisualizationPictureBox.Padding = new System.Windows.Forms.Padding(0, 1, 0, 0);
            this.levelsVisualizationPictureBox.Size = new System.Drawing.Size(296, 46);
            this.levelsVisualizationPictureBox.TabIndex = 3;
            this.levelsVisualizationPictureBox.TabStop = false;
            // 
            // baseTableLayoutPanel
            // 
            this.baseTableLayoutPanel.ColumnCount = 1;
            this.baseTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.baseTableLayoutPanel.Controls.Add(this.recordingTableLayoutPanel, 0, 0);
            this.baseTableLayoutPanel.Controls.Add(this.previousRecordings, 0, 1);
            this.baseTableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.baseTableLayoutPanel.Location = new System.Drawing.Point(0, 24);
            this.baseTableLayoutPanel.MinimumSize = new System.Drawing.Size(0, 50);
            this.baseTableLayoutPanel.Name = "baseTableLayoutPanel";
            this.baseTableLayoutPanel.RowCount = 2;
            this.baseTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.baseTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.baseTableLayoutPanel.Size = new System.Drawing.Size(527, 501);
            this.baseTableLayoutPanel.TabIndex = 1;
            // 
            // previousRecordingsContextMenu
            // 
            this.previousRecordingsContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.renameToolStripMenuItem,
            this.openFolderToolStripMenuItem});
            this.previousRecordingsContextMenu.Name = "previousRecordingsContextMenu";
            this.previousRecordingsContextMenu.Size = new System.Drawing.Size(140, 70);
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(139, 22);
            this.openToolStripMenuItem.Text = "Open";
            // 
            // renameToolStripMenuItem
            // 
            this.renameToolStripMenuItem.Name = "renameToolStripMenuItem";
            this.renameToolStripMenuItem.Size = new System.Drawing.Size(139, 22);
            this.renameToolStripMenuItem.Text = "Rename";
            // 
            // openFolderToolStripMenuItem
            // 
            this.openFolderToolStripMenuItem.Name = "openFolderToolStripMenuItem";
            this.openFolderToolStripMenuItem.Size = new System.Drawing.Size(139, 22);
            this.openFolderToolStripMenuItem.Text = "Open Folder";
            // 
            // previousRecordingsRefreshMenu
            // 
            this.previousRecordingsRefreshMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.refreshToolStripMenuItem});
            this.previousRecordingsRefreshMenu.Name = "previousRecordingsRefreshMenu";
            this.previousRecordingsRefreshMenu.Size = new System.Drawing.Size(114, 26);
            // 
            // refreshToolStripMenuItem
            // 
            this.refreshToolStripMenuItem.Name = "refreshToolStripMenuItem";
            this.refreshToolStripMenuItem.Size = new System.Drawing.Size(113, 22);
            this.refreshToolStripMenuItem.Text = "Refresh";
            this.refreshToolStripMenuItem.Click += new System.EventHandler(this.refreshToolStripMenuItem_Click);
            // 
            // levelsUpdateTimer
            // 
            this.levelsUpdateTimer.Enabled = true;
            this.levelsUpdateTimer.Interval = 40;
            this.levelsUpdateTimer.Tick += new System.EventHandler(this.levelsUpdateTimer_Tick);
            // 
            // buttonAnimationTimer
            // 
            this.buttonAnimationTimer.Interval = 600;
            this.buttonAnimationTimer.Tick += new System.EventHandler(this.buttonAnimationTimer_Tick);
            // 
            // previousRecordings
            // 
            this.previousRecordings.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.previousRecordings.Dock = System.Windows.Forms.DockStyle.Fill;
            this.previousRecordings.Location = new System.Drawing.Point(3, 249);
            this.previousRecordings.MinimumSize = new System.Drawing.Size(0, 50);
            this.previousRecordings.Name = "previousRecordings";
            this.previousRecordings.Size = new System.Drawing.Size(521, 249);
            this.previousRecordings.TabIndex = 2;
            this.previousRecordings.writeDir = null;
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(527, 525);
            this.Controls.Add(this.baseTableLayoutPanel);
            this.Controls.Add(this.menuMain);
            this.Icon = global::SoundRecorder.Properties.Resources.icon;
            this.MainMenuStrip = this.menuMain;
            this.MinimumSize = new System.Drawing.Size(380, 380);
            this.Name = "MainWindow";
            this.Text = "Sound Recorder";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainWindow_FormClosing);
            this.menuMain.ResumeLayout(false);
            this.menuMain.PerformLayout();
            this.recordingTableLayoutPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.visualizationPictureBox)).EndInit();
            this.buttonsLevelsLayout.ResumeLayout(false);
            this.buttonPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.levelsVisualizationPictureBox)).EndInit();
            this.baseTableLayoutPanel.ResumeLayout(false);
            this.previousRecordingsContextMenu.ResumeLayout(false);
            this.previousRecordingsRefreshMenu.ResumeLayout(false);
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
        private Timer visualUpdateTimer;
        private ToolStripMenuItem resetWindowSizeToolStripMenuItem;
        private TableLayoutPanel recordingTableLayoutPanel;
        private PictureBox visualizationPictureBox;
        private TableLayoutPanel baseTableLayoutPanel;
        private ContextMenuStrip previousRecordingsContextMenu;
        private ToolStripMenuItem renameToolStripMenuItem;
        private ToolStripMenuItem openToolStripMenuItem;
        private ContextMenuStrip contextMenuStrip1;
        private ToolStripMenuItem openFolderToolStripMenuItem;
        private ContextMenuStrip previousRecordingsRefreshMenu;
        private ToolStripMenuItem refreshToolStripMenuItem;
        private TableLayoutPanel buttonsLevelsLayout;
        private Panel buttonPanel;
        private Button pauseButton;
        private Button stopButton;
        private Button recordButton;
        private PictureBox levelsVisualizationPictureBox;
        private Timer levelsUpdateTimer;
        private ToolStripMenuItem refreshRecentFilesToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator1;
        private Timer buttonAnimationTimer;
        private PreviousRecordings previousRecordings;
    }
}

