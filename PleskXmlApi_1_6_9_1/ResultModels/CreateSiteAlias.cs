using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace PleskXmlApi_1_6_9_1.ResultModels
{
    public class CreateSiteAlias : Identity
    {
        public CreateSiteAlias(XmlDocument document) : base(document, "//site-alias//create")
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
