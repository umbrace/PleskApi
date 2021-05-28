// Copyright 1999-2016. Parallels IP Holdings GmbH. All Rights Reserved.

using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.IO;
using System.Linq;
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
            FullTestSetup(client);
            //DebugUsers(client);
            //DebugWebspaces(client);
        }

        private static void FullTestSetup(PleskXmlApi_1_6_9_1.Client client)
        {
            try
            {
                Console.WriteLine("Getting IpAddresses");
                var ipAddresses = client.GetIpAddresses();
                PrintResult(ipAddresses);
                if (ipAddresses?.Any() == false)
                {
                    Console.ReadKey();
                    return;
                }

                var mainIpAddress = ipAddresses.First().Address;

                var createCustomer = CreateCustomer(client, true);
                if (createCustomer.Status != Status.Ok)
                {
                    Console.ReadKey();
                    return;
                }
                Console.WriteLine("Getting Customer (" + createCustomer.Id + "):");
                PrintResult(client.GetCustomer(Customer.DataSets.Gen_Info, new Customer.Filter { Id = createCustomer.Id }));

                var createWebspace = CreateWebspace(client, mainIpAddress, createCustomer.Id, true);
                if (createWebspace.Status != Status.Ok)
                {
                    Console.ReadKey();
                    return;
                }

                var createSiteAlias = CreateSiteAlias(client, createWebspace.Id, true);
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

        private static CreateWebspace CreateWebspace(PleskXmlApi_1_6_9_1.Client client,string ipAddress, int? customerId, bool log = false)
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
                    IpAddress = ipAddress,
                    HostingType = "vrt_hst", //todo change by enum?
                    OwnerId = customerId
                },
                Hosting = new Webspace.Webspace_Hosting
                {
                    VirtualHost = new Webspace.Webspace_Hosting.Virtual_Host
                    {
                        IpAddress = ipAddress,
                        Properties = new Dictionary<string, string>
                        {
                            { Properties.Hosting.FtpLogin, "apitest_ftp" },
                            { Properties.Hosting.FtpPassword, "0123456789" },
                            { Properties.Hosting.Php, "false"},
                            { Properties.Hosting.AspDotNet, "true"},
                            { Properties.Hosting.ManagedRuntimeVersion,  "4.0"},
                        }
                    }
                },
                PlanName = "Unlimited", //todo get this from planlist
                Preferences = new Webspace.Webspace_Preferences
                {
                    WWW = true
                },
                Mail = new Webspace.Webspace_Mail
                {
                    MailService = false
                }
            });

            if (log)
            {
                PrintResult(result);
            }

            return result;
        }

        private static CreateSiteAlias CreateSiteAlias(PleskXmlApi_1_6_9_1.Client client, int siteId,
            bool log = false)
        {
            if (log)
            {
                Console.WriteLine("Creating Site Alias:");
            }
            var result = client.CreateSiteAlias(new SiteAlias
            {
                ManageDns = false,
                Name = "Apitest.Umbraceprojects.be",
                SiteId = siteId,
                Preferences = new SiteAlias.SiteAlias_Preferences
                {
                    Mail = false,
                    SeoRedirect = false,
                    Web = true
                }
            });

            if (log)
            {
                PrintResult(result);
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


        private static void DebugUsers(PleskXmlApi_1_6_9_1.Client client)
        {
            var existingUser = JsonConvert.SerializeObject(client.GetCustomer(Customer.DataSets.Gen_Info | Customer.DataSets.Statistics,
                new Customer.Filter { Id = 27 }),
                Newtonsoft.Json.Formatting.Indented);
            File.WriteAllText(Path.Combine(Environment.CurrentDirectory, "existingUser.json"), existingUser);

            var createdUser = JsonConvert.SerializeObject(client.GetCustomer(Customer.DataSets.Gen_Info | Customer.DataSets.Statistics,
                new Customer.Filter { Id = 5 }),
                Newtonsoft.Json.Formatting.Indented);
            File.WriteAllText(Path.Combine(Environment.CurrentDirectory, "createdUser.json"), createdUser);
        }

        private static void DebugWebspaces(PleskXmlApi_1_6_9_1.Client client)
        {
            var allDatasets = Webspace.DataSets.Gen_Info | Webspace.DataSets.Hosting | Webspace.DataSets.Limits |
                              Webspace.DataSets.Mail | Webspace.DataSets.Permissions | Webspace.DataSets.ApsFilter |
                              Webspace.DataSets.Packages | Webspace.DataSets.PhpSettings | Webspace.DataSets.PlanItems |
                              Webspace.DataSets.Preferences | Webspace.DataSets.Subscriptions;

            var existingWebspace = JsonConvert.SerializeObject(client.GetWebspace(allDatasets, new Webspace.Filter
            {
                Id = 37
            }),
                Newtonsoft.Json.Formatting.Indented);
            File.WriteAllText(Path.Combine(Environment.CurrentDirectory, "existingWebspace.json"), existingWebspace);

            var createdWebspace = JsonConvert.SerializeObject(client.GetWebspace(allDatasets, new Webspace.Filter
            {
                Id = 46
            }),
                Newtonsoft.Json.Formatting.Indented);
            File.WriteAllText(Path.Combine(Environment.CurrentDirectory, "createdWebspace.json"), createdWebspace);
        }
    }
}