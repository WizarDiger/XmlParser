using System.IO;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.ConstrainedExecution;
using System.Runtime.Intrinsics.X86;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;
using Npgsql;
using testovoeXML2.Models;

string connString = "Server = localhost; Database = testovoe2; Port = 5432; Ssl Mode = allow; User Id = postgres; Password = ";

//var xml = XDocument.Load("g:\\myXML.xml");
string path = "g:\\myXML.xml";
XmlSerializer serializer = new XmlSerializer(typeof(Orders));
Orders orders;
string xmlString = System.IO.File.ReadAllText(path);
using (StringReader reader = new StringReader(xmlString))
{
	 orders = (Orders)serializer.Deserialize(reader);
}


using (var conn = new NpgsqlConnection(connString))
{
//	conn.Open();
	

}

