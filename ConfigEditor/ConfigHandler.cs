using ConfigEditor.MatchClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using System.Xml.XPath;

namespace ConfigEditor
{
    public static class configHandler
    {
        static XmlDocument document = new XmlDocument();

        //XmlUrlResolver resolver = new XmlUrlResolver();
        public static void getConfig()
        {
            RulesCollection.ClearAll();
            document.Load(ConfigSettings.getSource());
            //document.Load(@"c:\config\config.xml");
            XmlNodeList nodes = document.DocumentElement.SelectNodes("folders/folder/path");
            foreach (XmlNode node in nodes)
            {
                Folder f = new Folder(node.InnerText);

                XmlNodeList rulesets = document.DocumentElement.SelectNodes("folders/folder[path = '" + node.InnerText + "']/rulesets/ruleset");
                foreach (XmlNode ruleset in rulesets)
                {
                    f.RuleSets.Add(new ruleset(getMatchSet(ruleset.SelectSingleNode("matchsetname").InnerText), getActionSet(ruleset.SelectSingleNode("actionsetname").InnerText)));
                }
                RulesCollection.Folders.Add(f);
            }
        }

        private static MatchSet getMatchSet(string matchSetName)
        {
            MatchSet matchSet = new MatchSet(matchSetName, getMatch("matchsets/matchset[name = '" + matchSetName + "']/match"));
            RulesCollection.AddMatchSet(matchSet);
            return matchSet;
        }

        private static Match getMatch(string xpath)
        {
            string kind = document.DocumentElement.SelectSingleNode(xpath + "/kind").InnerText;
            XmlNodeList nodes;
            int i;
            switch (kind)
            {
                case "and":
                    ucMatchAnd And = new ucMatchAnd();
                    nodes = document.DocumentElement.SelectNodes(xpath + "/matches/match");
                    i = 1;
                    foreach (XmlNode node in nodes)
                    {
                        And.Add(getMatch(xpath + "/matches/match[" + i + "]"));
                        i++;
                    }
                    return And;

                case "or":
                    ucMatchOr Or = new ucMatchOr();
                    nodes = document.DocumentElement.SelectNodes(xpath + "/matches/match");
                    i = 1;
                    foreach (XmlNode node in nodes)
                    {
                        Or.Add(getMatch(xpath + "/matches/match[" + i + "]"));
                        i++;
                    }
                    return Or;

                case "extension":
                    return new ucExtensionMatch(document.DocumentElement.SelectSingleNode(xpath + "/extension").InnerText);

                case "regex":
                    return new ucRegexMatch(document.DocumentElement.SelectSingleNode(xpath + "/pattern").InnerText);

                default:
                    return null;
            }
        }

        private static ActionSet getActionSet(string actionSetName)
        {
            string xpath = "actionsets/actionset[name = '" + actionSetName + "']";
            ActionSet actionSet = new ActionSet(actionSetName);
            XmlNodeList nodes = document.DocumentElement.SelectNodes(xpath + "/actions/action");
            int i = 1;
            foreach (XmlNode node in nodes)
            {
                Action Action = getAction(xpath + "/actions/action[" + i + "]");
                if (Action != null)
                {
                    actionSet.Add(Action);
                }
                i++;
            }
            RulesCollection.AddActionSet(actionSet);
            return actionSet;
        }
        private static Action getAction(string xpath)
        {
            string Kind = document.DocumentElement.SelectSingleNode(xpath + "/kind").InnerText;

            switch (Kind)
            {
                case "copy":
                    return new ucCopyAction(document.DocumentElement.SelectSingleNode(xpath + "/destination").InnerText);

                case "move":
                    return new ucMoveAction(document.DocumentElement.SelectSingleNode(xpath + "/destination").InnerText);

                case "cmd":
                    return new ucCmdAction(document.DocumentElement.SelectSingleNode(xpath + "/command").InnerText);

                default:
                    return null;
            }
        }

        public static void saveConfig()
        {
            XmlWriterSettings settings = new XmlWriterSettings();
            settings.Indent = true;
            settings.NewLineOnAttributes = true;
            XmlWriter writer = XmlWriter.Create(@"c:\config\saveconfig.xml", settings);

            writer.WriteStartDocument();
            writer.WriteStartElement("config");

            // Folders
            writer.WriteStartElement("folders");
            writeFolders(writer);
            writer.WriteEndElement();

            // Matches
            writer.WriteStartElement("matchsets");
            writeMatchSets(writer);
            writer.WriteEndElement();

            // ActionSets
            writer.WriteStartElement("actionsets");
            writeActionSets(writer);
            writer.WriteEndElement();

            writer.WriteEndElement();
            writer.WriteEndDocument();
            writer.Flush();

        }

        private static void writeFolders(XmlWriter writer)
        {
            foreach (Folder f in RulesCollection.Folders)
            {
                writer.WriteStartElement("folder");

                //path
                writer.WriteStartElement("path");
                writer.WriteValue(f.Path);
                writer.WriteEndElement();

                writer.WriteStartElement("rulesets");
                foreach (ruleset rs in f.RuleSets)
                {
                    writer.WriteStartElement("ruleset");

                    //matchset
                    writer.WriteStartElement("matchsetname");
                    writer.WriteValue(rs.matchSet.Name);
                    writer.WriteEndElement();

                    //actionset
                    writer.WriteStartElement("actionsetname");
                    writer.WriteValue(rs.actionSet.Name);
                    writer.WriteEndElement();

                    writer.WriteEndElement();
                }
                writer.WriteEndElement();

                writer.WriteEndElement();
            }
        }

        private static void writeMatchSets(XmlWriter writer)
        {
            foreach (MatchSet ms in RulesCollection.MatchSets)
            {
                writer.WriteStartElement("matchset");

                writer.WriteStartElement("name");
                writer.WriteValue(ms.Name);
                writer.WriteEndElement();

                writeMatch(writer, ms.Match);
                writer.WriteEndElement();
            }
        }

        private static void writeMatch(XmlWriter writer, Match match)
        {
            writer.WriteStartElement("match");
            match.WriteToConfig(writer);
            writer.WriteEndElement();
        }

        private static void writeActionSets(XmlWriter writer)
        {
            foreach (ActionSet a in RulesCollection.ActionSets)
            {
                writer.WriteStartElement("actionset");

                //Actionset Name
                writer.WriteStartElement("name");
                writer.WriteValue(a.Name);
                writer.WriteEndElement();

                writer.WriteStartElement("actions");
                foreach (Action action in a.Actions)
                {
                    writer.WriteStartElement("action");
                    action.WriteToConfig(writer);
                    writer.WriteEndElement();
                }
                writer.WriteEndElement();

                writer.WriteEndElement();
            }
        }
    }
}
