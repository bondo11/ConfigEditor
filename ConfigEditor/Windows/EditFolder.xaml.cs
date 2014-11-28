using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace ConfigEditor.Windows
{
    /// <summary>
    /// Interaction logic for EditFolder.xaml
    /// </summary>
    public partial class EditFolder : Window
    {
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private Folder f;

        public EditFolder()
        {
            InitializeComponent();
            tbFolder.Text = f.Path;
        }


        public EditFolder(Folder f)
            : this()
        {
            // TODO: Complete member initialization
            this.f = f;
        }


        private void browseBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
                if (folderBrowserDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    string Path = folderBrowserDialog1.SelectedPath;
                    string FolderName = System.IO.Path.GetFullPath(Path);
                    tbFolder.Text = FolderName;
                }
                else { tbFolder.Text = "not valid"; }
            }
            catch (Exception)
            {
                throw;
            }
           
        }

        private void btnOK_Click(object sender, RoutedEventArgs e)
        {
            f.Path = tbFolder.Text;
        }
    }
}
