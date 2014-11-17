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
                ConfigurationManager.AppSettings["source"] = tbPath.Text;
                ConfigurationManager.AppSettings["port"] = tbPort.Text;
                ConfigurationManager.AppSettings["user"] = tbUser.Text;
                ConfigurationManager.AppSettings["password"] = pwdPassword.Password;
                this.Close();
            }
            else
            {
                MessageBoxResult result = System.Windows.MessageBox.Show("Could not load config!" + Environment.NewLine + "Sure you want to continue?", "Config Error", MessageBoxButton.YesNo, MessageBoxImage.Error);
                if (result == MessageBoxResult.Yes)
                {
                    ConfigurationManager.AppSettings["source"] = tbPath.Text;
                    ConfigurationManager.AppSettings["port"] = tbPort.Text;
                    ConfigurationManager.AppSettings["user"] = tbUser.Text;
                    ConfigurationManager.AppSettings["password"] = pwdPassword.Password;
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

        private void tbUser_Initialized(object sender, EventArgs e)
        {
            tbUser.Text = ConfigSettings.getUser();
        }

        private void tbPort_Initialized(object sender, EventArgs e)
        {
            tbPort.Text = ConfigSettings.getPort().ToString();
        }
        

    }
}
