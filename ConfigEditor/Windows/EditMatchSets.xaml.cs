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
using System.Windows.Shapes;
using ConfigEditor.MatchClasses;

namespace ConfigEditor
{
    /// <summary>
    /// Interaction logic for EditMatchSets.xaml
    /// </summary>
    public partial class EditMatchSets : Window
    {
        public EditMatchSets()
        {
            InitializeComponent();
            foreach (MatchSet ms in RulesCollection.matchSets)
            {
                listMatchsets.Items.Add(ms.Name);
            }
        }

        public EditMatchSets(int MatchSetIndex)
            : this()
        {
            listMatchsets.SelectedIndex = MatchSetIndex;
        }

        private void listMatchsets_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            listMatch.Items.Clear();
            foreach (MatchSet ms in RulesCollection.matchSets)
            {
                if (ms.Name.Equals(listMatchsets.SelectedValue))
                {                   
                    switch (ms.match.kind)
                    {
                        case RulesCollection.MatchKinds.And:
                            listMatch.Items.Add(new ucMatch((AndRule)ms.match));
                            break;
                        case RulesCollection.MatchKinds.Or:
                            listMatch.Items.Add(new ucMatch((OrRule)ms.match));
                            break;
                        case RulesCollection.MatchKinds.extensionMatch:
                            listMatch.Items.Add(new ucMatch((extensionMatch)ms.match));
                            break;
                        case RulesCollection.MatchKinds.regexMatch:
                            listMatch.Items.Add(new ucMatch((regexMatch)ms.match));
                            break;
                        default:
                            listMatch.Items.Add(new ucMatch(ms.match));
                            break;
                    }
                }
            }
        }

        private void btnAddMatch_Click(object sender, RoutedEventArgs e)
        {
            listMatch.Items.Add(new ucMatch());
        }

        private void addbtnMatchsets_Click(object sender, RoutedEventArgs e)
        {
            MatchSet ms = new MatchSet("matchset" + (listMatchsets.Items.Count + 1).ToString(), new regexMatch(""));
            RulesCollection.matchSets.Add(ms);
            listMatchsets.Items.Add(ms.Name);
        }

        private void delMatchsets_Click(object sender, RoutedEventArgs e)
        {
          
            if (listMatchsets.SelectedIndex > -1)
            {
                for (int i = 0; i < RulesCollection.matchSets.Count; i++)
                {
                    if (RulesCollection.matchSets[i].Name.Equals(listMatchsets.SelectedIndex))
                        RulesCollection.matchSets.RemoveAt(i);
                }

                listMatchsets.Items.RemoveAt(listMatchsets.SelectedIndex);
            }
        }

    }
}
