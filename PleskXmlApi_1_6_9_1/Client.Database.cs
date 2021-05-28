using System.Net;
using System.Net.Security;
using System.Xml;
using PleskXmlApi_1_6_9_1.ResultModels;
using PleskXmlApi_1_6_9_1.XmlModels;

namespace PleskXmlApi_1_6_9_1
{
    public partial class Client
    {
        public CreateDatabase CreateDatabase(Models.Database database)
        {
            ServicePointManager.ServerCertificateValidationCallback =
                new RemoteCertificateValidationCallback(RemoteCertificateValidation);
            Request request = new Request(_hostName, _user, _password);

            var packet = Database.Create(database);

            XmlDocument result = request.Send(packet);
            return new CreateDatabase(result);
        }

        public CreateDatabaseUser CreateDatabaseUser(Models.DatabaseUser user)
        {
            ServicePointManager.ServerCertificateValidationCallback =
                new RemoteCertificateValidationCallback(RemoteCertificateValidation);
            Request request = new Request(_hostName, _user, _password);

            var packet = Database.CreateUser(user);

            XmlDocument result = request.Send(packet);
            return new CreateDatabaseUser(result);
        }
    }
}
