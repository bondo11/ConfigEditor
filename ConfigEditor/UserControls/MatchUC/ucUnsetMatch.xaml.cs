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

namespace ConfigEditor.MatchClasses
{
    /// <summary>
    /// Interaction logic for ucExtentionMatch.xaml
    /// </summary>
    public partial class ucUnsetMatch : UserControl, Match
    {
        public RulesCollection.MatchKinds Kind { get; set; }

        public ucUnsetMatch()
        {
            InitializeComponent();
        }

        public UserControl GetUC()
        {
            return this;
        }

        public Match Save()
        {
            return this;
        }

        public void WriteToConfig(System.Xml.XmlWriter Writer)
        {
        }
    }
}
