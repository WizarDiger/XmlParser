using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using testovoeXML2.Models;

namespace testovoeXML2.Repositories
{
	internal class ProductsRepository
	{
		public void ProcessProducts(Order order, NpgsqlConnection conn)
		{
			foreach (var product in order.product)
			{
				if (productExists(product.name, conn))
				{
					using (var command = new NpgsqlCommand($@"UPDATE ""Товары"" SET ""цена_товара""={product.price} WHERE ""название_товара""='{product.name}'", conn))
						command.ExecuteNonQuery();
				}
				else
				{
					using (var command = new NpgsqlCommand($@"INSERT INTO ""Товары"" (""название_товара"",""цена_товара"", ""производитель_id"", ""категория_id"") VALUES ('{product.name}',{product.price},'1','1')", conn))
						command.ExecuteNonQuery();
				}
			}
		}
		bool productExists(string name, NpgsqlConnection conn)
		{
			var check = "";
			using (var command = new NpgsqlCommand($@"SELECT * FROM ""Товары"" WHERE название_товара = '{name}'", conn))
			{
				var reader = command.ExecuteReader();
				while (reader.Read())
				{
					check = string.Format(reader.GetInt32(0).ToString());
				}
				reader.Close();
				if (check.Length > 0) return true;
				return false;
			}
		}
	}
}
