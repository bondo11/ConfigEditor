using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConfigEditor
{
    public class MoveAction : Action
    {
        public string destination;
        private MoveAction()
        {
            this.kind = RulesCollection.ActionKinds.moveAction;
        }

        public MoveAction(string destination)
        {
            // TODO: Complete member initialization
            this.destination = destination;
        }
    }
}
