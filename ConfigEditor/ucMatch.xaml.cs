﻿using System;
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
                        match = new AndRule();
                        break;
                    case (int)RulesCollection.MatchKinds.Or:
                        match = new OrRule();
                        break;
                    case (int)RulesCollection.MatchKinds.extensionMatch:
                        match = new extensionMatch();
                        break;
                    case (int)RulesCollection.MatchKinds.regexMatch:
                        match = new regexMatch();
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

    }
}
