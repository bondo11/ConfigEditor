using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConfigEditor
{
    class AndRule : Match
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
    }
}
