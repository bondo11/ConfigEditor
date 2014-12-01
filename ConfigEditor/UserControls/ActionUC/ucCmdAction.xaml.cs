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
    /// Interaction logic for cmdAction.xaml
    /// </summary>
    public partial class ucCmdAction : UserControl, Action
    {
        public RulesCollection.ActionKinds Kind { get; set; }
        public string Command { get; set; }

        public ucCmdAction()
        {
            InitializeComponent();
            Kind = RulesCollection.ActionKinds.Cmd;
            Command = "";
        }
        public ucCmdAction(string Command)
            : this()
        {
            this.Command = Command;
            tbCmd.Text = Command;
        }

        public UserControl GetUC()
        {
            return this;
        }
        public void Save(ActionSet ActionSet)
        {
            Command = tbCmd.Text;
            ActionSet.Add(this);
        }
        public void WriteToConfig(System.Xml.XmlWriter Writer)
        {
            Writer.WriteStartElement("kind");
            Writer.WriteValue("cmd");
            Writer.WriteEndElement();

            Writer.WriteStartElement("command");
            Writer.WriteValue(Command);
            Writer.WriteEndElement();
        }
    }
}
