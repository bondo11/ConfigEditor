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
                        listAction.Items.Add(new ucAction(act));
                        //switch (act.kind)
                        //{ 
                        //    case RulesCollection.ActionKinds.moveAction:
                        //        listAction.Items.Add(new ucAction(act, new ucMoveAction((MoveAction)act)));
                        //        break;
                        //    case RulesCollection.ActionKinds.copyAction:
                        //        listAction.Items.Add(new ucAction(act, new ucCopyAction((copyAction)act)));
                        //        break;
                        //    case RulesCollection.ActionKinds.deleteAction:
                        //        listAction.Items.Add(new ucAction(act, new ucDeleteAction(act)));
                        //        break;
                        //    case RulesCollection.ActionKinds.cmdAction:
                        //        listAction.Items.Add(new ucAction(act, new ucCmdAction((cmdAction)act)));
                        //        break;
                        //    default:
                        //        listAction.Items.Add(new ucAction(act));
                        //        break;
                        //}
                    }
                }
            }
        }

        private void addbtnActionsets_Click(object sender, RoutedEventArgs e)
        {
            ActionSet a = new ActionSet("actionSet" + (listActionsets.Items.Count + 1).ToString());
            RulesCollection.actionSets.Add(a);
            listActionsets.Items.Add(a.name);
        }

        private void delActionsets_Click(object sender, RoutedEventArgs e)
        {
            if (listActionsets.SelectedIndex > -1)
            {
                for (int i = 0; i < RulesCollection.actionSets.Count; i++)
                {
                    if (RulesCollection.actionSets[i].name.Equals(listActionsets.SelectedIndex))
                        RulesCollection.actionSets.RemoveAt(i);
                }
                listActionsets.Items.RemoveAt(listActionsets.SelectedIndex);
            }
        }

    }
}
