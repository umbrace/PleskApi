// Copyright 1999-2016. Parallels IP Holdings GmbH. All Rights Reserved.

using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.IO;
using System.Xml;
using System.Xml.Schema;
using System.Security.Cryptography.X509Certificates;
using System.Net.Security;
using Newtonsoft.Json;
using PleskXmlApi_1_6_9_1.Constants;
using PleskXmlApi_1_6_9_1.Models;
using PleskXmlApi_1_6_9_1.ResultModels;
using Formatting = System.Xml.Formatting;

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
            try
            {
                var createCustomer = CreateCustomer(client, true);
                if (createCustomer.Status != Status.Ok)
                {
                    Console.ReadKey();
                    return;
                }
                Console.WriteLine("Getting Customer (" + createCustomer.Id + "):");
                PrintResult(client.GetCustomer(Customer.DataSets.Gen_Info, new Customer.Filter { Id = createCustomer.Id }));

                var createWebspace = CreateWebspace(client, createCustomer.Id, true);
                Console.ReadKey();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                Console.ReadKey();
            }
        }

        private static CreateCustomer CreateCustomer(PleskXmlApi_1_6_9_1.Client client, bool log = false)
        {
            if (log)
            {
                Console.WriteLine("Creating Customer:");
            }
            var result = client.CreateCustomer(new Customer
            {
                General = new Customer.Customer_General
                {
                    PName = "ApiTest",
                    Login = "ApiTest",
                    Password = "0123456789",
                }
            });
            if (log)
            {
                PrintResult(result);
            }

            return result;
        }

        private static XmlDocument CreateWebspace(PleskXmlApi_1_6_9_1.Client client, int? customerId, bool log = false)
        {
            if (log)
            {
                Console.WriteLine("Creating Webspace:");
            }
            var result = client.CreateWebspace(new Webspace
            {
                General = new Webspace.Webspace_General
                {
                    Name = "Apitest.com",
                    IpAddress = "127.0.0.1", //todo get this from iplist
                    HostingType = "vrt_hst", //todo change by enum?
                    OwnerId = customerId
                },
                Hosting = new Webspace.Webspace_Hosting
                {
                    VirtualHost = new Webspace.Webspace_Hosting.Virtual_Host
                    {
                        IpAddress = "127.0.0.1", //todo get this from iplist
                        Properties = new Dictionary<string, string>
                        {
                            { Properties.Customer.Hosting.FtpLogin, "apitest_ftp" },
                            { Properties.Customer.Hosting.FtpPassword, "0123456789" }
                        }
                    }
                },
                PlanName = "Unlimited" //todo get this from planlist
            });

            if (log)
            {
                PrintXml(result);
            }

            return result;
        }

        static void PrintXml(XmlDocument document)
        {
            XmlTextWriter writer = new XmlTextWriter(Console.Out);
            writer.Formatting = Formatting.Indented;

            document.WriteTo(writer);

            writer.Flush();
            Console.WriteLine();
        }

        static void PrintResult(object result)
        {
            Console.WriteLine(JsonConvert.SerializeObject(result, Newtonsoft.Json.Formatting.Indented));
        }
    }
}