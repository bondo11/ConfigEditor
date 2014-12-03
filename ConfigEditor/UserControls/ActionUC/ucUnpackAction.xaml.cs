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
    /// Interaction logic for ucDeleteAction.xaml
    /// </summary>
    public partial class ucUnpackAction : UserControl, Action
    {

        public RulesCollection.ActionKinds Kind { get; set; }

        public ucUnpackAction()
        {
            InitializeComponent();
            Kind = RulesCollection.ActionKinds.Unpack;
        }
        public ucUnpackAction(Action act)
            : this()
        {
            // TODO: Complete member initialization
            //tbPath.Text= moveAction.destination;
        }
        public UserControl GetUC()
        {
            return this;
        }
        public void Save(ActionSet ActionSet)
        {
            ActionSet.Add(this);
        }

        
        public void WriteToConfig(System.Xml.XmlWriter Writer)
        {
            Writer.WriteStartElement("kind");
            Writer.WriteValue("unpack");
            Writer.WriteEndElement();
        }
    }
}
