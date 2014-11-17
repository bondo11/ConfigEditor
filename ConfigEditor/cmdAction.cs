using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConfigEditor
{
    class cmdAction : Action
    {
        private string command;

        public cmdAction(string command)
        {
            this.command = command;
        }
    }
}
