﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Xml;

namespace ConfigEditor.MatchClasses
{
    /// <summary>
    /// Interaction logic for ucRegexMatch.xaml
    /// </summary>
    public partial class ucRegexMatch : UserControl, Match
    {
        public RulesCollection.MatchKinds Kind { get; set; }
        public string Pattern;

        public ucRegexMatch()
        {
            InitializeComponent();
            Kind = RulesCollection.MatchKinds.Regex;
            Pattern = "";
        }
        public ucRegexMatch(string Pattern)
            : this()
        {
            this.Pattern = Pattern;
            tbRegex.Text = Pattern;
        }

        public UserControl GetUC()
        {
            return this;
        }

        public Match Save()
        {
            Pattern = tbRegex.Text;
            return this;
        }

        public void WriteToConfig(XmlWriter Writer)
        {
            Writer.WriteStartElement("kind");
            Writer.WriteValue("regex");
            Writer.WriteEndElement();

            Writer.WriteStartElement("pattern");
            Writer.WriteValue(Pattern);
            Writer.WriteEndElement();
        }
    }
}
