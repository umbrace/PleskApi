using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using PleskXmlApi_1_6_9_1.Extensions;

namespace PleskXmlApi_1_6_9_1.XmlModels
{

    public class Customer
    {
        private static XmlDocument Get()
        {
            var retval = new XmlDocument();
            retval.LoadXml(@"<packet>
<customer>
   <get>
    <filter/>
    <dataset/>
   </get>
</customer>
</packet>");
            return retval;
        }

        public static XmlDocument Get(Models.Customer.DataSets dataSets, Models.Customer.Filter filter = null)
        {
            var siteRequest = Get();
            ApplyDataSets(siteRequest, dataSets);
            ApplyFilter(siteRequest, filter);
            return siteRequest;
        }

        private static void ApplyDataSets(XmlDocument document, Models.Customer.DataSets dataSets)
        {
            var dataSetsTag = document.GetElementsByTagName("dataset")[0];
            if (dataSets.HasFlag(Models.Customer.DataSets.Gen_Info))
            {
                dataSetsTag.AppendChild(document.CreateElement("gen_info"));
            }
            if (dataSets.HasFlag(Models.Customer.DataSets.Statistics))
            {
                dataSetsTag.AppendChild(document.CreateElement("stat"));
            }
        }

        private static void ApplyFilter(XmlDocument document, Models.Customer.Filter filter)
        {
            if (filter == null)
            {
                return;
            }

            if (filter.Id != null)
            {
                document.AppendTagWithValue("filter", "id", filter.Id.Value);
            }
            if (filter.Login.IsNotNullOrWhiteSpace())
            {
                document.AppendTagWithValue("filter", "login", filter.Login);
            }
            if (filter.OwnerId != null)
            {
                document.AppendTagWithValue("filter", "owner-id", filter.OwnerId);
            }
            if (filter.OwnerLogin.IsNotNullOrWhiteSpace())
            {
                document.AppendTagWithValue("filter", "owner-login", filter.OwnerLogin);
            }
            if (filter.Guid.IsNotNullOrWhiteSpace())
            {
                document.AppendTagWithValue("filter", "guid", filter.Guid);
            }
            if (filter.ExternalId.IsNotNullOrWhiteSpace())
            {
                document.AppendTagWithValue("filter", "external-id", filter.ExternalId);
            }
        }

        private static XmlDocument Create()
        {
            var retval = new XmlDocument();
            retval.LoadXml(@"<packet>
<customer>
<add>
    <gen_info>
    </gen_info>
</add>
</customer>
</packet>");
            return retval;
        }

        public static XmlDocument Create(Models.Customer customer)
        {
            if (customer?.General == null)
            {
                return null;
            }

            var document = Create();

            if (customer.General.CName.IsNotNullOrWhiteSpace())
            {
                document.AppendTagWithValue("gen_info", "cname", customer.General.CName);
            }
            if (customer.General.PName.IsNotNullOrWhiteSpace())
            {
                document.AppendTagWithValue("gen_info", "pname", customer.General.PName);
            }
            if (customer.General.Login.IsNotNullOrWhiteSpace())
            {
                document.AppendTagWithValue("gen_info", "login", customer.General.Login);
            }
            if (customer.General.Password.IsNotNullOrWhiteSpace())
            {
                document.AppendTagWithValue("gen_info", "passwd", customer.General.Password);
            }
            if (customer.General.Phone.IsNotNullOrWhiteSpace())
            {
                document.AppendTagWithValue("gen_info", "phone", customer.General.Phone);
            }
            if (customer.General.Fax.IsNotNullOrWhiteSpace())
            {
                document.AppendTagWithValue("gen_info", "fax", customer.General.Fax);
            }
            if (customer.General.Email.IsNotNullOrWhiteSpace())
            {
                document.AppendTagWithValue("gen_info", "email", customer.General.Email);
            }
            if (customer.General.Address.IsNotNullOrWhiteSpace())
            {
                document.AppendTagWithValue("gen_info", "address", customer.General.Address);
            }
            if (customer.General.City.IsNotNullOrWhiteSpace())
            {
                document.AppendTagWithValue("gen_info", "city", customer.General.City);
            }
            if (customer.General.State.IsNotNullOrWhiteSpace())
            {
                document.AppendTagWithValue("gen_info", "state", customer.General.State);
            }
            if (customer.General.PostCode.IsNotNullOrWhiteSpace())
            {
                document.AppendTagWithValue("gen_info", "pcode", customer.General.PostCode);
            }
            if (customer.General.Country.IsNotNullOrWhiteSpace())
            {
                document.AppendTagWithValue("gen_info", "country", customer.General.Country);
            }
            if (customer.General.Locale.IsNotNullOrWhiteSpace())
            {
                document.AppendTagWithValue("gen_info", "locale", customer.General.Locale);
            }

            if (customer.General.OwnerId != null)
            {
                document.AppendTagWithValue("gen_info", "owner-id", customer.General.OwnerId.Value);
            }
            else if (customer.General.OwnerLogin.IsNotNullOrWhiteSpace())
            {
                document.AppendTagWithValue("gen_info", "owner-login", customer.General.OwnerLogin);
            }
            else if (customer.General.OwnerExternalId.IsNotNullOrWhiteSpace())
            {
                document.AppendTagWithValue("gen_info", "owner-external-id", customer.General.OwnerExternalId);
            }

            if (customer.General.ExternalId.IsNotNullOrWhiteSpace())
            {
                document.AppendTagWithValue("gen_info", "external-id", customer.General.ExternalId);
            }
            if (customer.General.Description.IsNotNullOrWhiteSpace())
            {
                document.AppendTagWithValue("gen_info", "description", customer.General.Description);
            }

            return document;
        }
    }
}
