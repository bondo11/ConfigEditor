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
            cBox.SelectedIndex = (int)act.kind;
            this.act = act;
        }
        public ucAction(Action act, UserControl uc)
            : this()
        {
            cBox.SelectedIndex = (int)act.kind;
            this.act = act;
            container.Children.Add(uc);
        }
    }
}
