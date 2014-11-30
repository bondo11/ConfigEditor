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
        private Match match;

        public ucMatch()
        {
            InitializeComponent();
            foreach (RulesCollection.MatchKinds kind in (RulesCollection.MatchKinds[])Enum.GetValues(typeof(RulesCollection.MatchKinds)))
            {
                cbMatch.Items.Add(kind);
            }
        }

        public ucMatch(Match match) : this()
        {
            this.match = match;
            cbMatch.SelectedIndex = (int)match.kind;
        }

        private void cbMatch_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            container.Children.Clear();

            if ((int)match.kind != cbMatch.SelectedIndex)
            {
                switch (cbMatch.SelectedIndex)
                {
                    case (int)RulesCollection.MatchKinds.And:
                        AndRule and = new AndRule();
                        match.replace(and);
                        match = and;
                        break;
                    case (int)RulesCollection.MatchKinds.Or:
                        OrRule or = new OrRule();
                        match.replace(or);
                        match = or;
                        break;
                    case (int)RulesCollection.MatchKinds.extensionMatch:
                        extensionMatch ext = new extensionMatch();
                        match.replace(ext);
                        match = ext;
                        break;
                    case (int)RulesCollection.MatchKinds.regexMatch:
                        regexMatch reg = new regexMatch();
                        match.replace(reg);
                        match = reg;
                        break;
                    default:
                        break;
                }
            }

            switch (match.kind)
            {
                case RulesCollection.MatchKinds.And:
                    container.Children.Add(((AndRule)match).GetUC());
                    break;
                case RulesCollection.MatchKinds.Or:
                    container.Children.Add(((OrRule)match).GetUC());
                    break;
                case RulesCollection.MatchKinds.extensionMatch:
                    container.Children.Add(((extensionMatch)match).GetUC());
                    break;
                case RulesCollection.MatchKinds.regexMatch:
                    container.Children.Add(((regexMatch)match).GetUC());
                    break;
                default:
                    break;
            }
        }

        public Match GetMatch()
        {
            switch (cbMatch.SelectedIndex)
            {
                case (int)RulesCollection.MatchKinds.And:
                    return ((ucMatchAnd)container.Children[0]).GetMatch();
                case (int)RulesCollection.MatchKinds.Or:
                    return ((ucMatchOr)container.Children[0]).GetMatch();
                case (int)RulesCollection.MatchKinds.extensionMatch:
                    return ((ucExtentionMatch)container.Children[0]).GetMatch();
                case (int)RulesCollection.MatchKinds.regexMatch:
                    return ((ucRegexMatch)container.Children[0]).GetMatch();
                default:
                    break;
            }

            return match;
        }
    }
}
