﻿using Npgsql;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using testovoeXML2.Models;

namespace testovoeXML2.Repositories
{
	internal class ProductsRepository
	{
		public void ProcessProducts(Order order, NpgsqlConnection conn, NpgsqlTransaction tx)
		{
			if (order == null || order.product== null) throw new Exception("Некорректные данные о товарах");
			foreach (var product in order.product)
			{
				if (ProductExists(product.name, conn, tx))
				{
					using var command = new NpgsqlCommand($@"UPDATE ""Товары"" SET ""цена_товара""=@productPrice WHERE ""название_товара""=@productName", conn, tx)
					{
						Parameters =
						{
							new("@productPrice",decimal.Parse($@"{product.price}",CultureInfo.InvariantCulture)),
							new("@productName",product.name)
						}
					};
						command.ExecuteNonQuery();
				}
				else
				{
					using var command = new NpgsqlCommand($@"INSERT INTO ""Товары"" (""название_товара"",""цена_товара"", ""производитель_id"", ""категория_id"") VALUES (@productName,@productPrice,@productManufacturerId,@categoryId)", conn, tx)
					{
						Parameters =
						{
							new("@productName",product.name),
							new("@productPrice",decimal.Parse($@"{product.price}",CultureInfo.InvariantCulture)),
							new("@productManufacturerId",1),
							new("@categoryId",1)
						}
					};
						command.ExecuteNonQuery();
				}
			}
		}
		private bool ProductExists(string name, NpgsqlConnection conn, NpgsqlTransaction tx)
		{
			var check = "";
			using var command = new NpgsqlCommand($@"SELECT * FROM ""Товары"" WHERE название_товара = @name", conn, tx)
			{
				Parameters =
				{
					new("@name",name)
				}
			};
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
