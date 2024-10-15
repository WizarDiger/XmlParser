using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using testovoeXML2.Interfaces;

namespace testovoeXML2
{
	public class XmlManager
	{
		public void InitializeParsing(ServiceProvider serviceProvider)
		{
			IParseXmlService? parseXmlService = serviceProvider.GetRequiredService<IParseXmlService>();
			IProcessXmlService? processXmlService = serviceProvider.GetRequiredService<IProcessXmlService>();
			string path = "myXML.xml";
			var orders = parseXmlService.ParseXml(path);
			processXmlService.ProcessXml(orders,serviceProvider);
		}
	}
}
