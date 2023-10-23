using GetBooksProject.Properties;
using System;
using System.Xml;

namespace GetBooksProject.XMLLayer
{
    class XMLPathReader
    {
        private XmlDocument _file;
        private static XMLPathReader _instance;

        private XMLPathReader()
        {
            _file = new XmlDocument();

            try
            {
                _file.LoadXml(Resources.Pathes);
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
                _instance = new XMLPathReader();
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

            throw new Exception($"Файл не содержит тэга {tagName}");
        }
    }
}
