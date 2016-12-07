using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Microsoft.WindowsAPICodePack.Shell;
using Microsoft.WindowsAPICodePack.Shell.PropertySystem;


namespace SoundRecorder
{
    public partial class PreviousRecordings : UserControl
    {
        public string writeDir { get; set; }
        private int _sortColumn = -1;
        private string _focusedPreviousRecording;

        public PreviousRecordings()
        {
            InitializeComponent();
        }

        public void DisplayRecentFiles()
        {
            this.listPreviousRecordings.Items.Clear();

            var extensions = new List<string> { ".mp3", ".wav", ".flac", ".aac", ".ac3", ".wma" };
            // TODO: Load formats from AvailableCodecs Enum?
            var files = Directory.GetFiles(writeDir, "*.*", SearchOption.AllDirectories)
                .Where(s => extensions.Any(e => s.ToLower().EndsWith(e)));

            foreach (var file in files)
            {
                try
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
                catch (Exception e)
                {
                    MessageBox.Show("Could not load file: " + e, "File Load Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void listPreviousRecordings_beforeLabelEdit(object sender, LabelEditEventArgs e)
        {
            // Using focusedItem to set the string as the e.Label is empty.
            this._focusedPreviousRecording = this.listPreviousRecordings.FocusedItem.Text;
        }

        private void listPreviousRecordings_afterLabelEdit(object sender, LabelEditEventArgs e)
        {
            if (e.Label != null && this._focusedPreviousRecording != e.Label)
            {
                // Check to make sure the new filename has an extension
                var fileExtension = e.Label.Split(new string[] { "." }, StringSplitOptions.RemoveEmptyEntries);

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
                if (Enum.IsDefined(typeof(AvailableCodecs), fileExtension[fileExtension.Length - 1].ToUpper()))
                {
                    try
                    {
                        File.Move(Path.Combine(this.writeDir, this._focusedPreviousRecording),
                            Path.Combine(this.writeDir, e.Label));
                    }
                    catch (IOException)
                    {
                        MessageBox.Show("Maybe a file with that name already exists?",
                            "Sound Recorder: Rename Error",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                        e.CancelEdit = true;
                        return;
                    }
                    catch (NotSupportedException)
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

        private void listPreviousRecordings_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Process.Start("explorer.exe", Path.Combine(this.writeDir, this.listPreviousRecordings.SelectedItems[0].Text));
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
            Process.Start("explorer.exe", Path.Combine(this.writeDir, this.listPreviousRecordings.FocusedItem.Text));
        }

        private void renameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            listPreviousRecordings.FocusedItem.BeginEdit();
        }

        private void openFolderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start("explorer.exe", this.writeDir);
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

        private void refreshToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DisplayRecentFiles();
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
                DateTime firstDate = DateTime.Parse(((ListViewItem)x).SubItems[col].Text);
                DateTime secondDate = DateTime.Parse(((ListViewItem)y).SubItems[col].Text);
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
