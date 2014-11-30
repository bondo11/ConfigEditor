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
    /// Interaction logic for ucRegexMatch.xaml
    /// </summary>
    public partial class ucRegexMatch : UserControl
    {
        private regexMatch regexMatch;

        public ucRegexMatch()
        {
            InitializeComponent();
        }
        public ucRegexMatch(regexMatch regexMatch)
            : this()
        {
            this.regexMatch = regexMatch;
            tbRegex.Text = regexMatch.regex;
        }

        public Match GetMatch()
        {
            regexMatch.regex = tbRegex.Text;
            return regexMatch;
        }
    }
}
