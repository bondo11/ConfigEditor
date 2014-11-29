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
    public partial class ucExtentionMatch : UserControl
    {
        private extensionMatch extensionMatch;

        public ucExtentionMatch()
        {
            InitializeComponent();
        }


        public ucExtentionMatch(extensionMatch extensionMatch)
            : this()
        {
            this.extensionMatch = extensionMatch;
            tbExtension.Text = extensionMatch.extension;
        }
    }
}
