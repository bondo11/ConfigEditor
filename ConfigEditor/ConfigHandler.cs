using System;
using System.Collections.Generic;
using System.Linq;
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
        public void getConfig()
        {
            document.Load(ConfigSettings.getSource());
            //document.Load(@"c:\config\config.xml");

            XmlNodeList nodes = document.DocumentElement.SelectNodes("folders/folder/path");

            foreach (XmlNode node in nodes)
            {
                Folder f = new Folder(node.InnerText);

                XmlNodeList rulesets = document.DocumentElement.SelectNodes("folders/folder[path = '" + node.InnerText + "']/rulesets/ruleset");
                foreach (XmlNode ruleset in rulesets)
                {
                    f.rules.Add(new ruleset(getMatchSet(ruleset.SelectSingleNode("matchsetname").InnerText), getActionSet(ruleset.SelectSingleNode("actionsetname").InnerText)));
                }
                RulesCollection.Folders.Add(f);
            }
        }

        private MatchSet getMatchSet(string matchSetName)
        {
            MatchSet matchSet = new MatchSet(matchSetName, getMatch("matches/match[name = '" + matchSetName + "']"));
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
                        andRule.add(getMatch(xpath + "/matches/match[" + i + "]"));
                        i++;
                    }

                    return andRule;

                case "or":
                    OrRule orRule = new OrRule();

                    nodes = document.DocumentElement.SelectNodes(xpath + "/matches/match");
                    i = 1;
                    foreach (XmlNode node in nodes)
                    {
                        orRule.add(getMatch(xpath + "/matches/match[" + i + "]"));
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
                    return new moveAction(document.DocumentElement.SelectSingleNode(xpath + "/destination").InnerText);

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
            #region folders
            writer.WriteStartElement("folders");
            foreach (Folder f in RulesCollection.Folders)
            {
                writer.WriteStartElement("folder");

                //path
                writer.WriteStartElement("path");
                writer.WriteValue(f.Path);
                writer.WriteEndElement();

                #region rulesets
                writer.WriteStartElement("rulesets");
                foreach (ruleset rs in f.rules)
                {
                    writer.WriteStartElement("ruleset");

                    //matchset
                    writer.WriteStartElement("matchsetname");
                    writer.WriteValue(rs.matchSet.name);
                    writer.WriteEndElement();

                    //actionset
                    writer.WriteStartElement("actionsetname");
                    writer.WriteValue(rs.actionSet.name);
                    writer.WriteEndElement();

                    writer.WriteEndElement();
                }
                writer.WriteEndElement();
                #endregion

                writer.WriteEndElement();
            }
            writer.WriteEndElement();
            #endregion

            // Matches
            writer.WriteStartElement("matches");
            foreach (MatchSet ms in RulesCollection.getMatchSets())
            {
            }
            writer.WriteEndElement();
            // ActionSets

            #region actionsets
            writer.WriteStartElement("actionsets");
            foreach (ActionSet a in RulesCollection.getActionSets())
            {
                writer.WriteStartElement("actionset");

                //Actionset Name
                writer.WriteStartElement("name");
                writer.WriteValue(a.name);
                writer.WriteEndElement();


                #region actions
                writer.WriteStartElement("actions");
                foreach (Action action in a.actions)
                {
                    writer.WriteStartElement("action");

                    if (action is copyAction)
                    {
                        //kind
                        writer.WriteStartElement("kind");
                        writer.WriteValue("copy");
                        writer.WriteEndElement();

                        //destination
                        writer.WriteStartElement("destination");
                        writer.WriteValue(((copyAction)action).destination);
                        writer.WriteEndElement();
                    }
                    else if (action is moveAction)
                    {
                        //kind
                        writer.WriteStartElement("kind");
                        writer.WriteValue("move");
                        writer.WriteEndElement();

                        //destination
                        writer.WriteStartElement("destination");
                        writer.WriteValue(((moveAction)action).destination);
                        writer.WriteEndElement();
                    }
                    else if (action is cmdAction)
                    {
                        //kind
                        writer.WriteStartElement("kind");
                        writer.WriteValue("cmd");
                        writer.WriteEndElement();

                        //destination
                        writer.WriteStartElement("command");
                        writer.WriteValue(((cmdAction)action).command);
                        writer.WriteEndElement();
                    }

                    writer.WriteEndElement();
                }
                writer.WriteEndElement();
                #endregion

                writer.WriteEndElement();
            }
            writer.WriteEndElement();
            #endregion

            //writer.WriteStartElement("Person");
            //writer.WriteAttributeString("Name", "Nick");
            //writer.WriteEndElement();

            //writer.WriteStartAttribute("Name");
            //writer.WriteValue("Nick");
            //writer.WriteEndAttribute();

            writer.WriteEndElement();
            writer.WriteEndDocument();
            writer.Flush();

        }
    }
}
