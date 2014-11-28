using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls;

namespace ConfigEditor
{
    public class MoveAction : Action
    {
        public string destination;
        public MoveAction()
        {
            this.kind = RulesCollection.ActionKinds.moveAction;
        }

        public MoveAction(string destination)
        {
            // TODO: Complete member initialization
            this.destination = destination;
        }

        public new UserControl GetUC()
        {
            return new ucMoveAction(this);
        }
    }
}
