using Npgsql;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using testovoeXML2.Models;

namespace testovoeXML2.Repositories
{
	internal class BasketRepository
	{
		public void ProcessBasket(Order order, NpgsqlConnection conn, NpgsqlTransaction tx)
		{
			if (order == null || order.Product == null || order.RegistrationDate == null || order.User == null || order.Sum == null) throw new Exception("Некорректные данные о продажах");

			using var deleteBasketCommand = new NpgsqlCommand($@"DELETE FROM ""Корзина"" WHERE ""заказ_id""=@orderNo", conn, tx)
			{
				Parameters =
				{
					new("@orderNo", Int32.Parse(order.Number))
				}
			};
			deleteBasketCommand.ExecuteNonQuery();

			foreach (var product in order.Product)
			{
				if (ProductExists(product.Name,conn, tx))
				{
					using var command = new NpgsqlCommand($@"UPDATE ""Товары"" SET ""цена_товара""=@productPrice WHERE ""название_товара""=@productName", conn, tx)
					{
						Parameters =
						{
							new("@productPrice",decimal.Parse($@"{product.Price}",CultureInfo.InvariantCulture)),
							new("@productName",product.Name)
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
							new("@productName",product.Name),
							new("@productPrice",decimal.Parse($@"{product.Price}",CultureInfo.InvariantCulture)),
							new("@productManufacturerId",1),
							new("@categoryId",1)
						}
					};
					command.ExecuteNonQuery();
				}
				var productId = GetProductId(product.Name,conn, tx);
				using var insertIntoBasketCommand = new NpgsqlCommand($@"INSERT INTO ""Корзина"" (""заказ_id"",""товар_id"",""количество_товара"") VALUES (@orderNo,@productId,@productQuantity)", conn, tx)
				{
					Parameters =
					{
						new("@orderNo",Int32.Parse(order.Number)),
						new("productId",Int32.Parse(productId)),
						new("productQuantity",Int32.Parse(product.Quantity))
					}
				};
                insertIntoBasketCommand.ExecuteNonQuery();
				
			}
		}
		private bool ProductExists(string name, NpgsqlConnection conn, NpgsqlTransaction tx)
		{
			var check = "";
			using (var command = new NpgsqlCommand($@"SELECT * FROM ""Товары"" WHERE название_товара = @name", conn, tx)
			{
				Parameters =
				{
					new("@name",name)
				}
			})
			{
				var reader = command.ExecuteReader();
				while (reader.Read())
				{
					check = string.Format(reader.GetInt32(0).ToString());
				}
				reader.Close();
				if (check.Length > 0) return true;
				return false;
			};
		}
		private string GetProductId(string name, NpgsqlConnection conn, NpgsqlTransaction tx)
		{
			var productId = "";
			using (var command = new NpgsqlCommand($@"SELECT * FROM ""Товары"" WHERE название_товара = @name", conn, tx)
			{
				Parameters =
				{
					new("@name",name)
				}
			})
			{
				var reader = command.ExecuteReader();
				while (reader.Read())
				{
					productId = string.Format(reader.GetInt32(0).ToString());
				}
				reader.Close();
				return productId;
			}
		}
	}
}
