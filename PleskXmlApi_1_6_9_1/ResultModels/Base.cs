using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace PleskXmlApi_1_6_9_1.ResultModels
{
    public class Base
    {
        public Status Status { get; set; }
        public int ErrorCode { get; set; }
        public string ErrorText { get; set; }

        public Base()
        {
            
        }

        public Base(XmlDocument document)
        {
            var systemNodes = document.GetElementsByTagName("system");
            if (systemNodes.Count == 0)
            {
                return;
            }

            var statusNode = document.SelectSingleNode("//system//status");
            if (statusNode.InnerText == "error")
            {
                Status = Status.Error;
                ErrorCode = Int32.Parse(document.SelectSingleNode("//system//errcode")?.InnerText);
                ErrorText = document.SelectSingleNode("//system//errtext")?.InnerText;
            }


        }

        internal bool IsSuccess()
        {
            return Status != Status.Error;
        }
    }
}
