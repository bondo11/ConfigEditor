using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConfigEditor
{
    public class ActionSet
    {
        public List<Action> actions = new List<Action>();
        public string name;

        public ActionSet(string name)
        {
            this.name = name;
        }

        internal void Add(Action action)
        {
            actions.Add(action);
        }
    }
}
