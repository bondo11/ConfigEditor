using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConfigEditor
{
    public class ruleset
    {
        public match matchSet { get; set; }
        List<Action> actions;

        public ruleset(match matchSet, List<Action> actionSet)
        {
            this.matchSet = matchSet;
            this.actions = actionSet;
        }
    }
}
