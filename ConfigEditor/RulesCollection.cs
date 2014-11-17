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
        private static List<ActionSet> actionSets = new List<ActionSet>();
        private static List<MatchSet> matchSets = new List<MatchSet>();

        public static bool AddActionSet(ActionSet actionSet)
        {
            foreach (ActionSet a in actionSets)
            {
                if (a.name.Equals(actionSet.name))
                {
                    return false;
                }
            }
            actionSets.Add(actionSet);
            return true;
        }
        public static void RemoveActionSet(int index)
        {
            actionSets.RemoveAt(index);
        }
        public static bool AddMatchSet(MatchSet matchSet)
        {
            foreach (MatchSet m in matchSets)
            {
                if (m.name.Equals(matchSet.name))
                {
                    return false;
                }
            }
            matchSets.Add(matchSet);
            return true;
        }
        public static void RemoveMatchSet(int index)
        {
            matchSets.RemoveAt(index);
        }
        public static List<MatchSet> getMatchSets()
        {
            return matchSets;
        }
        public static List<ActionSet> getActionSets()
        {
            return actionSets;
        }
    }
}
