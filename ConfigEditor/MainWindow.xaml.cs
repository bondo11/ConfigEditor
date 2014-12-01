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

        configHandler cl = new configHandler();
        //RulesCollection rulesCollection;
        public MainWindow()
        {
            cl.getConfig();
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

        private void btnSettings_MouseEnter(object sender, MouseEventArgs e)
        {
            settingsImage.Opacity = 1;
        }

        private void btnSettings_MouseLeave(object sender, MouseEventArgs e)
        {
            settingsImage.Opacity = 0.65;
        }


        private void btnSave_MouseEnter(object sender, MouseEventArgs e)
        {
            btnSave.Opacity = 1;
        }

        private void btnSave_MouseLeave(object sender, MouseEventArgs e)
        {
            btnSave.Opacity = 0.7;
        }

        private void btnReload_MouseEnter(object sender, MouseEventArgs e)
        {
            btnReloadImage.Opacity = 1;

        }

        private void btnReload_MouseLeave(object sender, MouseEventArgs e)
        {
            btnReloadImage.Opacity = 0.7;
        }

        private void delFolder_MouseEnter(object sender, MouseEventArgs e)
        {
            delFolderImage.Opacity = 1;
        }

        private void delFolder_MouseLeave(object sender, MouseEventArgs e)
        {
            delFolderImage.Opacity = 0.7;
        }

        private void addFolder_MouseEnter(object sender, MouseEventArgs e)
        {
            addFolderImage.Opacity = 1;

        }

        private void addFolder_MouseLeave(object sender, MouseEventArgs e)
        {
            addFolderImage.Opacity = 0.7;
        }

        private void delRule_MouseEnter(object sender, MouseEventArgs e)
        {
            delFolderImage.Opacity = 1;
        }

        private void delRule_MouseLeave(object sender, MouseEventArgs e)
        {
            delRuleImage.Opacity = 0.7;
        }

        private void addRule_MouseEnter(object sender, MouseEventArgs e)
        {
            addRuleImage.Opacity = 1;

        }

        private void addRule_MouseLeave(object sender, MouseEventArgs e)
        {
            addRuleImage.Opacity = 0.7;
        }

        private void addMatch_MouseEnter(object sender, MouseEventArgs e)
        {
            addMatchImage.Opacity = 1;
        }

        private void addMatch_MouseLeave(object sender, MouseEventArgs e)
        {
            addMatchImage.Opacity = 0.7;

        }

        private void removeMatch_MouseEnter(object sender, MouseEventArgs e)
        {
            removeMatchImage.Opacity = 1;
            removeMatch.Background = null;
        }

        private void removeMatch_MouseLeave(object sender, MouseEventArgs e)
        {
            removeMatchImage.Opacity = 0.7;
        } 
        #endregion

        private void listActiveMatches_Initialized(object sender, EventArgs e)
        {

            foreach (ActionSet a in RulesCollection.actionSets)
            {
                listActiveMatches.Items.Add(a.Name);
            }
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

        


    }
}
