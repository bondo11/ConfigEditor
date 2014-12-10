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
    /// Interaction logic for ucMetaDateTime.xaml
    /// </summary>
    public partial class ucMetaDateTime : UserControl, meta
    {
        public DateTime date{ get; set; }

        public bool value { get; set; }
        public ucMetaDateTime()
        {
            InitializeComponent();
        }
        public ucMetaDateTime(DateTime date)
            : this()
        {
            this.date = date;
            dpDate.DisplayDate = date;
        }

        private void dpDate_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            date = dpDate.SelectedDate.Value;
        }

        
    }
}
