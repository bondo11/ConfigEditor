using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls;

namespace ConfigEditor
{
    public class Match
    {
        protected MatchCollection parent;

        public RulesCollection.MatchKinds kind;

        public Match()
        {
            kind = RulesCollection.MatchKinds.onSet;
        }

        public Match(MatchCollection parent)
            : this()
        {
            this.parent = parent;
        }

        public void replace(Match newMatch)
        {
            if (parent != null)
            {
                parent.replaceChild(this, newMatch);
            }
        }

        public UserControl GetUC()
        {
            return new UserControl();
        }
    }
}
