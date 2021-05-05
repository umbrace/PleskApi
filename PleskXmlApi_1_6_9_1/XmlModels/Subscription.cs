using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace PleskXmlApi_1_6_9_1.XmlModels
{
    public class Subscription
    {
        private static XmlDocument Create()
        {
            var retval = new XmlDocument();
            retval.LoadXml(@"<packet>
<site>
    <get>
       <filter/>
       <dataset/>
    </get>
</site>
</packet>");
            return retval;
        }
    }
}
