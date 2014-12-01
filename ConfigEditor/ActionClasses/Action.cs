using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Xml;

namespace ConfigEditor
{
    public interface Action
    {
        RulesCollection.ActionKinds Kind { get; set; }

        UserControl GetUC();
        void Save(ActionSet ActionSet);
        void WriteToConfig(XmlWriter Writer);
    }
}
