using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace ConfigEditor
{
    public class Action
    {
        public RulesCollection.ActionKinds kind;

        public UserControl GetUC()
        {
            return new UserControl();
        }
    }
}
