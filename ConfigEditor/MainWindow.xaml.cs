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

        configHandler cl = new configHandler();
        //RulesCollection rulesCollection;
        public MainWindow()
        {
            cl.getConfig();
            //rulesCollection = cl.getRules(ConfigHandler.getSource());
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
           
        }

        #region Initialized functions
        private void folderList_Initialized(object sender, EventArgs e)
        {
            foreach (Folder f in RulesCollection.Folders)
                folderList.Items.Add(f.Path);
        }


        private void listMatches_Initialized(object sender, EventArgs e)
        {
            foreach (MatchSet ms in RulesCollection.getMatchSets())
            {
                listMatches.Items.Add(ms.name);
            }
            



        } 
        #endregion

        #region Selection changed functions
        private void folderList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            rulesList.Items.Clear();
            foreach (Folder f in RulesCollection.Folders)
            {
                if (f.Path.Equals(folderList.SelectedValue))
                {
                    foreach (ruleset rs in f.rules)
                    {
                        int msindex = 0;
                        int asindex = 0;
                        //ComboBox cbMatchset = new ComboBox();
                        foreach (MatchSet ms in RulesCollection.getMatchSets())
                        {
                           
                            if (!ms.name.Equals(rs.matchSet.name))
                            {
                                msindex++;
                            }
                            else
                            {
                                break;
                            }
                        }
                        ComboBox cbAction = new ComboBox();
                        foreach (ActionSet a in RulesCollection.getActionSets())
                        {
                            if (!a.name.Equals(rs.actionSet.name))
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
            }/*
            foreach (string match in cl.matchArray(ConfigHandler.getSource(), (Convert.ToString(folderList.SelectedItem))))
            {
                listActiveMatches.Items.Add(match);
            }*/
            

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

            foreach (ActionSet a in RulesCollection.getActionSets())
            {
                listActiveMatches.Items.Add(a.name);
            }
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            configHandler.saveConfig();
        }


    }
}
