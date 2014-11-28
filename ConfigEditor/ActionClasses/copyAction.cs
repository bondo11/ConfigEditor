using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls;

namespace ConfigEditor
{
    /// <summary>
    /// </summary>
    /// <remarks></remarks>
    public class copyAction : Action
    {
        public string destination;
        private copyAction()
        {
            this.kind = RulesCollection.ActionKinds.copyAction;
        }

        public copyAction(string destination) : this()
        { 
            this.destination = destination;
        }

        public new UserControl GetUC()
        {
            return new ucCopyAction(this);
        }
    }
}
