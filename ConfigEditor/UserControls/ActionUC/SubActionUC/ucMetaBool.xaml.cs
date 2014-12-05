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
    public partial class ucMetaBool : UserControl
    {
        
        bool value;
        public ucMetaBool()
        {
            InitializeComponent();
            value = false;
        }
        public ucMetaBool(bool value) : this()
        {
            this.value = value;
        }
        
        public UserControl GetUC()
        {
            return (UserControl)this;
        }
        partial void Save(ActionSet ActionSet);
        partial void WriteToConfig(XmlWriter Writer);
        

    }
}
