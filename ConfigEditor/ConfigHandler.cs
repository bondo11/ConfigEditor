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
    public class configHandler
    {
        XmlDocument document = new XmlDocument();

        //XmlUrlResolver resolver = new XmlUrlResolver();
        public void getConfig()
        {
            //resolver.Credentials = CredentialCache.DefaultCredentials;
            //document.XmlResolver = resolver;


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

        private MatchSet getMatchSet(string matchSetName)
        {
            MatchSet matchSet = new MatchSet(matchSetName, getMatch("matchsets/matchset[name = '" + matchSetName + "']/match"));
            RulesCollection.AddMatchSet(matchSet);
            return matchSet;
        }

        private Match getMatch(string xpath)
        {
            string kind = document.DocumentElement.SelectSingleNode(xpath + "/kind").InnerText;
            XmlNodeList nodes;
            int i;
            switch (kind)
            {
                case "and":
                    AndRule andRule = new AndRule();

                    nodes = document.DocumentElement.SelectNodes(xpath + "/matches/match");
                    i = 1;
                    foreach (XmlNode node in nodes)
                    {
                        andRule.Add(getMatch(xpath + "/matches/match[" + i + "]"));
                        i++;
                    }

                    return andRule;

                case "or":
                    OrRule orRule = new OrRule();

                    nodes = document.DocumentElement.SelectNodes(xpath + "/matches/match");
                    i = 1;
                    foreach (XmlNode node in nodes)
                    {
                        orRule.Add(getMatch(xpath + "/matches/match[" + i + "]"));
                        i++;
                    }
                    return orRule;

                case "extension":
                    return new extensionMatch(document.DocumentElement.SelectSingleNode(xpath + "/extension").InnerText);

                case "regex":
                    return new regexMatch(document.DocumentElement.SelectSingleNode(xpath + "/pattern").InnerText);

                default:
                    return new Match();
            }
        }

        private ActionSet getActionSet(string actionSetName)
        {
            string xpath = "actionsets/actionset[name = '" + actionSetName + "']";
            ActionSet actionSet = new ActionSet(actionSetName);
            XmlNodeList nodes = document.DocumentElement.SelectNodes(xpath + "/actions/action");
            int i = 1;
            foreach (XmlNode node in nodes)
            {
                actionSet.Add(getAction(xpath + "/actions/action[" + i + "]"));
                i++;
            }
            RulesCollection.AddActionSet(actionSet);
            return actionSet;
        }
        private Action getAction(string xpath)
        {
            string kind = document.DocumentElement.SelectSingleNode(xpath + "/kind").InnerText;

            switch (kind)
            {
                case "copy":
                    return new copyAction(document.DocumentElement.SelectSingleNode(xpath + "/destination").InnerText);

                case "move":
                    return new MoveAction(document.DocumentElement.SelectSingleNode(xpath + "/destination").InnerText);

                case "cmd":
                    return new cmdAction(document.DocumentElement.SelectSingleNode(xpath + "/command").InnerText);

                default:
                    return new Action();
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
            foreach (MatchSet ms in RulesCollection.matchSets)
            {
                writer.WriteStartElement("matchset");

                writer.WriteStartElement("name");
                writer.WriteValue(ms.Name);
                writer.WriteEndElement();

                writeMatch(writer, ms.match);
                writer.WriteEndElement();
            }
        }

        private static void writeMatch(XmlWriter writer, Match match)
        {
            writer.WriteStartElement("match");
            switch (match.kind)
            {
                case RulesCollection.MatchKinds.And:
                    writer.WriteStartElement("kind");
                    writer.WriteValue("and");
                    writer.WriteEndElement();

                    writer.WriteStartElement("matches");
                    foreach (Match m in ((AndRule)match).matchRules)
                    {
                        writeMatch(writer, m);
                    }
                    writer.WriteEndElement();
                    break;

                case RulesCollection.MatchKinds.Or:
                    writer.WriteStartElement("kind");
                    writer.WriteValue("or");
                    writer.WriteEndElement();

                    writer.WriteStartElement("matches");
                    foreach (Match m in ((OrRule)match).matchRules)
                    {
                        writeMatch(writer, m);
                    }
                    writer.WriteEndElement();
                    break;
                case RulesCollection.MatchKinds.extensionMatch:
                    writer.WriteStartElement("kind");
                    writer.WriteValue("or");
                    writer.WriteEndElement();

                    writer.WriteStartElement("extension");
                    writer.WriteValue(((extensionMatch)match).extension);
                    writer.WriteEndElement();
                    break;
                case RulesCollection.MatchKinds.regexMatch:
                    writer.WriteStartElement("kind");
                    writer.WriteValue("regex");
                    writer.WriteEndElement();

                    writer.WriteStartElement("extension");
                    writer.WriteValue(((regexMatch)match).regex);
                    writer.WriteEndElement();
                    break;
                default:
                    break;
            }
            writer.WriteEndElement();
        }

        private static void writeActionSets(XmlWriter writer)
        {
            foreach (ActionSet a in RulesCollection.actionSets)
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
                    switch (action.kind)
                    {
                        case RulesCollection.ActionKinds.moveAction:
                            writer.WriteStartElement("kind");
                            writer.WriteValue("move");
                            writer.WriteEndElement();

                            writer.WriteStartElement("destination");
                            writer.WriteValue(((MoveAction)action).destination);
                            writer.WriteEndElement();
                            break;
                        case RulesCollection.ActionKinds.copyAction:
                            writer.WriteStartElement("kind");
                            writer.WriteValue("copy");
                            writer.WriteEndElement();

                            writer.WriteStartElement("destination");
                            writer.WriteValue(((copyAction)action).destination);
                            writer.WriteEndElement();
                            break;
                        case RulesCollection.ActionKinds.cmdAction:
                            writer.WriteStartElement("kind");
                            writer.WriteValue("cmd");
                            writer.WriteEndElement();

                            writer.WriteStartElement("command");
                            writer.WriteValue(((cmdAction)action).command);
                            writer.WriteEndElement();
                            break;
                        default:
                            break;
                    }

                    writer.WriteEndElement();
                }
                writer.WriteEndElement();

                writer.WriteEndElement();
            }
        }
    }
}
