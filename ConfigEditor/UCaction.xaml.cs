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
        private Action Action;

        public ucAction()
        {
            InitializeComponent();
            foreach (RulesCollection.ActionKinds Kind in (RulesCollection.ActionKinds[])Enum.GetValues(typeof(RulesCollection.ActionKinds)))
            {
                cBox.Items.Add(Kind);
            }
        }
        public ucAction(Action Action)
            : this()
        {
            this.Action = Action;
            cBox.SelectedIndex = (int)Action.Kind;
        }

        public void Clear()
        {
            container.Children.Clear();
        }
        private void cBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Clear();

            if (Action != null && (int)Action.Kind != cBox.SelectedIndex)
            {
                switch (cBox.SelectedIndex)
                {
                    case (int)RulesCollection.ActionKinds.Move:
                        Action = new ucMoveAction();
                        break;
                    case (int)RulesCollection.ActionKinds.Copy:
                        Action = new ucCopyAction();
                        break;
                    case (int)RulesCollection.ActionKinds.Cmd:
                        Action = new ucCmdAction();
                        break;
                    default:
                        Action = null;
                        break;
                }
            }

            if (Action != null)
            {
                container.Children.Add(Action.GetUC());
            }
        }

        public void Save(ActionSet ActionSet)
        {
            Action.Save(ActionSet);
        }
    }
}
