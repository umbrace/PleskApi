using System;
using System.Collections.Generic;
using System.Text;

namespace PleskXmlApi_1_6_9_1.Models
{
    public class Site
    {
        public Site_General General { get; set; }

        public class Site_General
        {
            public string Name { get; set; }
            public int? ParenSiteId { get; set; }
            public int? WebSpaceId { get; set; }
        }

        [Flags]
        public enum DataSets
        {
            Gen_Info = 0,
            Hosting = 1,
            Stat = 2,
            Prefs = 4,
            DiskUsage = 8,
            Performance = 16
        }

        public class Filter
        {
            public int? Id { get; set; }
            public int? ParentId { get; set; }
            public int? ParentSideId { get; set; }
            public string Name { get; set; }
            public string ParentName { get; set; }
            public string ParentSiteName { get; set; }
            public string Guid { get; set; }
            public string ParentGuid { get; set; }
            public string ParentSiteGuid { get; set; }
        }
    }
}
