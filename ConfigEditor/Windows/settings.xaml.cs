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
using System.Windows.Forms;
using System.Configuration;
using System.IO;
using System.Security.Principal;
using System.Security.AccessControl;


namespace ConfigEditor
{
    /// <summary>
    /// Interaction logic for settings.xaml
    /// </summary>
    public partial class settings : Window
    {
        public settings()
        {
            InitializeComponent();
        }
        private void btnSave_Click(object sender, RoutedEventArgs e)
        {

            if (File.Exists(tbPath.Text))
            {
                if (cbCreds.IsChecked.Value)
                {
                    ConfigSettings.setUser(tbUsername.Text);
                    ConfigSettings.setPassword(pbPassword.Password);
                }
                if (HasWritePermission(tbPath.Text))
                {
                    ConfigSettings.setSource(tbPath.Text);
                    
                }
                else
                {
                    MessageBoxResult result = System.Windows.MessageBox.Show("No permission to file!" + Environment.NewLine + "Insert crednetials?", "Config Error", MessageBoxButton.YesNo, MessageBoxImage.Information);
                    if (result == MessageBoxResult.Yes)
                    {
                        ConfigurationManager.AppSettings["source"] = tbPath.Text;
                        //ConfigurationManager.AppSettings["port"] = tbPort.Text;
                        //ConfigurationManager.AppSettings["user"] = tbUser.Text;
                        //ConfigurationManager.AppSettings["password"] = pwdPassword.Password;
                        configHandler.getConfig();
                        this.Close();
                    }
                }
                //ConfigurationManager.AppSettings["port"] = tbPort.Text;
                //ConfigurationManager.AppSettings["user"] = tbUser.Text;
                //ConfigurationManager.AppSettings["password"] = pwdPassword.Password;
                configHandler.getConfig();
                this.Close();
            }
            else
            {
                MessageBoxResult result = System.Windows.MessageBox.Show("Could not load config!" + Environment.NewLine + "Sure you want to continue?", "Config Error", MessageBoxButton.YesNo, MessageBoxImage.Information);
                if (result == MessageBoxResult.Yes)
                {
                    ConfigurationManager.AppSettings["source"] = tbPath.Text;
                    //ConfigurationManager.AppSettings["port"] = tbPort.Text;
                    //ConfigurationManager.AppSettings["user"] = tbUser.Text;
                    //ConfigurationManager.AppSettings["password"] = pwdPassword.Password;
                    this.Close();
                }
                else
                {
                    LinearGradientBrush myBrush = new LinearGradientBrush();
                    myBrush.GradientStops.Add(new GradientStop(Colors.Yellow, 0.0));
                    myBrush.GradientStops.Add(new GradientStop(Colors.Orange, 0.5));
                    myBrush.GradientStops.Add(new GradientStop(Colors.Red, 1.0));
                    tbPath.Background = myBrush;
                }
            }
        }
        private void tbPath_Initialized(object sender, EventArgs e)
        {
            tbPath.Text = ConfigSettings.getSource();
        }
        private static bool HasWritePermission(string FilePath)
        {
            try
            {
                FileSystemSecurity security;
                if (File.Exists(FilePath))
                {
                    security = File.GetAccessControl(FilePath);
                }
                else
                {
                    security = Directory.GetAccessControl(System.IO.Path.GetDirectoryName(FilePath));
                }
                var rules = security.GetAccessRules(true, true, typeof(NTAccount));

                var currentuser = new WindowsPrincipal(WindowsIdentity.GetCurrent());
                bool result = false;
                foreach (FileSystemAccessRule rule in rules)
                {
                    if (0 == (rule.FileSystemRights &
                        (FileSystemRights.WriteData | FileSystemRights.Write)))
                    {
                        continue;
                    }

                    if (rule.IdentityReference.Value.StartsWith("S-1-"))
                    {
                        var sid = new SecurityIdentifier(rule.IdentityReference.Value);
                        if (!currentuser.IsInRole(sid))
                        {
                            continue;
                        }
                    }
                    else
                    {
                        if (!currentuser.IsInRole(rule.IdentityReference.Value))
                        {
                            continue;
                        }
                    }

                    if (rule.AccessControlType == AccessControlType.Deny)
                        return false;
                    if (rule.AccessControlType == AccessControlType.Allow)
                        result = true;
                }
                return result;
            }
            catch
            {
                return false;
            }

        }

        private void browseBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                System.Windows.Forms.OpenFileDialog ofd = new System.Windows.Forms.OpenFileDialog();
                ofd.Filter = "Config Files|config.xml";
                ofd.Title = "Open Config Dialog";
                ofd.RestoreDirectory = true;
                if (ofd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    string Path = ofd.FileName;
                    string FolderName = System.IO.Path.GetFullPath(Path);
                    tbPath.Text = FolderName;
                }
                else { tbPath.Text = "No permission"; }
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void cbCreds_Checked(object sender, RoutedEventArgs e)
        {
            spCreds.Visibility = Visibility.Visible;
        }

        private void cbCreds_Unchecked(object sender, RoutedEventArgs e)
        {
            spCreds.Visibility = Visibility.Hidden;
        }

        private void btnSave_MouseDown(object sender, MouseButtonEventArgs e)
        {
            btnSave_Click(sender, e);
        }

        private void btnSave_MouseEnter(object sender, System.Windows.Input.MouseEventArgs e)
        {
            btnSave.Opacity = 1;
        }

        private void btnSave_MouseLeave(object sender, System.Windows.Input.MouseEventArgs e)
        {
            btnSave.Opacity = 0.45;
        }

        private void browseImg_MouseDown(object sender, MouseButtonEventArgs e)
        {
            browseBtn_Click(sender, e);
        }

        private void browseImg_MouseEnter(object sender, System.Windows.Input.MouseEventArgs e)
        {

            browseImg.Opacity = 1;
        }

        private void browseImg_MouseLeave(object sender, System.Windows.Input.MouseEventArgs e)
        {

            browseImg.Opacity = 0.45;
        }


    }
}
