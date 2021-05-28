﻿using System.Collections.Generic;
using System.Net;
using System.Net.Security;
using System.Xml;
using PleskXmlApi_1_6_9_1.ResultModels;
using PleskXmlApi_1_6_9_1.XmlModels;

namespace PleskXmlApi_1_6_9_1
{
    public partial class Client
    {
        public List<Models.IpAddress> GetIpAddresses()
        {
            ServicePointManager.ServerCertificateValidationCallback =
                new RemoteCertificateValidationCallback(RemoteCertificateValidation);
            Request request = new Request(_hostName, _user, _password);

            var packet = IpAddress.Get();

            XmlDocument result = request.Send(packet);
            return Models.IpAddress.FromGetDocument(result);
        }
    }
}
