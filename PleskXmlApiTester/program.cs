// Copyright 1999-2016. Parallels IP Holdings GmbH. All Rights Reserved.

using System;
using System.Net;
using System.Text;
using System.IO;
using System.Xml;
using System.Xml.Schema;
using System.Security.Cryptography.X509Certificates;
using System.Net.Security;
using PleskXmlApi_1_6_9_1.Models;

namespace PleskXmlApiTester
{

    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length < 3)
            {
                Console.WriteLine("incorrect parameters, need: domain user password");
                Console.ReadKey();
            }

            var client = new PleskXmlApi_1_6_9_1.Client(args[0], args[1], args[2]);
            //PrintResult(client.Create(new Site
            //{
            //    General = new Site.Site_General
            //    {
            //        Name = "pleskTest.com",
            //        WebSpaceId = 4
            //    }
            //}));
            PrintResult(client.GetSite(Site.DataSets.Hosting | Site.DataSets.Gen_Info, new Site.Filter { Id = 6 }));
        }

        static void PrintResult(XmlDocument document)
        {
            XmlTextWriter writer = new XmlTextWriter(Console.Out);
            writer.Formatting = Formatting.Indented;

            document.WriteTo(writer);

            writer.Flush();
            Console.WriteLine();
        }
    }
}