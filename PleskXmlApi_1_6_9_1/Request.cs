using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using System.Xml;

namespace PleskXmlApi_1_6_9_1
{
    public class Request
    {
        private readonly string _hostName;
        private readonly string _login;
        private readonly string _password;

        public Request(string hostName, string login, string password)
        {
            _hostName = hostName;
            _login = login;
            _password = password;
        }

        public string AgentEntryPoint => "https://" + _hostName + ":8443/enterprise/control/agent.php";

        public XmlDocument Send(XmlDocument packet)
        {
            HttpWebRequest request = SendRequest(packet.OuterXml);
            XmlDocument result = GetResponse(request);
            return result;
        }

        public XmlDocument Send(Stream packet)
        {
            using (TextReader reader = new StreamReader(packet))
            {
                return Send(Parse(reader));
            }
        }

        public XmlDocument Send(string packetUri)
        {
            using (TextReader reader = new StreamReader(packetUri))
            {
                return Send(Parse(reader));
            }
        }

        private HttpWebRequest SendRequest(string message)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(AgentEntryPoint);

            request.Method = "POST";
            request.Headers.Add("HTTP_AUTH_LOGIN", _login);
            request.Headers.Add("HTTP_AUTH_PASSWD", _password);
            request.ContentType = "text/xml";
            request.ContentLength = message.Length;

            ASCIIEncoding encoding = new ASCIIEncoding();
            byte[] buffer = encoding.GetBytes(message);

            using (Stream stream = request.GetRequestStream())
            {
                stream.Write(buffer, 0, message.Length);
            }

            return request;
        }

        private XmlDocument Parse(TextReader xml)
        {
            XmlDocument document = new XmlDocument();

            using (XmlReader reader = XmlTextReader.Create(xml))
            {
                document.Load(reader);
            }

            return document;
        }

        private XmlDocument GetResponse(HttpWebRequest request)
        {
            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            using (Stream stream = response.GetResponseStream())
            using (TextReader reader = new StreamReader(stream))
            {
                return Parse(reader);
            }
        }
    }
}
