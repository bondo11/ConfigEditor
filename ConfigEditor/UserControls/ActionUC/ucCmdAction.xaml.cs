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
    /// Interaction logic for cmdAction.xaml
    /// </summary>
    public partial class ucCmdAction : UserControl
    {
        private cmdAction cmdAction;

        public ucCmdAction()
        {
            InitializeComponent();
        }


        public ucCmdAction(cmdAction cmdAction)
            : this()
        {
            this.cmdAction = cmdAction;
            // TODO: Complete member initialization
            tbCmd.Text = cmdAction.command;
        }
    }
}
