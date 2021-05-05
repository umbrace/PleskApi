using System;
using System.Xml;
using PleskXmlApi_1_6_9_1.Extensions;

namespace PleskXmlApi_1_6_9_1.XmlModels
{
    public class Site
    {
        #region Get
        private static XmlDocument Get()
        {
            var retval = new XmlDocument();
            retval.LoadXml(@"<packet>
<site>
    <get>
       <filter/>
       <dataset/>
    </get>
</site>
</packet>");
            return retval;
        }

        public static XmlDocument Get(Models.Site.DataSets dataSets, Models.Site.Filter filter = null)
        {
            var siteRequest = Get();
            ApplyDataSets(siteRequest, dataSets);
            ApplyFilter(siteRequest, filter);
            return siteRequest;
        }

        private static void ApplyDataSets(XmlDocument document, Models.Site.DataSets dataSets)
        {
            var dataSetsTag = document.GetElementsByTagName("dataset")[0];
            if (dataSets.HasFlag(Models.Site.DataSets.Gen_Info))
            {
                dataSetsTag.AppendChild(document.CreateElement("gen_info"));
            }
            if (dataSets.HasFlag(Models.Site.DataSets.Hosting))
            {
                dataSetsTag.AppendChild(document.CreateElement("hosting"));
            }
            if (dataSets.HasFlag(Models.Site.DataSets.Stat))
            {
                dataSetsTag.AppendChild(document.CreateElement("stat"));
            }
            if (dataSets.HasFlag(Models.Site.DataSets.Prefs))
            {
                dataSetsTag.AppendChild(document.CreateElement("prefs"));
            }
            if (dataSets.HasFlag(Models.Site.DataSets.DiskUsage))
            {
                dataSetsTag.AppendChild(document.CreateElement("disk_usage"));
            }
            if (dataSets.HasFlag(Models.Site.DataSets.Performance))
            {
                dataSetsTag.AppendChild(document.CreateElement("performance"));
            }
        }

        private static void ApplyFilter(XmlDocument document, Models.Site.Filter filter)
        {
            if (filter == null)
            {
                return;
            }

            if (filter.Id != null)
            {
                document.AppendTagWithValue("filter", "id", filter.Id.Value);
            }
            if (filter.ParentId != null)
            {
                document.AppendTagWithValue("filter", "parent-id", filter.ParentId.Value);
            }
            if (filter.ParentSideId != null)
            {
                document.AppendTagWithValue("filter", "parent-side-id", filter.ParentSideId.Value);
            }
            if (filter.Name.IsNotNullOrWhiteSpace())
            {
                document.AppendTagWithValue("filter", "name", filter.Name);
            }
            if (filter.ParentName.IsNotNullOrWhiteSpace())
            {
                document.AppendTagWithValue("filter", "parent-name", filter.ParentName);
            }
            if (filter.ParentSiteName.IsNotNullOrWhiteSpace())
            {
                document.AppendTagWithValue("filter", "parent-site-name", filter.ParentSiteName);
            }
            if (filter.Guid.IsNotNullOrWhiteSpace())
            {
                document.AppendTagWithValue("filter", "guid", filter.Guid);
            }
            if (filter.ParentGuid.IsNotNullOrWhiteSpace())
            {
                document.AppendTagWithValue("filter", "parent-guid", filter.ParentGuid);
            }
            if (filter.ParentSiteGuid.IsNotNullOrWhiteSpace())
            {
                document.AppendTagWithValue("filter", "parent-site-guid", filter.ParentSiteGuid);
            }
        }
        #endregion

        #region Create
        private static XmlDocument Create()
        {
            var retval = new XmlDocument();
            retval.LoadXml(@"<packet>
  <site>
   <add>
    </add>
  </site>
</packet>");
            return retval;
        }

        public static XmlDocument Create(Models.Site site)
        {
            var retval = Create();
            SetGeneral(retval, site.General);
            return retval;
        }

        private static void SetGeneral(XmlDocument document, Models.Site.Site_General general)
        {
            if (general == null)
            {
                return;
            }
            document.AppendTag("add","gen_setup");
            if (general.Name.IsNotNullOrWhiteSpace())
            {
                document.AppendTagWithValue("gen_setup","name",general.Name);
            }

            if (general.WebSpaceId != null)
            {
                document.AppendTagWithValue("gen_setup", "webspace-id", general.WebSpaceId);
            }
            if (general.ParenSiteId != null)
            {
                document.AppendTagWithValue("gen_setup", "parent-site-id", general.ParenSiteId);
            }
        }
        #endregion
    }
}
