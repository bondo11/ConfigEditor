using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ConfigEditor.MatchClasses;
using System.ComponentModel;

namespace ConfigEditor
{
    public class MatchSet : INotifyPropertyChanged
    {
        public Match match = new Match();

        private string _Name;
        public string Name { get { return _Name; } set { _Name = value; NotifyPropertyChanged("Name"); } }

        public MatchSet(string name, Match match)
        {
            this.Name = name;
            this.match = match;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(String propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
