using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls;
using System.Xml;

namespace ConfigEditor
{
    public interface Match
    {
        RulesCollection.MatchKinds Kind { get; set; }

        UserControl GetUC();
        Match Save();
        void WriteToConfig(XmlWriter Writer);

    }
}
