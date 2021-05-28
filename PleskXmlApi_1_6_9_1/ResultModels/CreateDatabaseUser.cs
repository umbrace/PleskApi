using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace PleskXmlApi_1_6_9_1.ResultModels
{
    public class CreateDatabaseUser : Identity
    {
        public CreateDatabaseUser(XmlDocument document) : base(document, "//database//add-db-user")
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
        }
    }
}
