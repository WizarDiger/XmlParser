using System.IO;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.ConstrainedExecution;
using System.Runtime.Intrinsics.X86;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;
using Npgsql;
using testovoeXML2;
using testovoeXML2.Models;
using testovoeXML2.Repositories;

//var xml = XDocument.Load("g:\\myXML.xml");
string path = "TestXmls\\myXML.xml";
var xmlProcesser = new XmlProcesser();
var xmlParser = new XmlParser();
var orders = xmlParser.ParseXml(path);
xmlProcesser.ProcessXml(orders);



