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
    public partial class EditMatchSet : Window
    {
        //private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private MatchSet ms;

        public EditMatchSet()
        {
            InitializeComponent();
        }


        public EditMatchSet(MatchSet ms)
            : this()
        {
            this.ms = ms;
            tbMatchset.Text = ms.Name;
        }

        /*
        private void browseBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
                if (folderBrowserDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    string Path = folderBrowserDialog1.SelectedPath;
                    string FolderName = System.IO.Path.GetFullPath(Path);
                    tbMatchset.Text = FolderName;
                }
                else { tbMatchset.Text = "not valid"; }
            }
            catch (Exception)
            {
                throw;
            }
           
        }
        */
        private void btnOK_Click(object sender, RoutedEventArgs e)
        {
            ms.Name= tbMatchset.Text;
            this.Close();
        }
    }
}
