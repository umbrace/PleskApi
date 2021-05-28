using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using PleskXmlApi_1_6_9_1.Extensions;

namespace PleskXmlApi_1_6_9_1.XmlModels
{

    public class IpAddress
    {
        public static XmlDocument Get()
        {
            var retval = new XmlDocument();
            retval.LoadXml(@"<packet>
<ip>
  <get/>
</ip>
</packet>");
            return retval;
        }
    }
}
