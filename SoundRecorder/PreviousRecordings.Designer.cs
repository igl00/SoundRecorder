namespace SoundRecorder
{
    partial class PreviousRecordings
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
            this.listPreviousRecordings = new System.Windows.Forms.ListView();
            this.columnFileName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnDuration = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnCreated = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.previousRecordingsContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.renameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openFolderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.previousRecordingsRefreshMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.refreshToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.previousRecordingsContextMenu.SuspendLayout();
            this.previousRecordingsRefreshMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // listPreviousRecordings
            // 
            this.listPreviousRecordings.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnFileName,
            this.columnDuration,
            this.columnCreated});
            this.listPreviousRecordings.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listPreviousRecordings.LabelEdit = true;
            this.listPreviousRecordings.Location = new System.Drawing.Point(0, 0);
            this.listPreviousRecordings.Name = "listPreviousRecordings";
            this.listPreviousRecordings.Size = new System.Drawing.Size(0, 50);
            this.listPreviousRecordings.TabIndex = 1;
            this.listPreviousRecordings.UseCompatibleStateImageBehavior = false;
            this.listPreviousRecordings.View = System.Windows.Forms.View.Details;
            this.listPreviousRecordings.AfterLabelEdit += new System.Windows.Forms.LabelEditEventHandler(this.listPreviousRecordings_afterLabelEdit);
            this.listPreviousRecordings.BeforeLabelEdit += new System.Windows.Forms.LabelEditEventHandler(this.listPreviousRecordings_beforeLabelEdit);
            this.listPreviousRecordings.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.listPreviousRecordings_ColumnClick);
            this.listPreviousRecordings.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.listPreviousRecordings_MouseDoubleClick);
            this.listPreviousRecordings.MouseDown += new System.Windows.Forms.MouseEventHandler(this.listPreviousRecordings_MouseDown);
            // 
            // columnFileName
            // 
            this.columnFileName.Text = "File Name";
            this.columnFileName.Width = 259;
            // 
            // columnDuration
            // 
            this.columnDuration.Text = "Duration";
            this.columnDuration.Width = 120;
            // 
            // columnCreated
            // 
            this.columnCreated.Text = "Created";
            this.columnCreated.Width = 135;
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
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // renameToolStripMenuItem
            // 
            this.renameToolStripMenuItem.Name = "renameToolStripMenuItem";
            this.renameToolStripMenuItem.Size = new System.Drawing.Size(139, 22);
            this.renameToolStripMenuItem.Text = "Rename";
            this.renameToolStripMenuItem.Click += new System.EventHandler(this.renameToolStripMenuItem_Click);
            // 
            // openFolderToolStripMenuItem
            // 
            this.openFolderToolStripMenuItem.Name = "openFolderToolStripMenuItem";
            this.openFolderToolStripMenuItem.Size = new System.Drawing.Size(139, 22);
            this.openFolderToolStripMenuItem.Text = "Open Folder";
            this.openFolderToolStripMenuItem.Click += new System.EventHandler(this.openFolderToolStripMenuItem_Click);
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
            // PreviousRecordings
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Controls.Add(this.listPreviousRecordings);
            this.MinimumSize = new System.Drawing.Size(0, 50);
            this.Name = "PreviousRecordings";
            this.Size = new System.Drawing.Size(0, 50);
            this.previousRecordingsContextMenu.ResumeLayout(false);
            this.previousRecordingsRefreshMenu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView listPreviousRecordings;
        private System.Windows.Forms.ColumnHeader columnFileName;
        private System.Windows.Forms.ColumnHeader columnDuration;
        private System.Windows.Forms.ColumnHeader columnCreated;
        private System.Windows.Forms.ContextMenuStrip previousRecordingsContextMenu;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem renameToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openFolderToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip previousRecordingsRefreshMenu;
        private System.Windows.Forms.ToolStripMenuItem refreshToolStripMenuItem;
    }
}