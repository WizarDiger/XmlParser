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
		public string no { get; set; }
		public string reg_date { get; set; }
		public string sum { get; set; }
	
		[XmlElement("product", typeof(Product))]
		public Product[] product { get; set; }
		public User user { get; set; }
	}
}
