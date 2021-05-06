using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace PleskXmlApi_1_6_9_1.Models
{
    public class Customer
    {
        public Customer_General General { get; set; }

        public static Customer FromGetCustomerDocument(XmlDocument document)
        {
            var retval = new Customer();
            retval.General = new Customer_General();

            retval.General.CreateDate = document.SelectSingleNode("//customer//get//result//data/gen_info/cr_date")?.InnerText;
            retval.General.CName = document.SelectSingleNode("//customer//get//result//data/gen_info/cname")?.InnerText;
            retval.General.PName = document.SelectSingleNode("//customer//get//result//data/gen_info/pname")?.InnerText;
            retval.General.Login = document.SelectSingleNode("//customer//get//result//data/gen_info/login")?.InnerText;
            retval.General.State = document.SelectSingleNode("//customer//get//result//data/gen_info/status")?.InnerText;
            retval.General.Phone = document.SelectSingleNode("//customer//get//result//data/gen_info/phone")?.InnerText;
            retval.General.Fax = document.SelectSingleNode("//customer//get//result//data/gen_info/fax")?.InnerText;
            retval.General.Email = document.SelectSingleNode("//customer//get//result//data/gen_info/email")?.InnerText;
            retval.General.Address = document.SelectSingleNode("//customer//get//result//data/gen_info/address")?.InnerText;
            retval.General.City = document.SelectSingleNode("//customer//get//result//data/gen_info/city")?.InnerText;
            retval.General.State = document.SelectSingleNode("//customer//get//result//data/gen_info/state")?.InnerText;
            retval.General.PostCode = document.SelectSingleNode("//customer//get//result//data/gen_info/pcode")?.InnerText;
            retval.General.Country = document.SelectSingleNode("//customer//get//result//data/gen_info/country")?.InnerText;
            retval.General.Locale = document.SelectSingleNode("//customer//get//result//data/gen_info/locale")?.InnerText;
            retval.General.Guid = document.SelectSingleNode("//customer//get//result//data/gen_info/guid")?.InnerText;
            retval.General.OwnerLogin = document.SelectSingleNode("//customer//get//result//data/gen_info/owner-login")?.InnerText;
            retval.General.VendorGuid = document.SelectSingleNode("//customer//get//result//data/gen_info/vendor-guid")?.InnerText;
            retval.General.ExternalId = document.SelectSingleNode("//customer//get//result//data/gen_info/external-id")?.InnerText;
            retval.General.Description = document.SelectSingleNode("//customer//get//result//data/gen_info/description")?.InnerText;
            retval.General.Password = document.SelectSingleNode("//customer//get//result//data/gen_info/password")?.InnerText;
            retval.General.PasswordType = document.SelectSingleNode("//customer//get//result//data/gen_info/password_type")?.InnerText;
            retval.General.Id = int.Parse(document.SelectSingleNode("//customer//get//result//id")?.InnerText);

            return retval;
        }

        public class Customer_General
        {
            /// <summary>
            /// Create Required
            /// </summary>
            public string CName { get; set; }

            public string PName { get; set; }

            /// <summary>
            /// Create Required
            /// </summary>
            public string Login { get; set; }
            
            /// <summary>
            /// Create Required
            /// </summary>
            public string Password { get; set; }

            /// <summary>
            /// Read only
            /// </summary>
            public int Status { get; set; }
            public string Phone { get; set; }
            public string Fax { get; set; }
            public string Email { get; set; }
            public string Address { get; set; }
            public string City { get; set; }
            public string State { get; set; }
            public string PostCode { get; set; }

            /// <summary>
            /// 2 letter code
            /// </summary>
            public string Country { get; set; }
            public string Locale { get; set; }
            public int? OwnerId { get; set; }
            public string OwnerLogin { get; set; }
            public string OwnerExternalId { get; set; }
            public string ExternalId { get; set; }
            public string Description { get; set; }

            /// <summary>
            /// Read only
            /// </summary>
            public string CreateDate { get; set; }

            /// <summary>
            /// Read only
            /// </summary>
            public int Id { get; set; }

            /// <summary>
            /// Read only
            /// </summary>
            public string Guid { get; set; }

            /// <summary>
            /// Read only
            /// </summary>
            public string VendorGuid { get; set; }

            /// <summary>
            /// Read only
            /// </summary>
            public string PasswordType { get; set; }
        }

        [Flags]
        public enum DataSets
        {
            Gen_Info = 0,
            Statistics = 1,
        }

        public class Filter
        {
            public int? Id { get; set; }
            public string Login { get; set; }
            public int? OwnerId { get; set; }
            public string OwnerLogin { get; set; }
            public string Guid { get; set; }
            public string ExternalId { get; set; }
        }
    }
}
