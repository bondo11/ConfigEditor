using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls;

namespace ConfigEditor
{
    public class MatchCollection : Match
    {
        public List<Match> matchRules = new List<Match>();

        public void replaceChild(Match child, Match newChild)
        {
            for (int i = 0; i < matchRules.Count(); i++)
            {
                if (matchRules[i].Equals(child))
                {
                    matchRules.RemoveAt(i);
                    matchRules.Insert(i, newChild);
                    break;
                }
            }
        }

        public void Add(Match matchRule)
        {
            matchRules.Add(matchRule);
        }

        public new UserControl GetUC()
        {
            return new UserControl();
        }
    }
}
