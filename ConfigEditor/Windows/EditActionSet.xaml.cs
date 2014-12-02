﻿using System;
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
    /// Interaction logic for EditActionSet.xaml
    /// </summary>
    public partial class EditActionSet : Window
    {
        //private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private ActionSet a;

        public EditActionSet()
        {
            InitializeComponent();
        }


        public EditActionSet(ActionSet a)
            : this()
        {
            // TODO: Complete member initialization
            this.a = a;
            tbActionName.Text = a.Name;
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
                    tbFolder.Text = FolderName;
                }
                else { tbFolder.Text = "not valid"; }
            }
            catch (Exception)
            {
                throw;
            }
           
        }
        */
        private void btnOK_Click(object sender, RoutedEventArgs e)
        {
            a.Name = tbActionName.Text;
            this.Close();
        }
    }
}
