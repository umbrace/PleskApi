using System.Collections.Generic;
using System.Xml;

namespace PleskXmlApi_1_6_9_1.Extensions
{
    public static class XmlDocumentExtensions
    {
        /// <summary>
        /// Appends a new Tag with value to the first ParentTagName found
        /// </summary>
        /// <param name="document"></param>
        /// <param name="parentTagName"></param>
        /// <param name="tagName"></param>
        /// <param name="value"></param>
        public static XmlNode AppendTagWithValue(this XmlDocument document, string parentTagName, string tagName, object value)
        {
            var newTag = document.CreateElement(tagName);
            
            newTag.InnerText = value.ToString();
            document.GetElementsByTagName(parentTagName)[0].AppendChild(newTag);

            return newTag;
        }

        public static XmlNode AppendTag(this XmlDocument document, string parentTagName, string tagName)
        {
            var newTag = document.CreateElement(tagName);

            document.GetElementsByTagName(parentTagName)[0].AppendChild(newTag);

            return newTag;
        }

        public static XmlNode AppendKeyValuePair(this XmlDocument document, string parentXpath, KeyValuePair<string, string> pair, string pairName, string keyName, string valueName)
        {
            var parent = document.SelectSingleNode(parentXpath);
            if (parent == null)
            {
                return null;
            }

            return document.AppendKeyValuePair(parent, pair, pairName, keyName, valueName);
        }

        public static XmlNode AppendKeyValuePair(this XmlDocument document, XmlNode parent, KeyValuePair<string, string> pair, string pairName, string keyName, string valueName)
        {
            if (parent == null)
            {
                return null;
            }
            var pairTag = document.CreateElement(pairName);
            var keyTag = document.CreateElement(keyName);
            var valueTag = document.CreateElement(valueName);
            keyTag.InnerText = pair.Key;
            valueTag.InnerText = pair.Value;
            pairTag.AppendChild(keyTag);
            pairTag.AppendChild(valueTag);
            parent.AppendChild(pairTag);

            return pairTag;
        }
    }
}
