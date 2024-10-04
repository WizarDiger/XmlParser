using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace testovoeXML2.Models
{
	public class Order
	{
		[XmlElement("no")]
		public string Number { get; set; }
		[XmlElement("reg_date")]
		public string RegistrationDate { get; set; }
		[XmlElement("sum")]
		public string Sum { get; set; }
	
		[XmlElement("product", typeof(Product))]
		public Product[] Product { get; set; }
		[XmlElement("user")]
		public User User { get; set; }
	}
}
