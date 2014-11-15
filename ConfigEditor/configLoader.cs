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

        public static List<string> matchArray(string path)
        {
            var doc = XDocument.Load(path);

            var services = from service in doc.Descendants("folder")
                           select (string)service.Attribute("matchsetname");

            return services.ToList();
        }

        public RulesCollection getRules(string path)
        {
            RulesCollection collection = new RulesCollection();
            objDoc.Load(path);
            XmlNodeList elemList = objDoc.GetElementsByTagName("folder");
            foreach (XmlNode element in elemList)
            {
                collection.folderCollection.Add(element.SelectSingleNode("path").InnerXml);
                    foreach (XmlNode child in element.SelectSingleNode("rulesets"))
                    {
                        collection.matchsetCollection.Add(child.SelectSingleNode("matchsetname").InnerXml);
                        collection.actionsetCollection.Add(child.SelectSingleNode("actionsetname").InnerXml);
                    }
            }
            return collection;
            
        }
    }
}
