using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using testovoeXML2.Models;

namespace testovoeXML2.Interfaces
{
	internal interface IProcessXmlService
	{
		void ProcessXml(Orders orders, ServiceProvider serviceProvider);
	}
}
