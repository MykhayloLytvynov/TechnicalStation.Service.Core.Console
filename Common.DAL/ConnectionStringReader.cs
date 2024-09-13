using System;
using System.Xml;

namespace Common.DAL
{
    public class ConnectionStringReader
    {
        public static string GetConnectionString(string databaseName, string xmlFilePath)
        {
            XmlDocument xmlDoc = new XmlDocument();
            string keyname = "";
            string keyvalue = "";
            xmlDoc.Load(xmlFilePath);
            string connectionString = string.Empty;

            foreach (XmlNode nodes in xmlDoc.SelectNodes("connectionStrings/add"))
            {
                keyname = nodes.Attributes.GetNamedItem("name").Value;
                keyvalue = nodes.Attributes.GetNamedItem("connectionString").Value;

                if (keyname == "Notes")
                {
                    connectionString = keyvalue;
                    break;
                }
            }
            connectionString = "server=localhost;UserId=root;Password=281099;database=orders;SslMode=none;";
            //Console.WriteLine(connectionString);
            return connectionString;
        }
    }
}
