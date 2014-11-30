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
    /// Interaction logic for ucMatchOr.xaml
    /// </summary>
    public partial class ucMatchOr : UserControl
    {
        private OrRule OrRule;

        public ucMatchOr()
        {
            InitializeComponent();
        }
        public ucMatchOr(OrRule OrRule)
            : this()
        {
            this.OrRule = OrRule;
            refresh();
        }
        private void refresh()
        {
            listMatch.Items.Clear();
            foreach (Match m in OrRule.matchRules)
            {
                switch (m.kind)
                {
                    case RulesCollection.MatchKinds.And:
                        listMatch.Items.Add(new ucMatch((AndRule)m));
                        break;
                    case RulesCollection.MatchKinds.Or:
                        listMatch.Items.Add(new ucMatch((OrRule)m));
                        break;
                    case RulesCollection.MatchKinds.extensionMatch:
                        listMatch.Items.Add(new ucMatch((extensionMatch)m));
                        break;
                    case RulesCollection.MatchKinds.regexMatch:
                        listMatch.Items.Add(new ucMatch((regexMatch)m));
                        break;
                    default:
                        listMatch.Items.Add(new ucMatch(m));
                        break;
                }
            }
        }

        private void addMatch_Click(object sender, RoutedEventArgs e)
        {
            OrRule.Add(new Match(OrRule));
            refresh();
        }

        public Match GetMatch()
        {
            OrRule.matchRules.Clear();
            foreach (ucMatch ucM in listMatch.Items)
            {
                OrRule.matchRules.Add(ucM.GetMatch());
            }

            return OrRule;
        }
    }
}
