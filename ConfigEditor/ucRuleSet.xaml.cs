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
    /// Interaction logic for ucRuleSet.xaml
    /// </summary>
    public partial class ucRuleSet : UserControl
    {
        public ucRuleSet()
        {
            InitializeComponent();
            foreach (MatchSet m in RulesCollection.matchSets)
            {
                cbMatchSet.Items.Add(m.name);
            }
            foreach (ActionSet a in RulesCollection.actionSets)
            {
                cbActionSet.Items.Add(a.name);
            }
        }
        public ucRuleSet(int matchSetIndex, int actionSetIndex) : this()
        {
            cbMatchSet.SelectedIndex = matchSetIndex;
            cbActionSet.SelectedIndex = actionSetIndex;
        }

        private void editMatchSet_Click(object sender, RoutedEventArgs e)
        {
            var newW = new EditMatchSets(cbMatchSet.SelectedIndex);
            newW.Show();
        }

        private void editActionSet_Click(object sender, RoutedEventArgs e)
        {
            var newW = new EditActionSets(cbActionSet.SelectedIndex);
            newW.Show();
        }
    }
}
