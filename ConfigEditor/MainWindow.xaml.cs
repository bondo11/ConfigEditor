using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

        //configHandler cl = new configHandler();
        //RulesCollection rulesCollection;
        public MainWindow()
        {
            configHandler.getConfig();
            //rulesCollection = cl.getRules(ConfigHandler.getSource());
            InitializeComponent();
            folderList.ItemsSource = RulesCollection.Folders;
        }

        #region Selection changed functions
        private void folderList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            rulesList.Items.Clear();
            foreach (Folder f in RulesCollection.Folders)
            {
                if (f.Equals(folderList.SelectedValue))
                {
                    foreach (ruleset rs in f.RuleSets)
                    {
                        int msindex = 0;
                        int asindex = 0;
                        //ComboBox cbMatchset = new ComboBox();
                        foreach (MatchSet ms in RulesCollection.matchSets)
                        {
                           
                            if (!ms.Name.Equals(rs.matchSet.Name))
                            {
                                msindex++;
                            }
                            else
                            {
                                break;
                            }
                        }
                        ComboBox cbAction = new ComboBox();
                        foreach (ActionSet a in RulesCollection.actionSets)
                        {
                            if (!a.Name.Equals(rs.actionSet.Name))
                            {
                                asindex++;
                            }
                            else
                            {
                                break;
                            }
                        }

                        rulesList.Items.Add(new ucRuleSet(msindex, asindex));
                        
                    }
                }
            }
        }
        private void listActiveMatches_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
        } 
        #endregion

        #region Button Functions
        private void btnSettings_Click(object sender, RoutedEventArgs e)
        {
            var newW = new settings();
            newW.Show();
        }
        
        #endregion

        #region Button MouseEnter and MouseLeave

        private void btn_MouseEnter(object sender, MouseEventArgs e)
        {
            ((Image)sender).Opacity = 1;
        }

        private void btn_MouseLeave(object sender, MouseEventArgs e)
        {
            ((Image)sender).Opacity = 0.45;
        }
        

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            configHandler.saveConfig();
        }

        private void delRule_Click(object sender, RoutedEventArgs e)
        {
            if (rulesList.SelectedIndex > -1)
                rulesList.Items.RemoveAt(rulesList.SelectedIndex);
        }

        private void addRule_Click(object sender, RoutedEventArgs e)
        {
            rulesList.Items.Add(new ucRuleSet());
        }

        private void folderList_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var newW = new Windows.EditFolder(RulesCollection.Folders[folderList.SelectedIndex]);
            newW.Show();
        }

        private void addFolder_Click(object sender, RoutedEventArgs e)
        {
            
            RulesCollection.Folders.Add(new Folder(""));
            var newW = new Windows.EditFolder(RulesCollection.Folders.Last());
            newW.Show();
        }

        private void delFolder_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (folderList.SelectedIndex > -1)
                RulesCollection.Folders.RemoveAt(folderList.SelectedIndex);
        }



        private void btnReload_MouseDown(object sender, MouseButtonEventArgs e)
        {
            configHandler.getConfig();
        }

        #endregion

    }
}
