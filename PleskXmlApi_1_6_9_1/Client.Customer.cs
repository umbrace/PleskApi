using System.Net;
using System.Net.Security;
using System.Xml;
using PleskXmlApi_1_6_9_1.ResultModels;
using PleskXmlApi_1_6_9_1.XmlModels;

namespace PleskXmlApi_1_6_9_1
{
    public partial class Client
    {
        public Models.Customer GetCustomer(Models.Customer.DataSets dataSets, Models.Customer.Filter filter)
        {
            ServicePointManager.ServerCertificateValidationCallback =
                new RemoteCertificateValidationCallback(RemoteCertificateValidation);
            Request request = new Request(_hostName, _user, _password);

            var packet = Customer.Get(dataSets, filter);

            XmlDocument result = request.Send(packet);
            return Models.Customer.FromGetCustomerDocument(result);
        }

        public CreateCustomer CreateCustomer(Models.Customer customer)
        {
            ServicePointManager.ServerCertificateValidationCallback =
                new RemoteCertificateValidationCallback(RemoteCertificateValidation);
            Request request = new Request(_hostName, _user, _password);

            var packet = Customer.Create(customer);

            XmlDocument result = request.Send(packet);
            return new CreateCustomer(result);
        }
    }
}
