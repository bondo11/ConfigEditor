using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace ConfigEditor
{
    public class configLoader
    {

        XmlDocument objDoc = new XmlDocument();
        public void getConfig ()
        {
            //List<string> matchArray = new List<string>();
            objDoc.Load(ConfigHandler.getSource());
            XmlNodeList elemList = objDoc.GetElementsByTagName("folder");
            
            foreach (XmlNode element in elemList)
            {

                Folder f = new Folder(element.SelectSingleNode("path").InnerXml); 
                foreach (XmlNode ruleset in element.SelectNodes("rulesets"))
                {
                    f.rules.Add(new ruleset(getMatchSet(ruleset.SelectSingleNode("ruleset").SelectSingleNode("matchsetname").InnerXml), 
                        getActionSet(ruleset.SelectSingleNode("ruleset").SelectSingleNode("actionsetname").InnerXml)));
                    
                    
                    //getMatchSet(ruleset.SelectSingleNode("ruleset").SelectSingleNode("matchsetname").InnerXml);
                    //matchArray.Add(ruleset.SelectSingleNode("ruleset").SelectSingleNode("matchsetname").InnerXml);

                    
                }
                RulesCollection.Folders.Add(f);
            }
        }

        private match getMatchSet(string MatchSetName)
        {
            objDoc.Load(ConfigHandler.getSource());
            XmlNodeList elemList = objDoc.GetElementsByTagName("matches");
            match m = new match();
            foreach (XmlNode element in elemList)
            {
                if(element.SelectSingleNode("match").SelectSingleNode("name").InnerXml.Equals(MatchSetName))
                {
                    m.Name = element.SelectSingleNode("match").SelectSingleNode("name").InnerXml;
                }

            }
            return m;
        }

        private List<Action> getActionSet(string ActionName)
        {
            objDoc.Load(ConfigHandler.getSource());
            XmlNodeList elemList = objDoc.GetElementsByTagName("actionsets");
            match m = new match();
            foreach (XmlNode element in elemList)
            {
                if (element.SelectSingleNode("actionsets").SelectSingleNode("name").InnerXml.Equals(ActionName))
                {

                    m.Name = element.SelectSingleNode("match").SelectSingleNode("name").InnerXml;
                }

            }
            return new List<Action>();
        }


        public List<string> matchArray(string path, Folder folder)
        {
            List<string> matchArray = new List<string>();
            objDoc.Load(path);
            XmlNodeList elemList = objDoc.GetElementsByTagName("folder");
            foreach (XmlNode element in elemList)
            {
                if (element.SelectSingleNode("path").InnerXml.Equals(folder.Path))
                {
                    foreach (XmlNode ruleset in element.SelectSingleNode("rulesets").SelectNodes("ruleset"))
                    {
                        matchArray.Add(ruleset.SelectSingleNode("matchsetname").InnerXml);
                    }
                }
            }
            return matchArray;
        }
        public List<string> matchArray()
        {
            List<string> matchArray = new List<string>();
            objDoc.Load(ConfigHandler.getSource());
            XmlNodeList elemList = objDoc.GetElementsByTagName("folder");
            foreach (XmlNode element in elemList)
            {
                foreach (XmlNode ruleset in element.SelectNodes("rulesets"))
                {
                    matchArray.Add(ruleset.SelectSingleNode("ruleset").SelectSingleNode("matchsetname").InnerXml);
                }
            }
            return matchArray;
        }

        /*
        public RulesCollection getRules(string path)
        {
            RulesCollection collection = new RulesCollection();
            objDoc.Load(path);
            XmlNodeList elemList = objDoc.GetElementsByTagName("folder");
            foreach (XmlNode element in elemList)
            {
                collection.folderCollection.Add(element.SelectSingleNode("path").InnerXml);
            }
            elemList = objDoc.GetElementsByTagName("match");
            foreach (XmlNode element in elemList)
            {
                collection.matchsetCollection.Add(element.SelectSingleNode("name").InnerXml);
            }
            elemList = objDoc.GetElementsByTagName("actionset");
            foreach (XmlNode element in elemList)
            {
                collection.actionsetCollection.Add(element.SelectSingleNode("name").InnerXml);
            }
            return collection;
            
        }*/
    }
}
