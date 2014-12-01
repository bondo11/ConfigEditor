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

        private static ObservableCollection<ActionSet> _ActionSets = new ObservableCollection<ActionSet>();
        public static ObservableCollection<ActionSet> ActionSets { get { return _ActionSets; } }

        private static ObservableCollection<MatchSet> _MatchSets = new ObservableCollection<MatchSet>();
        public static ObservableCollection<MatchSet> MatchSets { get { return _MatchSets; } }

        private static ObservableCollection<Folder> _Folders = new ObservableCollection<Folder>();
        public static ObservableCollection<Folder> Folders { get { return _Folders; } }

        #region Set enums
        public enum ActionKinds
        {
            Unset = 0,
            Move = 1,
            Copy = 2,
            Cmd = 3
        }

        public enum MatchKinds
        {
            Unset = 0,
            And = 1,
            Or = 2,
            Extension = 3,
            Regex = 4
        } 
        #endregion

        public static bool AddActionSet(ActionSet ActionSet)
        {
            foreach (ActionSet a in _ActionSets)
            {
                if (a.Name.Equals(ActionSet.Name))
                {
                    return false;
                }
            }
            _ActionSets.Add(ActionSet);
            return true;
        }
        public static void RemoveActionSet(int index)
        {
            _ActionSets.RemoveAt(index);
        }

        public static bool AddMatchSet(MatchSet MatchSet)
        {
            foreach (MatchSet m in _MatchSets)
            {
                if (m.Name.Equals(MatchSet.Name))
                {
                    return false;
                }
            }
            _MatchSets.Add(MatchSet);
            return true;
        }
        public static void RemoveMatchSet(int index)
        {
            _MatchSets.RemoveAt(index);
        }

        internal static void ClearAll()
        {
            _Folders.Clear();
            _ActionSets.Clear();
            _MatchSets.Clear();
        }
    }
}
