using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Xml;

namespace BanksLogic._03_XML
{
    class MainLogic
    {
        string URL;

        List<string> result = new List<string>();

        public MainLogic(string _url) => URL = _url;

        public void GetData()
        {
            var Data = GetDataInURL();

            XmlDocument xDoc = new XmlDocument();
            try
            {
                xDoc.LoadXml(Data);
                XmlElement xRoot = xDoc.DocumentElement;
                IteratorListXML(xRoot.ChildNodes);
            }
            catch
            {
                //var json = JsonSerializer.Deserialize<Belarusbank>(data);
            }
        }

        public string GetDataInURL()
        {
            using (var Client = new WebClient { Encoding = Encoding.Default }) return Client.DownloadString(URL);
        }

        private void IteratorListXML(XmlNodeList data)
        {
            foreach (XmlNode node in data)
            {
                if (node.HasChildNodes) this.IteratorListXML(node.ChildNodes);
                else
                {
                    if (node.OuterXml.Contains('<'))
                    {
                        result.AddRange(ReadOuterXml(node.OuterXml));
                        continue;
                    } 
                    result.Add($"{node.ParentNode.Name}={node.InnerText}");
                }
            }
        }

        private List<string> ReadOuterXml(string line)
        {
            List<string> result = new List<string>();

            string[] parts = line.Split(' ');
            foreach (string p in parts)
            {
                if (p.Contains('=')) result.Add(p.Replace('"', ' '));
            }
            return result;
        }
    }
}
