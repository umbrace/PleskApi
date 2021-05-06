using System.Net;
using System.Net.Security;
using System.Xml;
using PleskXmlApi_1_6_9_1.XmlModels;

namespace PleskXmlApi_1_6_9_1
{
    public partial class Client
    {
        public XmlDocument GetWebspace(Models.Webspace.DataSets dataSets, Models.Webspace.Filter filter)
        {
            ServicePointManager.ServerCertificateValidationCallback =
                new RemoteCertificateValidationCallback(RemoteCertificateValidation);
            Request request = new Request(_hostName, _user, _password);

            var packet = Webspace.Get(dataSets, filter);

            XmlDocument result = request.Send(packet);
            return result;
        }

        public XmlDocument CreateWebspace(Models.Webspace webspace)
        {
            ServicePointManager.ServerCertificateValidationCallback =
                new RemoteCertificateValidationCallback(RemoteCertificateValidation);
            Request request = new Request(_hostName, _user, _password);

            var packet = Webspace.Create(webspace);

            XmlDocument result = request.Send(packet);
            return result;
        }
    }
}
