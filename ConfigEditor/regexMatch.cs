using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConfigEditor
{
    class regexMatch: Match
    {
        public String regex = "";

        public regexMatch(String regex)
        {
            this.regex = regex;
        }
    }
}
