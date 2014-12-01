using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace ConfigEditor.MatchClasses
{
    /// <summary>
    /// Interaction logic for ucMatchAnd.xaml
    /// </summary>
    public partial class ucMatchAnd : UserControl, MatchCollection
    {
        public RulesCollection.MatchKinds Kind { get; set; }
        public ObservableCollection<Match> Matches { get; set; }

        public ucMatchAnd()
        {
            InitializeComponent();
            Kind = RulesCollection.MatchKinds.And;
            Matches = new ObservableCollection<Match>();
        }

        public void Refresh()
        {
            Clear();
            foreach (Match m in Matches)
            {
                listMatch.Items.Add(new ucMatch(m));
            }
        }

        private void btn_MouseEnter(object sender, MouseEventArgs e)
        {
            ((Image)sender).Opacity = 1;
        }

        private void btn_MouseLeave(object sender, MouseEventArgs e)
        {
            ((Image)sender).Opacity = 0.45;
        }

        private void delMatch_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (listMatch.SelectedIndex > -1)
            {
                Matches.RemoveAt(listMatch.SelectedIndex);
                Refresh();
            }
        }

        public void ReplaceMatch(Match Match, Match NewMatch)
        {
            for (int i = 0; i < Matches.Count(); i++)
            {
                if (Matches[i].Equals(Match))
                {
                    Matches.RemoveAt(i);
                    Matches.Insert(i, NewMatch);
                    break;
                }
            }
        }

        public void Add(Match Match)
        {
            Matches.Add(Match);
        }

        public UserControl GetUC()
        {
            return this;
        }

        public Match Save()
        {
            Matches.Clear();
            foreach (ucMatch m in listMatch.Items)
            {
                Add(m.Save());
            }
            return this;
        }

        public void WriteToConfig(XmlWriter Writer)
        {
            Writer.WriteStartElement("kind");
            Writer.WriteValue("and");
            Writer.WriteEndElement();

            Writer.WriteStartElement("matches");
            foreach (Match m in Matches)
            {
                m.WriteToConfig(Writer);
            }
            Writer.WriteEndElement();
        }

        public void Clear()
        {
            foreach (ucMatch m in listMatch.Items)
            {
                m.Clear();
            }
            listMatch.Items.Clear();
        }

        private void addMatch_Click(object sender, MouseButtonEventArgs e)
        {
            Add(new ucUnsetMatch());
            Refresh();
        }
    }
}
