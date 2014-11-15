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

        public List<string> matchArray(string path, string folder)
        {
            List<string> matchArray = new List<string>();
            objDoc.Load(path);
            XmlNodeList elemList = objDoc.GetElementsByTagName("folder");
            foreach (XmlNode element in elemList)
            {
                if (element.SelectSingleNode("path").InnerXml.Equals(folder))
                {
                    foreach (XmlNode ruleset in element.SelectSingleNode("rulesets").SelectNodes("ruleset"))
                    {
                        matchArray.Add(ruleset.SelectSingleNode("matchsetname").InnerXml);
                    }
                }
            }
            return matchArray;
        }
        public List<string> matchArray(string path)
        {
            List<string> matchArray = new List<string>();
            objDoc.Load(path);
            XmlNodeList elemList = objDoc.GetElementsByTagName("folder");
            foreach (XmlNode element in elemList)
            {
                foreach (XmlNode ruleset in element.SelectNodes("rulesets"))
                {
                    matchArray.Add(ruleset.SelectSingleNode("ruleset").SelectSingleNode("matchsetname").InnerXml);
                }
                //matchArray.Add(element.SelectSingleNode("rulesets").SelectSingleNode("ruleset").SelectSingleNode("matchsetname").InnerXml);
            }
            return matchArray;
        }


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
            
        }
    }
}
