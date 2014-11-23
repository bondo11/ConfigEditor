using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConfigEditor
{
    class regexMatch: Match
    {
        public String regex = "";
        public regexMatch()
        {
            this.kind = RulesCollection.MatchKinds.regexMatch;
        }
        public regexMatch(String regex) : this()
        {
            this.regex = regex;
        }
    }
}
