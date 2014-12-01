using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConfigEditor
{
    public class Folder : INotifyPropertyChanged
    {
        private string _Path;
        public string Path { get { return _Path; } set { _Path = value; NotifyPropertyChanged("Path"); } }

        public ObservableCollection<ruleset> RuleSets = new ObservableCollection<ruleset>();

        public Folder()
        {
            this.Path = "";
        }
        public Folder(string Path) : this()
        {
            this.Path = Path;
        }
        public Folder(string Path, ObservableCollection<ruleset> RuleSets)
        {
            this.Path = Path;
            this.RuleSets = RuleSets;
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
