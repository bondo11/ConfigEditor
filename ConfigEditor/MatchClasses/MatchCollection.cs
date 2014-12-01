using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Windows.Controls;

namespace ConfigEditor
{
    public interface MatchCollection : Match
    {
        ObservableCollection<Match> Matches { get; set; }

        void ReplaceMatch(Match Match, Match NewMatch);
        void Add(Match Match);
        void Refresh();
        void Clear();
    }
}
