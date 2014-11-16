using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConfigEditor
{
    public class match
    {
        public string Name { get; set; }
        public string Kind { get; set; }
        public string Value { get; set; }

        public match();
        public match(string name)
        {
            this.Name = name;
        }
        public match(string name, string kind)
        {
            this.Name = name;
            this.Kind = kind;

        }
        public match(string name, string kind, string value)
        {
            this.Name = name;
            this.Kind = kind;
            this.Value = value;
        }
    }
}
