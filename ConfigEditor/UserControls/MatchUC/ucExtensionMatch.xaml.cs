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

namespace ConfigEditor.MatchClasses
{
    /// <summary>
    /// Interaction logic for ucExtentionMatch.xaml
    /// </summary>
    public partial class ucExtensionMatch : UserControl, Match
    {
        public RulesCollection.MatchKinds Kind { get; set; }
        public string Extension;

        public ucExtensionMatch()
        {
            InitializeComponent();
            Kind = RulesCollection.MatchKinds.Extension;
            Extension = "";
        }
        public ucExtensionMatch(string Extension)
            : this()
        {
            this.Extension = Extension;
            tbExtension.Text = Extension;
        }

        public UserControl GetUC()
        {
            return this;
        }

        public Match Save()
        {
            Extension = tbExtension.Text;
            return this;
        }

        public void WriteToConfig(XmlWriter Writer)
        {
            Writer.WriteStartElement("kind");
            Writer.WriteValue("extension");
            Writer.WriteEndElement();

            Writer.WriteStartElement("extension");
            Writer.WriteValue(Extension);
            Writer.WriteEndElement();
        }
    }
}
