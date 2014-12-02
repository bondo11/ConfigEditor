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
    /// Interaction logic for ActionSets.xaml
    /// </summary>
    public partial class EditActionSets : Window
    {
        Window mainWin;
        public EditActionSets(MainWindow Main)
        {
            InitializeComponent();
            listActionsets.ItemsSource = RulesCollection.ActionSets;
            mainWin = Main;
        }

        public void SetIndex(int ActionSetIndex)
        {
            listActionsets.SelectedIndex = ActionSetIndex;
        }


        private void listActionsets_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            foreach (ucAction a in listAction.Items)
            {
                a.Clear();
            }
            listAction.Items.Clear();
            foreach (Action a in ((ActionSet)listActionsets.SelectedValue).Actions)
            {
                listAction.Items.Add(new ucAction(a));
            }
        }

        private void addbtnActionsets_Click(object sender, RoutedEventArgs e)
        {
            ActionSet a = new ActionSet("actionSet" + (listActionsets.Items.Count + 1).ToString());
            RulesCollection.ActionSets.Add(a);
            listActionsets.Items.Add(a.Name);
        }

        private void delActionsets_Click(object sender, RoutedEventArgs e)
        {
            if (listActionsets.SelectedIndex > -1)
            {
                for (int i = 0; i < RulesCollection.ActionSets.Count; i++)
                {
                    if (RulesCollection.ActionSets[i].Name.Equals(listActionsets.SelectedIndex))
                        RulesCollection.ActionSets.RemoveAt(i);
                }
                listActionsets.Items.RemoveAt(listActionsets.SelectedIndex);
            }
        }

        private void btnSave_MouseDown(object sender, MouseButtonEventArgs e)
        {
            ((ActionSet)listActionsets.SelectedItem).Actions.Clear();
            foreach (ucAction a in listAction.Items)
            {
                a.Save((ActionSet)listActionsets.SelectedItem);
            }
        }

        private void btn_MouseEnter(object sender, MouseEventArgs e)
        {
            ((Image)sender).Opacity = 1;
        }

        private void btn_MouseLeave(object sender, MouseEventArgs e)
        {
            ((Image)sender).Opacity = 0.45;
        }

        private void btnOK_MouseDown(object sender, MouseButtonEventArgs e)
        {
            mainWin.Show();
            this.Hide();
        }
        private void listActionsets_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var newW = new Windows.EditActionSet(RulesCollection.ActionSets[listActionsets.SelectedIndex]);
            newW.Show();
        }

        private void addlistActionset_Click(object sender, RoutedEventArgs e)
        {
            ActionSet a = new ActionSet("New ActionSet" + (RulesCollection.ActionSets.Count + 1).ToString());
            RulesCollection.ActionSets.Add(a);
            var newW = new Windows.EditActionSet(RulesCollection.ActionSets.Last());
            newW.Show();
        }
        private void btn_addAction(object sender, RoutedEventArgs e)
        {
            ucCopyAction u = new ucCopyAction();
            RulesCollection.ActionSets[listActionsets.SelectedIndex].Actions.Add(u);
            listAction.Items.Add(new ucAction(u));
        }
        private void btn_delAction(object sender, RoutedEventArgs e)
        {
            if (listAction.SelectedIndex > -1)
            {
                RulesCollection.ActionSets[listActionsets.SelectedIndex].Actions.RemoveAt(listAction.SelectedIndex);
                listAction.Items.RemoveAt(listAction.SelectedIndex);
            }
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            e.Cancel = true;
            btnOK_MouseDown(sender, null);
        }

    }
}
