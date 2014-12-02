using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ConfigEditor.Libraries
{
    public static class BrowseDialog
    {

        private static FolderBrowserDialog folderBrowserDialog;

        private static OpenFileDialog openFileDialog;

        public static string File(string filterName, string filter, string title)
        {
            openFileDialog = new OpenFileDialog();

            openFileDialog.Filter = filterName + "|" + filter;
            openFileDialog.Title = title;
            openFileDialog.RestoreDirectory = true;
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                return Path.GetFullPath(openFileDialog.FileName);
            }
            return null;
        }
        public static string Folder()
        {
            folderBrowserDialog = new FolderBrowserDialog();
            if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                return Path.GetFullPath(folderBrowserDialog.SelectedPath);
            }
            return null;
        }
    }
}
