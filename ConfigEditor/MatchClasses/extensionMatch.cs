using ConfigEditor.MatchClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace ConfigEditor
{
    public class extensionMatch : Match
    {
        public String extension = "";
        public extensionMatch()
        {
            this.kind = RulesCollection.MatchKinds.extensionMatch;
        }
        public extensionMatch(String extension) : this()
        {
            this.extension = extension;
        }

        public new UserControl GetUC()
        {
            return new ucExtentionMatch(this);
        }
    }
}
