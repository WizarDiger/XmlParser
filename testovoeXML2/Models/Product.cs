using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace testovoeXML2.Models
{
	public class Product
	{
		[XmlElement("quantity")]
		public string Quantity { get; set; }
		[XmlElement("name")]
		public string Name { get; set; }
		[XmlElement("price")]
		public string Price { get; set; }
	}
}
