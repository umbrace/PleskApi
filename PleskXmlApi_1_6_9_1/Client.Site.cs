using System.Net;
using System.Net.Security;
using System.Xml;
using PleskXmlApi_1_6_9_1.XmlModels;

namespace PleskXmlApi_1_6_9_1
{
    public partial class Client
    {
        public XmlDocument GetSite(Models.Site.DataSets dataSets, Models.Site.Filter filter)
        {
            ServicePointManager.ServerCertificateValidationCallback =
                new RemoteCertificateValidationCallback(RemoteCertificateValidation);
            Request request = new Request(_hostName, _user, _password);

            var packet = Site.Get(dataSets, filter);

            XmlDocument result = request.Send(packet);
            return result;
        }

        public XmlDocument Create(Models.Site site)
        {
            ServicePointManager.ServerCertificateValidationCallback =
                new RemoteCertificateValidationCallback(RemoteCertificateValidation);
            Request request = new Request(_hostName, _user, _password);

            var packet = Site.Create(site);

            XmlDocument result = request.Send(packet);
            return result;
        }
    }
}
