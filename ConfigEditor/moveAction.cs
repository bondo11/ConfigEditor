using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConfigEditor
{
    class MoveAction : Action
    {
        public string destination;

        public MoveAction()
        {

        }
        public MoveAction(string destination)
        {
            // TODO: Complete member initialization
            this.destination = destination;
        }
    }
}
