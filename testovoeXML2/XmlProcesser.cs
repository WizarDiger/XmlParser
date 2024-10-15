using Microsoft.Extensions.DependencyInjection;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using testovoeXML2.Interfaces;
using testovoeXML2.Models;
using testovoeXML2.Repositories;

namespace testovoeXML2
{
	public class XmlProcesser:IProcessXmlService
	{
		string connString = "Server = localhost; Database = testovoe2; Port = 5432; Ssl Mode = allow; User Id = postgres; Password = ";
		public void ProcessXml(Orders orders, ServiceProvider serviceProvider)
		{
			IBasketService? basketService = serviceProvider.GetRequiredService<IBasketService>();
			IProductsService? productsService = serviceProvider.GetRequiredService<IProductsService>();
			ISalesService? salesService = serviceProvider.GetRequiredService<ISalesService>();
			IUsersService? usersService = serviceProvider.GetRequiredService<IUsersService>();
			using (var conn = new NpgsqlConnection(connString))
			{
				conn.Open();
				using var tx = conn.BeginTransaction();
				foreach (var order in orders.Order)
				{
					try
					{
						usersService.ProcessUserData(order.User, conn, tx);
						productsService.ProcessProducts(order, conn, tx);
						salesService.ProcessSales(order, conn, tx);
						basketService.ProcessBasket(order, conn, tx);
					}
					catch
					{
						throw new Exception("Некорректный XML файл");
					}
				}
				tx.Commit();
			}
		}
	}
}
