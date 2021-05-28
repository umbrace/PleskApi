using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using PleskXmlApi_1_6_9_1.Extensions;

namespace PleskXmlApi_1_6_9_1.XmlModels
{

    public class Database
    {

        private static XmlDocument Create()
        {
            var retval = new XmlDocument();
            retval.LoadXml(@"<packet>
<database>

<add-db>
</add-db>

</database>
</packet>");
            return retval;
        }

        public static XmlDocument Create(Models.Database database)
        {
            var document = Create();
            document.AppendTagWithValue("add-db", "webspace-id", database.WebspaceId);
            document.AppendTagWithValue("add-db", "name", database.Name);
            document.AppendTagWithValue("add-db", "type", database.Type);
            return document;
        }

        private static XmlDocument CreateUser()
        {
            var retval = new XmlDocument();
            retval.LoadXml(@"<packet>
<database>
   <add-db-user>
   </add-db-user>
</database>
</packet>");
            return retval;
        }

        public static XmlDocument CreateUser(Models.DatabaseUser user)
        {
            var document = CreateUser();
            document.AppendTagWithValue("add-db-user", "db-id", user.DbId);
            document.AppendTagWithValue("add-db-user", "login", user.Login);
            document.AppendTagWithValue("add-db-user", "password", user.Password);
            return document;
        }
    }
}
