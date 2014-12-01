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
        public EditActionSets()
        {
            InitializeComponent();
            listActionsets.ItemsSource = RulesCollection.actionSets;
        }

        public EditActionSets(int ActionSetIndex)
            : this()
        {
            listActionsets.SelectedIndex = ActionSetIndex;
        }


        private void listActionsets_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            listAction.Items.Clear();
            foreach (Action a in ((ActionSet)listActionsets.SelectedValue).Actions)
            {
                listAction.Items.Add(new ucAction(a));
            }
        }

        private void addbtnActionsets_Click(object sender, RoutedEventArgs e)
        {
            ActionSet a = new ActionSet("actionSet" + (listActionsets.Items.Count + 1).ToString());
            RulesCollection.actionSets.Add(a);
            listActionsets.Items.Add(a.Name);
        }

        private void delActionsets_Click(object sender, RoutedEventArgs e)
        {
            if (listActionsets.SelectedIndex > -1)
            {
                for (int i = 0; i < RulesCollection.actionSets.Count; i++)
                {
                    if (RulesCollection.actionSets[i].Name.Equals(listActionsets.SelectedIndex))
                        RulesCollection.actionSets.RemoveAt(i);
                }
                listActionsets.Items.RemoveAt(listActionsets.SelectedIndex);
            }
        }

    }
}
