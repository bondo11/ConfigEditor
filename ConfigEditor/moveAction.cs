using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConfigEditor
{
    class moveAction : Action
    {
        private string destination;

        public moveAction(string destination)
        {
            // TODO: Complete member initialization
            this.destination = destination;
        }
    }
}
