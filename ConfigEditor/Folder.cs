using System;
using System.Collections.Generic;
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

        public List<ruleset> rules = new List<ruleset>();

        public Folder(string path)
        {
            Path = path;
        }
        public Folder(string path, List<ruleset> rulesets)
        {
            Path = path;
            rules = rulesets;
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
