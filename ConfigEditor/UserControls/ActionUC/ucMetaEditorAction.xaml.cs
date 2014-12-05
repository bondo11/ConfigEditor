using ConfigEditor.UserControls.ActionUC.SubActionUC;
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
    public partial class ucMetaEditorAction : UserControl, Action
    {
        public RulesCollection.ActionKinds Kind { get; set; }
        public metaAction action { get; set; }
        public DateTime date { get; set; }
        public bool value { get; set; }
        UserControl uc;
        public ucMetaEditorAction()
        {
            InitializeComponent();

            Kind = RulesCollection.ActionKinds.Metaeditor;
            foreach (metaAction a in (metaAction[])Enum.GetValues(typeof(metaAction)))
            {
                cBox.Items.Add(a);
            }
        }
        public ucMetaEditorAction(string action, bool value)
            : this()
        {
            switch (action)
            {
                case ("hidden"):
                    this.action = metaAction.hidden;
                    break;
                case ("writeprotected"):
                    this.action = metaAction.writeprotected;
                    break;
                default:
                    break;
            }
            this.value = value;
        }
        public enum metaAction
        {
            creationTime = 0,
            lastModifiedTime = 1,
            lastAccessTime = 2,
            hidden = 3,
            writeprotected = 4
        }

        public ucMetaEditorAction(Action act)
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
            date = DateTime.Now;
            value = true;
            action = metaAction.lastAccessTime;
            ActionSet.Add(this);
        }

        public void WriteToConfig(System.Xml.XmlWriter Writer)
        {
            Writer.WriteStartElement("kind");
            Writer.WriteValue("meta");
            Writer.WriteEndElement();

            Writer.WriteStartElement("tag");
            Writer.WriteValue(Enum.GetName(typeof(metaAction), (int)action));
            Writer.WriteEndElement();
            getActionValues(Writer);

        }

        private void getActionValues(System.Xml.XmlWriter Writer)
        {
            switch (action)
            {
                case metaAction.creationTime:
                    Writer.WriteStartElement("date");
                    Writer.WriteValue(date.ToString("dd/MM/yyyy hh:mm:ss"));
                    Writer.WriteEndElement();
                    break;
                case metaAction.lastModifiedTime:
                    Writer.WriteStartElement("date");
                    Writer.WriteValue(date.ToString("dd/MM/yyyy hh:mm:ss"));
                    Writer.WriteEndElement();
                    break;
                case metaAction.lastAccessTime:
                    Writer.WriteStartElement("date");
                    Writer.WriteValue(date.ToString("dd/MM/yyyy hh:mm:ss"));
                    Writer.WriteEndElement();
                    break;
                case metaAction.hidden:
                    Writer.WriteStartElement("value");
                    Writer.WriteValue(value);
                    Writer.WriteEndElement();
                    break;
                case metaAction.writeprotected:
                    Writer.WriteStartElement("value");
                    Writer.WriteValue(value);
                    Writer.WriteEndElement();
                    break;
                default:
                    break;
            }
        }
        public void Clear()
        {
            container.Children.Clear();
        }
        private void cBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Clear();

            if ((int)action != cBox.SelectedIndex)
            {
                switch (cBox.SelectedIndex)
                {
                    case (int)metaAction.creationTime:
                        uc = new ucMetaDateTime();
                        break;
                    case (int)metaAction.lastAccessTime:
                        uc = new ucMetaDateTime();
                        break;
                    case (int)metaAction.lastModifiedTime:
                        uc = new ucMetaDateTime();                        
                        break;
                    case (int)metaAction.hidden:
                        uc = new ucMetaBool();
                        break;
                    case (int)metaAction.writeprotected:
                        uc = new ucMetaBool();
                        break;
                    default:
                        break;
                }
                container.Children.Add(uc);
            }

        }

    }
}
