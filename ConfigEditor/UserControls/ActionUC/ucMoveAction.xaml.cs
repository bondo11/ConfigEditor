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
    /// Interaction logic for moveAction.xaml
    /// </summary>
    public partial class ucMoveAction : UserControl, Action
    {
        public RulesCollection.ActionKinds Kind { get; set; }
        public string Destination { get; set; }

        public ucMoveAction()
        {
            InitializeComponent();
            Kind = RulesCollection.ActionKinds.Move;
            Destination = "";
        }

        public ucMoveAction(string Destination)
            : this()
        {
            this.Destination = Destination;
            tbPath.Text = Destination;
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
            Writer.WriteValue("move");
            Writer.WriteEndElement();

            Writer.WriteStartElement("destination");
            Writer.WriteValue(Destination);
            Writer.WriteEndElement();
        }
        private void browseBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string result = Libraries.BrowseDialog.Folder();
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
    }
}
