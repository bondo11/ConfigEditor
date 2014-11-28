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
    /// Interaction logic for moveAction.xaml
    /// </summary>
    public partial class ucMoveAction : UserControl
    {
        private MoveAction moveAction;

        public ucMoveAction()
        {
            InitializeComponent();
        }

        public ucMoveAction(MoveAction moveAction): this()
        {
            // TODO: Complete member initialization
            this.moveAction = moveAction;
            tbPath.Text= moveAction.destination;
        }
    }
}
