using System;
using System.Collections.Generic;
using System.Text;

namespace PleskXmlApi_1_6_9_1.Constants
{
    public static class Properties
    {
        public static class Hosting
        {
            public const string SeoRedirect = "seo-redirect";

            public const string FtpLogin = "ftp_login";
            public const string FtpPassword = "ftp_password";
            public const string FtpPassworType = "ftp_password_type";
            public const string FtpQuota = "ftp_quota";

            public const string Ssl = "ssl";
            public const string SslRedirect = "ssl-redirect";

            public const string Shell = "shell";

            public const string Php = "php";
            public const string PhpHandlerId = "php_handler_id";

            public const string UnpaidWebsiteStatus = "unpaid_website_status";

            public const string Ssi = "ssi";
            public const string SsiHtml = "ssi_html";
            public const string Cgi = "cgi";
            public const string Perl = "perl";
            public const string Python = "python";
            public const string Asp = "asp";
            public const string AspDotNet = "asp_dot_net";
            public const string ManagedRuntimeVersion = "managed_runtime_version";

            //todo add all
        }

        public static class Limits
        {
            public const string DiskSpace = "disk_space";
            public const string MaxTraffic = "max_traffic";

            //todo add all
        }
    }
}
