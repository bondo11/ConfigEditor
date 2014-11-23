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

        public enum ActionKinds{moveAction=0, copyAction=1, deleteAction=2, cmdAction=3}
        public enum MatchKinds{And=0, Or=1, extensionMatch=2, regexMatch=3}
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
