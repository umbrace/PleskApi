using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace PleskXmlApi_1_6_9_1.ResultModels
{
    public class CreateCustomer : Identity
    {
        public CreateCustomer(XmlDocument document) : base(document, "//customer//add")
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
