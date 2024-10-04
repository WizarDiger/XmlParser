using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace testovoeXML2.Models
{
	public class User
	{
		[XmlElement("fio")]
		public string Fio { get; set; }
		[XmlElement("email")]
		public string Email { get; set; }
	}
}
