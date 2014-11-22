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
            foreach (ActionSet a in RulesCollection.getActionSets())
            {
                listActionsets.Items.Add(a.name);
            }
        }

        public EditActionSets(int ActionSetIndex)
            : this()
        {
            listActionsets.SelectedIndex = ActionSetIndex;
            /*foreach (ActionSet a in RulesCollection.actionSets)
            {
                if (a.name.Equals(listActionsets.SelectedValue))
                {
                    foreach (Action act in a.actions)
	                {
                        ucAction UCA = new ucAction(act);
                        listAction.Items.Add(UCA);
	                }
                }
            }*/
        }

        private void listActionsets_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            listAction.Items.Clear();
            foreach (ActionSet a in RulesCollection.actionSets)
            {
                if (a.name.Equals(listActionsets.SelectedValue))
                {
                    foreach (Action act in a.actions)
                    {
                        ucAction UCA = new ucAction(act);
                        listAction.Items.Add(UCA);
                    }
                }
            }
        }

    }
}
