using System;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.Xml.Schema;

namespace PleskXmlApi_1_6_9_1
{
    public partial class Client
    {
        private readonly string _hostName;
        private readonly string _user;
        private readonly string _password;

        public Client(string hostName, string user, string password)
        {
            _hostName = hostName;
            _user = user;
            _password = password;
        }

        public static bool RemoteCertificateValidation(object sender,
            X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors)
        {
            if (sslPolicyErrors != SslPolicyErrors.RemoteCertificateNotAvailable)
                return true;

            Console.WriteLine("Certificate error: {0}", sslPolicyErrors);

            // Do not allow this client to communicate with unauthenticated servers.
            return false;
        }

        private static void XmlSchemaValidation(object sender, ValidationEventArgs e)
        {
            Console.WriteLine("Validation error: {0}", e.Message);
        }
    }
}