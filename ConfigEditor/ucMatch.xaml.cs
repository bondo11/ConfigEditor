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
    /// Interaction logic for UCaction.xaml
    /// </summary>
    public partial class ucMatch : UserControl
    {
        private Match match;
        private UserControl UCmatch;
        //private RulesCollection.MatchKinds kind;


        public ucMatch()
        {
            InitializeComponent();
            foreach (RulesCollection.MatchKinds kind in (RulesCollection.MatchKinds[])Enum.GetValues(typeof(RulesCollection.MatchKinds)))
            {
                cbMatch.Items.Add(kind);
            }
        }
        public ucMatch(Match match, UserControl UC)
            : this()
        {
            cbMatch.SelectedIndex = (int)match.kind;
            this.UCmatch = UC;
            container.Children.Add(UCmatch);
        }

        public ucMatch(Match match) : this()
        {
            // TODO: Complete member initialization
            this.match = match;
            switch (match.kind)
            {
                case RulesCollection.MatchKinds.And:
                    addAndUC((AndRule)match);
                    break;
                case RulesCollection.MatchKinds.Or:
                    addOrUC((OrRule)match);
                    break;
                default:
                    break;
            }
        }

        private void addAndUC(AndRule match)
        {
            foreach (Match m in match.matchRules)
            {
                switch (m.kind)
                {
                    case RulesCollection.MatchKinds.And:
                        break;
                    case RulesCollection.MatchKinds.Or:
                        break;
                    case RulesCollection.MatchKinds.extensionMatch:
                        break;
                    case RulesCollection.MatchKinds.regexMatch:
                        break;
                    default:
                        break;
                }
            }
        }

        private void addOrUC(OrRule match)
        {
            foreach (Match m in match.matchRules)
            {
                switch (m.kind)
                {
                    case RulesCollection.MatchKinds.And:
                        break;
                    case RulesCollection.MatchKinds.Or:
                        break;
                    case RulesCollection.MatchKinds.extensionMatch:
                        break;
                    case RulesCollection.MatchKinds.regexMatch:
                        break;
                    default:
                        break;
                }
            }
        }

    }
}
