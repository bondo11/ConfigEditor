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
    /// Interaction logic for UCaction.xaml
    /// </summary>
    public partial class ucAction : UserControl
    {
        private Action act;


        public ucAction()
        {
            InitializeComponent();
            foreach (RulesCollection.ActionKinds kind in (RulesCollection.ActionKinds[])Enum.GetValues(typeof(RulesCollection.ActionKinds)))
            {
                cBox.Items.Add(kind);
            }
        }

        public ucAction(Action act) : this()
        {
            this.act = act;
            cBox.SelectedIndex = (int)act.kind;
        }

        private void cBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            container.Children.Clear();

            if ((int)act.kind != cBox.SelectedIndex)
            {
                switch (cBox.SelectedIndex)
                {
                    case (int)RulesCollection.ActionKinds.moveAction:
                        act = new MoveAction();
                        break;
                    case (int)RulesCollection.ActionKinds.copyAction:
                        act = new copyAction();
                        break;
                    case (int)RulesCollection.ActionKinds.deleteAction:
                        act = new Action();
                        break;
                    case (int)RulesCollection.ActionKinds.cmdAction:
                        act = new cmdAction();
                        break;
                    default:
                        act = new Action();
                        break;
                }
            }

            switch (act.kind)
            {
                case RulesCollection.ActionKinds.moveAction:
                    container.Children.Add(((MoveAction)act).GetUC());
                    break;
                case RulesCollection.ActionKinds.copyAction:
                    container.Children.Add(((copyAction)act).GetUC());
                    break;
                case RulesCollection.ActionKinds.deleteAction:
                    break;
                case RulesCollection.ActionKinds.cmdAction:
                    container.Children.Add(((cmdAction)act).GetUC());
                    break;
                default:
                    break;
            }
        }
        //public ucAction(Action act, UserControl uc)
        //    : this()
        //{
        //    cBox.SelectedIndex = (int)act.kind;
        //    this.act = act;
        //    container.Children.Add(uc);
        //}
    }
}
