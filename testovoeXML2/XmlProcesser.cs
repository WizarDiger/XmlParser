using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using testovoeXML2.Models;
using testovoeXML2.Repositories;

namespace testovoeXML2
{
	public class XmlProcesser
	{
		string connString = "Server = localhost; Database = testovoe2; Port = 5432; Ssl Mode = allow; User Id = postgres; Password = ";
		public void ProcessXml(Orders orders)
		{
			using (var conn = new NpgsqlConnection(connString))
			{
				conn.Open();
				using var tx = conn.BeginTransaction();
				foreach (var order in orders.Order)
				{
					try
					{
						UsersRepository usersRepository = new UsersRepository();
						usersRepository.ProcessUserData(order.User, conn, tx);

						ProductsRepository productsRepository = new ProductsRepository();
						productsRepository.ProcessProducts(order, conn, tx);

						SalesRepository salesRepository = new SalesRepository();
						salesRepository.ProcessSales(order, conn, tx);

						BasketRepository basketRepository = new BasketRepository();
						basketRepository.ProcessBasket(order, conn, tx);
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
