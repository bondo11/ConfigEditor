using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace ConfigEditor
{
    public class ActionSet : INotifyPropertyChanged
    {
        private string _Name;
        public string Name { get { return _Name; } set { _Name = value; NotifyPropertyChanged("Name"); } }

        public ObservableCollection<Action> Actions = new ObservableCollection<Action>();

        public ActionSet(string Name)
        {
            this.Name = Name;
        }

        internal void Add(Action Action)
        {
            Actions.Add(Action);
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
