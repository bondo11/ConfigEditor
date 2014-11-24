using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConfigEditor
{
    public class Folder
    {
        public string Path { get; set; }
        public List<ruleset> rules = new List<ruleset>();

        public Folder(string path)
        {
            Path = path;
        }
        public Folder(string path, List<ruleset> rulesets)
        {
            Path = path;
            rules = rulesets;
        }
    }
}
