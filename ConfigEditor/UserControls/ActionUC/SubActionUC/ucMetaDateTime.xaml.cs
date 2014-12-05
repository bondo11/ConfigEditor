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
using System.Xml;

namespace ConfigEditor.UserControls.ActionUC.SubActionUC
{
    /// <summary>
    /// Interaction logic for ucMetaDateTime.xaml
    /// </summary>
    public partial class ucMetaDateTime : UserControl
    {
        DateTime date;
        public ucMetaDateTime()
        {
            InitializeComponent();
        }
        public ucMetaDateTime(DateTime date)
            : this()
        {
            this.date = date;
        }
        public new UserControl GetUC()
        {
            return this;
        }
        public void Save(ActionSet ActionSet)
        {
            //Destination = tbPath.Text;
            //ActionSet.Add(this);
        }
        public void WriteToConfig(System.Xml.XmlWriter Writer)
        {
            Writer.WriteStartElement("element");
            Writer.WriteValue("copy");
            Writer.WriteEndElement();

            Writer.WriteStartElement("destination");
            Writer.WriteValue(date);
            Writer.WriteEndElement();
        }
    }
}
