using ConfigEditor.MatchClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls;

namespace ConfigEditor
{
    public class AndRule : Match
    {
        public List<Match> matchRules = new List<Match>();
        public AndRule()
        {
            this.kind = RulesCollection.MatchKinds.And;
        }
        public void add(Match matchRule)
        {
            matchRules.Add(matchRule);
        }

        public new UserControl GetUC()
        {
            return new ucMatchAnd(this);
        }
    }
}
