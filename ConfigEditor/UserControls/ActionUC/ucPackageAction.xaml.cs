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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ConfigEditor
{
    /// <summary>
    /// Interaction logic for copyAction.xaml
    /// </summary>
    public partial class ucPackageAction : UserControl, Action
    {
        public RulesCollection.ActionKinds Kind { get; set; }
        public string Destination { get; set; }
        public int compression { get; set; }

        public ucPackageAction()
        {
            InitializeComponent();
            Kind = RulesCollection.ActionKinds.Copy;
            Destination = "";
        }
        public ucPackageAction(string Destination)
            : this()
        {
            this.Destination = Destination;
            tbPath.Text = Destination;
            cbCompression_Click();
        }

        public UserControl GetUC()
        {
            return this;
        }
        public void Save(ActionSet ActionSet)
        {
            Destination = tbPath.Text;
            ActionSet.Add(this);
        }
        public void WriteToConfig(System.Xml.XmlWriter Writer)
        {
            Writer.WriteStartElement("kind");
            Writer.WriteValue("package");
            Writer.WriteEndElement();

            Writer.WriteStartElement("destination");
            Writer.WriteValue(Destination);
            Writer.WriteEndElement();

            Writer.WriteStartElement("compression");
            Writer.WriteValue((bool)cbCompression.IsChecked ? "" : compression.ToString());
            Writer.WriteEndElement();
        }
        private void browseBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string result = Libraries.BrowseDialog.File("Zip file", "*.zip", "Browse zip file");
                if (result != null)
                {

                    tbPath.Text = result;
                }
            }
            catch (Exception)
            {
                throw;
            }

        }
        private void btn_MouseEnter(object sender, RoutedEventArgs e)
        {
            ((Image)sender).Opacity = 1;
        }
        private void btn_MouseLeave(object sender, RoutedEventArgs e)
        {
            ((Image)sender).Opacity = 0.45;
        }

        private void SliderValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            this.compression = (int)sliderCompression.Value;
            lblCompression.Content = ((int)sliderCompression.Value).ToString();
        }


        private void cbCompression_Click()
        {
            if ((bool)cbCompression.IsChecked)
            {
                sliderCompression.IsEnabled = false;
                sliderCompression.Opacity = 0.25;
            }
            else
            {
                sliderCompression.IsEnabled = true;
                sliderCompression.Opacity = 1;
            }

        }

        private void cbCompression_Click(object sender, RoutedEventArgs e)
        {
            cbCompression_Click();
        }
    }
}
