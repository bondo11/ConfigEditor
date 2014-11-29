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

        private static ObservableCollection<ActionSet> _actionSets = new ObservableCollection<ActionSet>();
        public static ObservableCollection<ActionSet> actionSets { get { return _actionSets; } }

        private static ObservableCollection<MatchSet> _matchSets = new ObservableCollection<MatchSet>();
        public static ObservableCollection<MatchSet> matchSets { get { return _matchSets; } }

        private static ObservableCollection<Folder> _Folders = new ObservableCollection<Folder>();
        public static ObservableCollection<Folder> Folders { get { return _Folders; } }


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

        public static bool AddActionSet(ActionSet actionSet)
        {
            foreach (ActionSet a in _actionSets)
            {
                if (a.name.Equals(actionSet.name))
                {
                    return false;
                }
            }
            _actionSets.Add(actionSet);
            return true;
        }
        public static void RemoveActionSet(int index)
        {
            _actionSets.RemoveAt(index);
        }
        public static bool AddMatchSet(MatchSet matchSet)
        {
            foreach (MatchSet m in _matchSets)
            {
                if (m.name.Equals(matchSet.name))
                {
                    return false;
                }
            }
            _matchSets.Add(matchSet);
            return true;
        }
        public static void RemoveMatchSet(int index)
        {
            _matchSets.RemoveAt(index);
        }
    }
}
