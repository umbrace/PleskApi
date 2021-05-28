using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace PleskXmlApi_1_6_9_1.Models
{
    public class DbServer
    {
        public int Id { get; set; }
        public string Host { get; set; }
        public int? Port { get; set; }
        public string Type { get; set; }
        public string Admin { get; set; }
        public int DbNum { get; set; }

        public static List<DbServer> FromGetDocument(XmlDocument document)
        {
            var retval = new List<DbServer>();
            var nodes = document.SelectNodes("//result");
            for (int i = 0; i < nodes.Count; i++)
            {
                var item = new DbServer();
                item.Id = int.Parse(nodes[i].SelectSingleNode("id")?.InnerText);
                item.Host = nodes[i].SelectSingleNode("data/host")?.InnerText;
                var portData = nodes[i].SelectSingleNode("data//port")?.InnerText;
                item.Port = portData == null ? null : (int?)int.Parse(portData);
                item.Port = portData == null ? null : (int?)int.Parse(portData);
                item.Type = nodes[i].SelectSingleNode("data//type")?.InnerText;
                item.Admin = nodes[i].SelectSingleNode("data//admin")?.InnerText;
                item.DbNum = int.Parse(nodes[i].SelectSingleNode("data//db_num")?.InnerText);
                retval.Add(item);
            }

            return retval;
        }
    }
}
