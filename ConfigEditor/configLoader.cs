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
    public class configLoader
    {
        XmlDocument document = new XmlDocument();
        public void getConfig()
        {
            document.Load(ConfigHandler.getSource());
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
            string kind = document.DocumentElement.SelectSingleNode(xpath+ "/kind").InnerText;
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
                        andRule.add(getMatch(xpath + "/matches/match["+i+"]"));
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
    }
}
