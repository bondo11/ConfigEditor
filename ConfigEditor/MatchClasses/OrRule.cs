using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConfigEditor
{
    class OrRule : Match
    {
        public List<Match> matchRules = new List<Match>();
        public OrRule()
        {
            this.kind = RulesCollection.MatchKinds.Or;
        }
        public void add(Match matchRule)
        {
            matchRules.Add(matchRule);
        }
    }
}
