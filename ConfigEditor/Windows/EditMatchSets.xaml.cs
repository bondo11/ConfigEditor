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
using ConfigEditor.MatchClasses;
using System.ComponentModel;

namespace ConfigEditor
{
    /// <summary>
    /// Interaction logic for EditMatchSets.xaml
    /// </summary>
    public partial class EditMatchSets : Window
    {
        Window mainWin;
        public EditMatchSets(MainWindow Main)
        {
            InitializeComponent();
            listMatchsets.ItemsSource = RulesCollection.MatchSets;
            mainWin = Main;
        }

        public void SetIndex(int MatchSetIndex)
        {
            listMatchsets.SelectedIndex = MatchSetIndex;
        }

        private void listMatchsets_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (MatchContainer.Content is ucMatch)
            {
                ((ucMatch)MatchContainer.Content).Clear();
            }
            MatchContainer.Content = new ucMatch(((MatchSet)listMatchsets.SelectedValue).Match);
        }

        private void btnAddMatchSet_Click(object sender, RoutedEventArgs e)
        {

            MatchSet ms = new MatchSet("matchset" + (RulesCollection.MatchSets.Count + 1).ToString(), new ucRegexMatch());
            RulesCollection.MatchSets.Add(ms);
            //listMatchsets.Items.Add(ms.Name);
        }

        private void btnDelMatchSet_Click(object sender, RoutedEventArgs e)
        {
          
            if (listMatchsets.SelectedIndex > -1)
            {
                RulesCollection.MatchSets.RemoveAt(listMatchsets.SelectedIndex);
            }
        }

        private void btnMoveMatchUp_Click(object sender, RoutedEventArgs e)
        {
            //((MatchSet)listMatchsets.SelectedItem).match
        }

        private void btn_MouseEnter(object sender, MouseEventArgs e)
        {
            ((Image)sender).Opacity = 1;
        }

        private void btn_MouseLeave(object sender, MouseEventArgs e)
        {
            ((Image)sender).Opacity = 0.45;
        }

        //private void btnOK_MouseDown(object sender, MouseButtonEventArgs e)
        //{
        //    mainWin.Show();
        //    this.Hide();
        //}

        private void btnSave_MouseDown(object sender, MouseButtonEventArgs e)
        {
            RulesCollection.MatchSets[listMatchsets.SelectedIndex].Match.Save();
        }

        private void btnOK_MouseDown(object sender, MouseButtonEventArgs e)
        {
            mainWin.Show();
            this.Hide();
        }

        private void Window_Closing(object sender, CancelEventArgs e)
        {
            e.Cancel = true;
            btnOK_MouseDown(sender, null);
        }
        private void listMatchsets_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var newW = new Windows.EditMatchSet(RulesCollection.MatchSets[listMatchsets.SelectedIndex]);
            newW.Show();
        }

        private void addlistMatchset_Click(object sender, RoutedEventArgs e)
        {
            MatchSet ms = new MatchSet("New Matchset" + (RulesCollection.MatchSets.Count + 1).ToString(), new ucRegexMatch());
            RulesCollection.MatchSets.Add(ms);
            var newW = new Windows.EditMatchSet(RulesCollection.MatchSets.Last());
            newW.Show();
        }


    }
}
