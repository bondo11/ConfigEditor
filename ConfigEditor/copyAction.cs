using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConfigEditor
{
    /// <summary>
    /// </summary>
    /// <remarks></remarks>
    class copyAction : Action
    {
        public string destination;

        public copyAction(string destination)
        {
            this.destination = destination;
        }
    }
}
