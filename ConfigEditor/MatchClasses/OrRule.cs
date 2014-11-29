using ConfigEditor.MatchClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls;

namespace ConfigEditor
{
    public class OrRule : MatchCollection
    {
        public OrRule()
        {
            this.kind = RulesCollection.MatchKinds.Or;
        }
        public OrRule(MatchCollection parent) : this()
        {
            this.parent = parent;
        }

        public new UserControl GetUC()
        {
            return new ucMatchOr(this);
        }
    }
}
