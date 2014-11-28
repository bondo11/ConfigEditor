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
    /// Interaction logic for ucMatchAnd.xaml
    /// </summary>
    public partial class ucMatchAnd : UserControl
    {
        private AndRule andRule;

        public ucMatchAnd()
        {
            InitializeComponent();
        }
        public ucMatchAnd(List<Match> matchRules)
            : this()
        {
            foreach (Match m in matchRules)
            {
                switch (m.kind)
                {
                    case RulesCollection.MatchKinds.And:
                        listMatch.Items.Add(new ucMatch(m, new ucMatchAnd(((AndRule)m).matchRules)));
                        break;
                    case RulesCollection.MatchKinds.Or:
                        listMatch.Items.Add(new ucMatch(m, new ucMatchOr(((OrRule)m).matchRules)));
                        break;
                    case RulesCollection.MatchKinds.extensionMatch:
                        listMatch.Items.Add(new ucMatch(m, new ucExtentionMatch(((extensionMatch)m).extension)));
                        break;
                    case RulesCollection.MatchKinds.regexMatch:
                        listMatch.Items.Add(new ucMatch(m, new ucRegexMatch(((regexMatch)m).regex)));
                        break;
                    default:
                        listMatch.Items.Add(new ucMatch(m));
                        break;
                }
            }
        }
    }
}
