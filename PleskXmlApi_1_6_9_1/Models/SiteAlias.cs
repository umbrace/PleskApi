using System;
using System.Collections.Generic;
using System.Text;

namespace PleskXmlApi_1_6_9_1.Models
{
    public class SiteAlias
    {
        public SiteAlias_Preferences Preferences { get; set; }
        public bool? ManageDns { get; set; }
        public int SiteId { get; set; }
        public string Name { get; set; }
        public string AsciiName { get; set; }

        public class SiteAlias_Preferences
        {
            public bool? Web { get; set; }
            public bool? Mail { get; set; }
            public bool? SeoRedirect { get; set; }
            public bool? IcpStatus { get; set; }
        }

        public class Filter
        {
            public int? Id { get; set; }
            public string Name { get; set; }
            public int? SiteId { get; set; }
            public string SiteName { get; set; }
        }
    }
}
