using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace PleskXmlApi_1_6_9_1.Models
{
    public class IpAddress
    {
        public string Address { get; set; }
        public string NetMask { get; set; }
        public string Type { get; set; }
        public string Interface { get; set; }
        public string PublicAddress { get; set; }

        public static List<IpAddress> FromGetDocument(XmlDocument document)
        {
            var retval = new List<IpAddress>();
            var nodes = document.SelectNodes("//ip_info");
            for (int i = 0; i < nodes.Count; i++)
            {
                var item = new IpAddress();
                item.Address = nodes[i].SelectSingleNode("//ip_address")?.InnerText;
                item.NetMask = nodes[i].SelectSingleNode("//netmask")?.InnerText;
                item.Type = nodes[i].SelectSingleNode("//type")?.InnerText;
                item.Interface = nodes[i].SelectSingleNode("//interface")?.InnerText;
                item.PublicAddress = nodes[i].SelectSingleNode("//public_ip_address")?.InnerText;
                retval.Add(item);
            }
            
            return retval;
        }
    }
}
