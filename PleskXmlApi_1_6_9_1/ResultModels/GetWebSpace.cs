using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace PleskXmlApi_1_6_9_1.ResultModels
{
    public class GetWebSpace : Identity
    {
        public GetWebSpaceHosting_Hosting Hosting { get; set; }
        public GetWebSpace(XmlDocument document) : base(document, "//webspace/get/result")
        {
            if (base.IsSuccess() == false)
            {
                return;
            }

            if (base.ProcessIsSuccess(document) == false)
            {
                return;
            }

            base.SetFields(document);
            Setfields(document);
        }

        private void Setfields(XmlDocument document)
        {
            Hosting = new GetWebSpaceHosting_Hosting
            {
                VirtualHosting = new GetWebSpaceHosting_Hosting.GetWebSpaceHosting_VirtualHosting
                {
                    IpAddress = document.SelectSingleNode(BaseXpath + "/data/hosting/vrt_hst/ip_address")?.InnerText,
                    Properties = new Dictionary<string, string>()
                }
            };
            var propertyNodes = document.SelectNodes(BaseXpath + "/data/hosting/vrt_hst/property");

            for (int i = 0; i < propertyNodes.Count; i++)
            {
                Hosting.VirtualHosting.Properties.Add(propertyNodes[i].SelectSingleNode("name").InnerText ,propertyNodes[i].SelectSingleNode("value").InnerText);
            }
        }

        public class GetWebSpaceHosting_Hosting
        {
            public GetWebSpaceHosting_VirtualHosting VirtualHosting { get; set; }

            public class GetWebSpaceHosting_VirtualHosting
            {
                public string IpAddress { get; set; }
                public Dictionary<string,string> Properties { get; set; }
            }
        }
    }
}
