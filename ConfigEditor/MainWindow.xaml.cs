using System;
using System.Collections.Generic;
using System.IO;
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
using System.Xml.Serialization;

namespace ConfigEditor
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        configLoader cl = new configLoader();
        RulesCollection rulesCollection;
        public MainWindow()
        {
            rulesCollection = cl.getRules(@"C:\config\config.xml");
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
           
        }

        private void RuleList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            listMatches.Items.Clear();
            foreach (string match in configLoader.matchArray(ConfigHandler.getSource())){
                listMatches.Items.Add(match);
            }
        }

        private void RuleList_Initialized(object sender, EventArgs e)
        {

            foreach (string folder in rulesCollection.folderCollection)
            {
                RuleList.Items.Add(folder);
            }
        }

        private void btnSettings_Click(object sender, RoutedEventArgs e)
        {
            var newW = new settings();
            newW.Show(); 
        }

        private void listMatches_Initialized(object sender, EventArgs e)
        {
            foreach (string match in rulesCollection.matchsetCollection)
            {
                listMatches.Items.Add(match);
            }
        }


    }
}
