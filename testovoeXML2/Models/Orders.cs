using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace testovoeXML2.Models
{
	[XmlRoot(ElementName = "orders", DataType = "string", IsNullable = true)]
	public class Orders
	{

		[XmlElement("order", typeof(Order))]
		public Order[] Order { get; set; }
	}

}
