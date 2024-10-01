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
		public string quantity { get; set; }
		public string name { get; set; }
		public string price { get; set; }
	}
}
