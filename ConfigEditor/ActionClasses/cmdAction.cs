using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls;

namespace ConfigEditor
{
    public class cmdAction : Action
    {
        public string command;

        public cmdAction()
        {
            this.kind = RulesCollection.ActionKinds.cmdAction;
        }
        public cmdAction(string command) :this()
        {
            this.command = command;
        }

        public new UserControl GetUC()
        {
            return new ucCmdAction(this);
        }
    }
}
