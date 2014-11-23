using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConfigEditor
{
    public class cmdAction : Action
    {
        public string command;

        private cmdAction()
        {
            this.kind = RulesCollection.ActionKinds.cmdAction;
        }
        public cmdAction(string command) :this()
        {
            this.command = command;
        }
    }
}
