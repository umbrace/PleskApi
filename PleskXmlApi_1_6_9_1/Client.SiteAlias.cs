using System.Net;
using System.Net.Security;
using System.Xml;
using PleskXmlApi_1_6_9_1.ResultModels;
using PleskXmlApi_1_6_9_1.XmlModels;

namespace PleskXmlApi_1_6_9_1
{
    public partial class Client
    {
        public XmlDocument GetSiteAlias(Models.SiteAlias.Filter filter)
        {
            ServicePointManager.ServerCertificateValidationCallback =
                new RemoteCertificateValidationCallback(RemoteCertificateValidation);
            Request request = new Request(_hostName, _user, _password);

            var packet = SiteAlias.Get(filter);

            XmlDocument result = request.Send(packet);
            return result;
        }

        public CreateSiteAlias CreateSiteAlias(Models.SiteAlias siteAlias)
        {
            ServicePointManager.ServerCertificateValidationCallback =
                new RemoteCertificateValidationCallback(RemoteCertificateValidation);
            Request request = new Request(_hostName, _user, _password);

            var packet = SiteAlias.Create(siteAlias);

            XmlDocument result = request.Send(packet);
            return new CreateSiteAlias(result);
        }
    }
}
