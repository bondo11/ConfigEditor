using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls;

namespace ConfigEditor
{
    public class Match
    {

        public RulesCollection.MatchKinds kind;

        public UserControl GetUC()
        {
            return new UserControl();
        }
    }
}
