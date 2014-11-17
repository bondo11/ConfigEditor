using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConfigEditor
{
    class copyAction : Action
    {
        private string destination;

        public copyAction(string destination)
        {
            this.destination = destination;
        }
    }
}
