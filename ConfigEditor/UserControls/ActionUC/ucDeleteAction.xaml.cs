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
    /// Interaction logic for ucDeleteAction.xaml
    /// </summary>
    public partial class ucDeleteAction : UserControl
    {

        public ucDeleteAction()
        {
            InitializeComponent();
        }


        public ucDeleteAction(Action act) : this()
        {
            // TODO: Complete member initialization
            //tbPath.Text= moveAction.destination;
        }
    }
}
