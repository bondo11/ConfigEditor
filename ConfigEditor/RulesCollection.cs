using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConfigEditor
{
    public static class RulesCollection
    {

        public static ObservableCollection<ActionSet> actionSets = new ObservableCollection<ActionSet>();
        public static ObservableCollection<MatchSet> matchSets = new ObservableCollection<MatchSet>();
        public static List<Folder> Folders = new List<Folder>();

        #region Set enums
        public enum ActionKinds
        {
            onSet = 0,
            moveAction = 1,
            copyAction = 2,
            deleteAction = 3,
            cmdAction = 4
        }

        public enum MatchKinds
        {
            onSet = 0,
            And = 1,
            Or = 2,
            extensionMatch = 3,
            regexMatch = 4
        } 
        #endregion
        //private static List<ActionSet> actionSets = new List<ActionSet>();
        //private static List<MatchSet> matchSets = new List<MatchSet>();

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
        public static ObservableCollection<MatchSet> getMatchSets()
        {
            return matchSets;
        }
        public static ObservableCollection<ActionSet> getActionSets()
        {
            return actionSets;
        }
    }
}
