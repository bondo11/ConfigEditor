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

        public extensionMatch(String extension)
        {
            this.extension = extension;
        }
    }
}
