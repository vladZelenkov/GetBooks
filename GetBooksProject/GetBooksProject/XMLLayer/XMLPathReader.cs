using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace GetBooksProject.XMLLayer
{
    class XMLPathReader
    {
        private XmlDocument _file;
        private string _fileName;
        private static XMLPathReader _instance;

        private XMLPathReader(string XMLFileName)
        {
            _file = new XmlDocument();
            _fileName = XMLFileName;

            try
            {
                _file.Load(_fileName);
            }
            catch (XmlException)
            {
                throw;
            }
        }

        public static XMLPathReader GetInstance()
        {
            if (_instance == null)
            {
                _instance = new XMLPathReader("Pathes.xml");
            }

            return _instance;
        }

        public string GetPath(string tagName)
        {
            XmlElement root = _file.DocumentElement;
            XmlNodeList tags = root.ChildNodes;

            foreach (XmlNode node in tags)
            {
                if (node.Name == tagName)
                {
                    try
                    {
                        return node.InnerXml;
                    }
                    catch (Exception e)
                    {
                        throw e;
                    }
                }
            }

            throw new Exception($"{_fileName} не содержит тэга {tagName}");
        }
    }
}
