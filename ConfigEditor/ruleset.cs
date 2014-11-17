using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConfigEditor
{
    public class ruleset
    {
        public MatchSet matchSet { get; set; }
        public ActionSet actionSet;

        public ruleset(MatchSet matchSet, ActionSet actionSet)
        {
            this.matchSet = matchSet;
            this.actionSet = actionSet;
        }
    }
}
