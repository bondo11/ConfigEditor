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
using System.Xml;

namespace ConfigEditor.UserControls.ActionUC.SubActionUC
{
    /// <summary>
    /// Interaction logic for ucMetaBool.xaml
    /// </summary>
    public partial class ucMetaBool : UserControl, meta
    {
        

        public ucMetaBool()
        {
            cbBool.IsChecked = false;
            InitializeComponent();
        }
        public ucMetaBool(bool value) : this()
        {
            this.value = value;
            cbBool.IsChecked = value;
        }


        public DateTime date
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public bool value
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        private void cbBool_checked_change(object sender, RoutedEventArgs e)
        {
            if (((CheckBox)sender).IsChecked.Value)
            {
                value = true;
            }
            else
            {
                value = false;
            }

        }

    }
}
