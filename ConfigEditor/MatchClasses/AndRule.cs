using ConfigEditor.MatchClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls;

namespace ConfigEditor
{
    public class AndRule : MatchCollection
    {
        public AndRule()
        {
            this.kind = RulesCollection.MatchKinds.And;
        }
        public AndRule(MatchCollection parent)
            : this()
        {
            this.parent = parent;
        }

        public new UserControl GetUC()
        {
            return new ucMatchAnd(this);
        }
    }
}
