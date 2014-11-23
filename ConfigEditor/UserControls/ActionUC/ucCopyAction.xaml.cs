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
    /// Interaction logic for copyAction.xaml
    /// </summary>
    public partial class ucCopyAction : UserControl
    {
        private copyAction copyAction;

        public ucCopyAction()
        {
            InitializeComponent();
        }
        
        public ucCopyAction(copyAction copyAction)
            : this()
        {
            // TODO: Complete member initialization
            this.copyAction = copyAction;
            tbPath.Text = copyAction.destination;
        }
    }
}
