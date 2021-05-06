using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using PleskXmlApi_1_6_9_1.Extensions;

namespace PleskXmlApi_1_6_9_1.XmlModels
{

    public class Webspace
    {
        private static XmlDocument Get()
        {
            var retval = new XmlDocument();
            retval.LoadXml(@"<packet>
<webspace>
   <get>
    <filter/>
    <dataset/>
   </get>
</webspace>
</packet>");
            return retval;
        }

        public static XmlDocument Get(Models.Webspace.DataSets dataSets, Models.Webspace.Filter filter = null)
        {
            var siteRequest = Get();
            ApplyDataSets(siteRequest, dataSets);
            ApplyFilter(siteRequest, filter);
            return siteRequest;
        }

        private static void ApplyDataSets(XmlDocument document, Models.Webspace.DataSets dataSets)
        {
            var dataSetsTag = document.GetElementsByTagName("dataset")[0];
            if (dataSets.HasFlag(Models.Webspace.DataSets.Gen_Info))
            {
                dataSetsTag.AppendChild(document.CreateElement("gen_info"));
            }
            if (dataSets.HasFlag(Models.Webspace.DataSets.Hosting))
            {
                dataSetsTag.AppendChild(document.CreateElement("hosting"));
            }
            if (dataSets.HasFlag(Models.Webspace.DataSets.HostingBasic))
            {
                dataSetsTag.AppendChild(document.CreateElement("hosting-basic"));
            }
            if (dataSets.HasFlag(Models.Webspace.DataSets.Limits))
            {
                dataSetsTag.AppendChild(document.CreateElement("limits"));
            }
            if (dataSets.HasFlag(Models.Webspace.DataSets.Statistics))
            {
                dataSetsTag.AppendChild(document.CreateElement("stat"));
            }
            if (dataSets.HasFlag(Models.Webspace.DataSets.Preferences))
            {
                dataSetsTag.AppendChild(document.CreateElement("pref"));
            }
            if (dataSets.HasFlag(Models.Webspace.DataSets.DiskUsage))
            {
                dataSetsTag.AppendChild(document.CreateElement("disk_usage"));
            }
            if (dataSets.HasFlag(Models.Webspace.DataSets.Performance))
            {
                dataSetsTag.AppendChild(document.CreateElement("performance"));
            }
            if (dataSets.HasFlag(Models.Webspace.DataSets.Subscriptions))
            {
                dataSetsTag.AppendChild(document.CreateElement("subscriptions"));
            }
            if (dataSets.HasFlag(Models.Webspace.DataSets.Permissions))
            {
                dataSetsTag.AppendChild(document.CreateElement("permissions"));
            }
            if (dataSets.HasFlag(Models.Webspace.DataSets.PlanItems))
            {
                dataSetsTag.AppendChild(document.CreateElement("plan-items"));
            }
            if (dataSets.HasFlag(Models.Webspace.DataSets.PhpSettings))
            {
                dataSetsTag.AppendChild(document.CreateElement("php-settings"));
            }
            if (dataSets.HasFlag(Models.Webspace.DataSets.ResourceUsage))
            {
                dataSetsTag.AppendChild(document.CreateElement("resource-usage"));
            }
            if (dataSets.HasFlag(Models.Webspace.DataSets.Mail))
            {
                dataSetsTag.AppendChild(document.CreateElement("mail"));
            }
            if (dataSets.HasFlag(Models.Webspace.DataSets.ApsFilter))
            {
                dataSetsTag.AppendChild(document.CreateElement("aps-filter"));
            }
            if (dataSets.HasFlag(Models.Webspace.DataSets.Packages))
            {
                dataSetsTag.AppendChild(document.CreateElement("packages"));
            }
        }

        private static void ApplyFilter(XmlDocument document, Models.Webspace.Filter filter)
        {
            if (filter == null)
            {
                return;
            }

            if (filter.Id != null)
            {
                document.AppendTagWithValue("filter", "id", filter.Id.Value);
            }
            if (filter.OwnerId != null)
            {
                document.AppendTagWithValue("filter", "owner-id", filter.OwnerId.Value);
            }
            if (filter.Name.IsNotNullOrWhiteSpace())
            {
                document.AppendTagWithValue("filter", "name", filter.Name);
            }
            if (filter.OwnerLogin.IsNotNullOrWhiteSpace())
            {
                document.AppendTagWithValue("filter", "owner-login", filter.OwnerLogin);
            }
            if (filter.Guid.IsNotNullOrWhiteSpace())
            {
                document.AppendTagWithValue("filter", "guid", filter.Guid);
            }
            if (filter.OwnerGuid.IsNotNullOrWhiteSpace())
            {
                document.AppendTagWithValue("filter", "owner-guid", filter.OwnerGuid);
            }
            if (filter.ExternalId.IsNotNullOrWhiteSpace())
            {
                document.AppendTagWithValue("filter", "external-id", filter.ExternalId);
            }
            if (filter.OwnerExternalId.IsNotNullOrWhiteSpace())
            {
                document.AppendTagWithValue("filter", "owner-external-id", filter.OwnerExternalId);
            }
        }

        private static XmlDocument Create()
        {
            var retval = new XmlDocument();
            retval.LoadXml(@"<packet>
<webspace>
    <add>
    </add>
  </webspace>
</packet>");
            return retval;
        }

        public static XmlDocument Create(Models.Webspace webspace)
        {
            var document = Create();
            AddGeneral(document,webspace);
            AddHosting(document,webspace);
            if (webspace.PlanName.IsNotNullOrWhiteSpace())
            {
                document.AppendTagWithValue("add", "plan-name", webspace.PlanName);
            }
            return document;
        }

        private static void AddGeneral(XmlDocument document, Models.Webspace webspace)
        {
            if (webspace.General == null)
            {
                return;
            }

            document.AppendTag("add", "gen_setup");
            if (webspace.General.Name.IsNotNullOrWhiteSpace())
            {
                document.AppendTagWithValue("gen_setup", "name", webspace.General.Name);
            }
            if (webspace.General.OwnerId != null)
            {
                document.AppendTagWithValue("gen_setup", "owner-id", webspace.General.OwnerId.Value);
            }
            if (webspace.General.HostingType.IsNotNullOrWhiteSpace())
            {
                document.AppendTagWithValue("gen_setup", "htype", webspace.General.HostingType);
            }
            if (webspace.General.IpAddress.IsNotNullOrWhiteSpace())
            {
                document.AppendTagWithValue("gen_setup", "ip_address", webspace.General.IpAddress);
            }
        }

        private static void AddHosting(XmlDocument document, Models.Webspace webspace)
        {
            if (webspace.Hosting == null)
            {
                return;
            }
            document.AppendTag("add", "hosting");
            var hostingTag = document.AppendTag("hosting", "vrt_hst");
            if (webspace.Hosting.VirtualHost.Properties != null)
            {
                foreach (var property in webspace.Hosting.VirtualHost.Properties)
                {
                    document.AppendKeyValuePair(hostingTag, property, "property", "name", "value");
                }
            }
            if (webspace.Hosting.VirtualHost.IpAddress.IsNotNullOrWhiteSpace())
            {
                document.AppendTagWithValue("vrt_hst", "ip_address", webspace.Hosting.VirtualHost.IpAddress);
            }
        }
    }
}
