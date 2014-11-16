using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConfigEditor
{
    public static class RulesCollection
    {
        public static List<Folder> Folders = new List<Folder>();
        public static List<ActionSet> actionSets = new List<ActionSet>();
        public static List<match> matchSets = new List<match>();
    }
}
