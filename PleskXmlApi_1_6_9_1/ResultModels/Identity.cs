using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace PleskXmlApi_1_6_9_1.ResultModels
{
    public class Identity : Base
    {
        public int Id { get; set; }
        protected string BaseXpath { get; set; }

        public Identity()
        {

        }

        public Identity(XmlDocument document, string baseXpath) : base(document)
        {
            BaseXpath = baseXpath;
        }

        protected bool ProcessIsSuccess(XmlDocument document)
        {
            var statusNode = document.SelectSingleNode(BaseXpath + "//status");
            if (statusNode?.InnerText == "error")
            {
                Status = Status.Error;
                ErrorCode = Int32.Parse(document.SelectSingleNode(BaseXpath + "//errcode")?.InnerText);
                ErrorText = document.SelectSingleNode(BaseXpath + "//errtext")?.InnerText;
                return false;
            }

            if (statusNode?.InnerText == "ok")
            {
                base.Status = Status.Ok;
            }
            return base.Status == Status.Ok;
        }

        protected void SetFields(XmlDocument document)
        {
            Id = Int32.Parse(document.SelectSingleNode(BaseXpath + "//id")?.InnerText);
        }
    }
}
