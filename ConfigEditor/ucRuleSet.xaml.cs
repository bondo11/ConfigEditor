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
        private MainWindow MainWindow;
        private EditMatchSets EditMatchSets;
        private EditActionSets EditActionSets;

        public ucRuleSet(MainWindow MainWindow, EditMatchSets EditMatchSets, EditActionSets EditActionSets)
        {
            InitializeComponent();
            cbMatchSet.ItemsSource = RulesCollection.MatchSets;
            cbActionSet.ItemsSource = RulesCollection.ActionSets;
            this.MainWindow = MainWindow;
            this.EditMatchSets = EditMatchSets;
            this.EditActionSets = EditActionSets;
        }

        public ucRuleSet(int matchSetIndex, int actionSetIndex, MainWindow MainWindow, EditMatchSets EditMatchSets, EditActionSets EditActionSets)
            : this(MainWindow, EditMatchSets, EditActionSets)
        {

            cbMatchSet.SelectedIndex = matchSetIndex;
            cbActionSet.SelectedIndex = actionSetIndex;
        }

        private void editMatchSet_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.Hide();
            EditMatchSets.Show();
            EditMatchSets.SetIndex(cbMatchSet.SelectedIndex);
        }

        private void editActionSet_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.Hide();
            EditActionSets.Show();
            EditActionSets.SetIndex(cbActionSet.SelectedIndex);
        }

        private void editMatchSet_MouseEnter(object sender, MouseEventArgs e)
        {
            editMatchSet.Opacity = 1;

        }

        private void editMatchSet_MouseLeave(object sender, MouseEventArgs e)
        {
            editMatchSet.Opacity = 0.45;
        }

        private void editActionSet_MouseEnter(object sender, MouseEventArgs e)
        {
            editActionSet.Opacity = 1;
        }

        private void editActionSet_MouseLeave(object sender, MouseEventArgs e)
        {
            editActionSet.Opacity = 0.45;
        }
    }
}
