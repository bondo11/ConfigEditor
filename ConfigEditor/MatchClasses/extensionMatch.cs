using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConfigEditor
{
    class extensionMatch : Match
    {
        public String extension = "";
        private extensionMatch()
        {
            this.kind = RulesCollection.MatchKinds.extensionMatch;
        }
        public extensionMatch(String extension) : this()
        {
            this.extension = extension;
        }
    }
}
