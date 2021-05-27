using System;
using System.Collections.Generic;
using System.Text;

namespace PleskXmlApi_1_6_9_1.Models
{
    public class Webspace
    {
        public Webspace_General General { get; set; }
        public Webspace_Hosting Hosting { get; set; }
        public Webspace_Preferences Preferences { get; set; }
        public Webspace_Mail Mail { get; set; }
        public string PlanName { get; set; }

        public class Webspace_General
        {
            public string Name { get; set; }
            public int? OwnerId { get; set; }
            public string HostingType { get; set; }
            public string IpAddress { get; set; }
            public int? Status { get; set; }
        }

        public class Webspace_Hosting
        {
            public Virtual_Host VirtualHost { get; set; }

            public class Virtual_Host
            {
                public Dictionary<string, string> Properties { get; set; }
                public string IpAddress { get; set; }
            }
        }

        public class Webspace_Preferences
        {
            public bool? WWW { get; set; }
            //public int? StatTtl { get; set; } //todo change by enum
        }

        public class Webspace_Mail
        {
            public bool? MailService { get; set; }
        }

        [Flags]
        public enum DataSets
        {
            Gen_Info = 0,
            Hosting = 1,
            HostingBasic = 2,
            Limits = 4,
            Statistics = 8,
            Preferences = 16,
            DiskUsage = 32,
            Performance = 64,
            Subscriptions = 128,
            Permissions = 256,
            PlanItems = 512,
            PhpSettings = 1024,
            ResourceUsage = 2048,
            Mail = 4096,
            ApsFilter = 8192,
            Packages = 16384
        }

        public class Filter
        {
            public int? Id { get; set; }
            public int? OwnerId { get; set; }
            public string Name { get; set; }
            public string OwnerLogin { get; set; }
            public string Guid { get; set; }
            public string OwnerGuid { get; set; }
            public string ExternalId { get; set; }
            public string OwnerExternalId { get; set; }
        }
    }
}
