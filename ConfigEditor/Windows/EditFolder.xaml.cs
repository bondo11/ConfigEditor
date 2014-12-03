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
        }


        public EditFolder(Folder f) : this()
        {
            // TODO: Complete member initialization
            this.f = f;
            tbFolder.Text = f.Path;
        }


        private void browseBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string result = Libraries.BrowseDialog.Folder();
                if (result != null)
                {

                    tbFolder.Text = result;
                }
            }
            catch (Exception)
            {
                throw;
            }
           
        }

        private void btnOK_Click(object sender, RoutedEventArgs e)
        {
            f.Path = tbFolder.Text;
            this.Close();
        }

        private void btn_MouseEnter(object sender, MouseEventArgs e)
        {
            ((Image)sender).Opacity = 1;
        }

        private void btn_MouseLeave(object sender, MouseEventArgs e)
        {
            ((Image)sender).Opacity = 0.45;
        }

    }
}
