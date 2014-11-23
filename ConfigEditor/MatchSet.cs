using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ConfigEditor.MatchClasses;

namespace ConfigEditor
{
    public class MatchSet
    {
        public Match match = new Match();
        public string name;

        public MatchSet(string name, Match match)
        {
            this.name = name;
            this.match = match;
        }
    }
}
