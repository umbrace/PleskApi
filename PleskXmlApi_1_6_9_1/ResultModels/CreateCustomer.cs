using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace PleskXmlApi_1_6_9_1.ResultModels
{
    public class CreateCustomer : Base
    {
        public int Id { get; set; }
        public string Guid { get; set; }

        public CreateCustomer()
        {
            
        }

        public CreateCustomer(XmlDocument document) : base(document)
        {
            if (base.IsSuccess() == false)
            {
                return;
            }

            if (ProcessIsSuccess(document) == false)
            {
                return;
            }

            SetFields(document);
        }

        private bool ProcessIsSuccess(XmlDocument document)
        {
            var statusNode = document.SelectSingleNode("//customer//add//status");
            if (statusNode?.InnerText == "error")
            {
                Status = Status.Error;
                ErrorCode = Int32.Parse(document.SelectSingleNode("//customer//add//errcode")?.InnerText);
                ErrorText = document.SelectSingleNode("//customer//add//errtext")?.InnerText;
                return false;
            }

            if (statusNode?.InnerText == "ok")
            {
                base.Status = Status.Ok;
            }
            return base.Status == Status.Ok;
        }

        private void SetFields(XmlDocument document)
        {
            Id = Int32.Parse(document.SelectSingleNode("//customer//add//id")?.InnerText);
            Guid = document.SelectSingleNode("//customer//add//guid")?.InnerText;
        }
    }
}
