using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using PleskXmlApi_1_6_9_1.Extensions;

namespace PleskXmlApi_1_6_9_1.XmlModels
{

    public class SiteAlias
    {
        private static XmlDocument GetPacket()
        {
            var retval = new XmlDocument();
            retval.LoadXml(@"<packet>
<site-alias>
   <get>
    <filter/>
   </get>
</site-alias>
</packet>");
            return retval;
        }

        public static XmlDocument Get(Models.SiteAlias.Filter filter = null)
        {
            var siteRequest = GetPacket();
            ApplyFilter(siteRequest, filter);
            return siteRequest;
        }

        private static void ApplyFilter(XmlDocument document, Models.SiteAlias.Filter filter)
        {
            if (filter == null)
            {
                return;
            }

            if (filter.Id != null)
            {
                document.AppendTagWithValue("filter", "id", filter.Id.Value);
            }
            if (filter.Name.IsNotNullOrWhiteSpace())
            {
                document.AppendTagWithValue("filter", "name", filter.Name);
            }
            if (filter.SiteId != null)
            {
                document.AppendTagWithValue("filter", "site-id", filter.SiteId.Value);
            }
            if (filter.SiteName.IsNotNullOrWhiteSpace())
            {
                document.AppendTagWithValue("filter", "site-name", filter.SiteName);
            }
        }

        private static XmlDocument Create()
        {
            var retval = new XmlDocument();
            retval.LoadXml(@"<packet>
<site-alias>
    <create>
    </create>
  </site-alias>
</packet>");
            return retval;
        }

        public static XmlDocument Create(Models.SiteAlias siteAlias)
        {
            var document = Create();
            AddPreferences(document, siteAlias);
            AddGeneral(document, siteAlias);
            return document;
        }

        private static void AddGeneral(XmlDocument document, Models.SiteAlias siteAlias)
        {
            if (siteAlias.ManageDns.HasValue)
            {
                document.AppendTagWithValue("create", "manage-dns", siteAlias.ManageDns.Value ? "true" : "false");
            }
            document.AppendTagWithValue("create", "site-id", siteAlias.SiteId);
            document.AppendTagWithValue("create", "name", siteAlias.Name);
            document.AppendTagWithValue("create", "ascii-name", siteAlias.AsciiName.IsNotNullOrWhiteSpace() ? siteAlias.AsciiName : siteAlias.Name);
        }

        private static void AddPreferences(XmlDocument document, Models.SiteAlias siteAlias)
        {
            if (siteAlias.Preferences == null)
            {
                return;
            }
            document.AppendTag("create", "pref");
            if (siteAlias.Preferences.Web.HasValue)
            {
                document.AppendTagWithValue("pref", "web", siteAlias.Preferences.Web.Value ? "true": "false");
            }
            if (siteAlias.Preferences.Mail.HasValue)
            {
                document.AppendTagWithValue("pref", "mail", siteAlias.Preferences.Mail.Value ? "true" : "false");
            }
            if (siteAlias.Preferences.SeoRedirect.HasValue)
            {
                document.AppendTagWithValue("pref", "seo-redirect", siteAlias.Preferences.SeoRedirect.Value ? "true" : "false");
            }
            if (siteAlias.Preferences.IcpStatus.HasValue)
            {
                document.AppendTagWithValue("pref", "icp-status", siteAlias.Preferences.IcpStatus.Value ? "true" : "false");
            }
        }
    }
}
