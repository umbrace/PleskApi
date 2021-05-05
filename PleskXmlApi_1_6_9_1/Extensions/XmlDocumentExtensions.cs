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
        public static void AppendTagWithValue(this XmlDocument document, string parentTagName, string tagName, object value)
        {
            var temp = document.GetElementsByTagName(parentTagName)[0];

            var newTag = document.CreateElement(tagName);
            
            newTag.InnerText = value.ToString();
            document.GetElementsByTagName(parentTagName)[0].AppendChild(newTag);
        }

        public static void AppendTag(this XmlDocument document, string parentTagName, string tagName)
        {
            var temp = document.GetElementsByTagName(parentTagName)[0];

            var newTag = document.CreateElement(tagName);

            document.GetElementsByTagName(parentTagName)[0].AppendChild(newTag);
        }
    }
}
