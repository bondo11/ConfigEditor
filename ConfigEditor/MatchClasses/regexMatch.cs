using ConfigEditor.MatchClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls;

namespace ConfigEditor
{
    public class regexMatch: Match
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

        public new UserControl GetUC()
        {
            return new ucRegexMatch(this);
        }
    }
}
