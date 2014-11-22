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
using System.Windows.Shapes;

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
            foreach (MatchSet ms in RulesCollection.getMatchSets())
            {
                listMatchsets.Items.Add(ms.name);
            }
        }

        public EditMatchSets(int MatchSetIndex)
            : this()
        {
            listMatchsets.SelectedIndex = MatchSetIndex;
        }

        private void listActionsets_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            listMatch.Items.Clear();
            foreach (MatchSet ms in RulesCollection.matchSets)
            {
                if (ms.name.Equals(listMatchsets.SelectedValue))
                {
                    ucMatch UCA = new ucMatch(ms.match);
                        listMatch.Items.Add(UCA);
                }
            }
        }

    }
}
