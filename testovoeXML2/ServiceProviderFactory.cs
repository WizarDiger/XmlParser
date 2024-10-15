using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using testovoeXML2.Interfaces;
using testovoeXML2.Repositories;

namespace testovoeXML2
{
	public class ServiceProviderFactory
	{
		public ServiceProvider Create()
		{
			var services = new ServiceCollection();
			services.AddTransient<IParseXmlService,XmlParser>();
			services.AddTransient<IProcessXmlService,XmlProcesser>();
			services.AddTransient<IBasketService,BasketRepository>();
			services.AddTransient<IProductsService,ProductsRepository>();
			services.AddTransient<ISalesService,SalesRepository>();
			services.AddTransient<IUsersService,UsersRepository>();
			services.AddTransient<XmlManager>();
			var serviceProvider = services.BuildServiceProvider();
			return serviceProvider;
		}

	}
}
