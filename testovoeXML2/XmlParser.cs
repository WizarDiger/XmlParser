using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using testovoeXML2.Interfaces;
using testovoeXML2.Models;

namespace testovoeXML2
{
	public class XmlParser:IParseXmlService
	{
		public Orders ParseXml(string filePath)
		{
			string xmlString = System.IO.File.ReadAllText(filePath);
			XmlSerializer serializer = new XmlSerializer(typeof(Orders));
			Orders orders;
			using (StringReader reader = new StringReader(xmlString))
			{
				orders = (Orders)serializer.Deserialize(reader);
			}
			return orders;
		}
	}
}
