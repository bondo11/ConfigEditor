using ConfigEditor.MatchClasses;
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
        private Match Match;

        public ucMatch()
        {
            InitializeComponent();
            foreach (RulesCollection.MatchKinds kind in (RulesCollection.MatchKinds[])Enum.GetValues(typeof(RulesCollection.MatchKinds)))
            {
                cbMatch.Items.Add(kind);
            }
        }

        public ucMatch(Match Match)
            : this()
        {
            this.Match = Match;
            cbMatch.SelectedIndex = (int)Match.Kind;
        }

        private void cbMatch_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Clear();
            if ((int)Match.Kind != cbMatch.SelectedIndex)
            {
                switch (cbMatch.SelectedIndex)
                {
                    case (int)RulesCollection.MatchKinds.And:
                        Match = new ucMatchAnd();
                        break;
                    case (int)RulesCollection.MatchKinds.Or:
                        Match = new ucMatchOr();
                        break;
                    case (int)RulesCollection.MatchKinds.Extension:
                        Match = new ucExtensionMatch();
                        break;
                    case (int)RulesCollection.MatchKinds.Regex:
                        Match = new ucRegexMatch();
                        break;
                    default:
                        Match = new ucUnsetMatch();
                        break;
                }
            }

            container.Children.Add(Match.GetUC());
            if (Match is MatchCollection)
            {
                ((MatchCollection)Match).Refresh();
            }
        }

        public Match Save() 
        {
            return Match.Save();
        }

        public void Clear()
        {
            container.Children.Clear();
            if (Match is MatchCollection)
            {
                ((MatchCollection)Match).Clear();
            }
        }
    }
}
