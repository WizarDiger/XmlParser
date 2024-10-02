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
	internal class SalesRepository
	{		
		public void ProcessSales(Order order, NpgsqlConnection conn, NpgsqlTransaction tx)
		{
			if (order == null || order.product == null || order.reg_date == null || order.user == null || order.sum == null) throw new Exception("Некорректные данные о продажах");
			var userId = GetUserId(order.user.email,conn,tx);
			if (RecordExists(order.no,conn,tx))
			{
				using var command = new NpgsqlCommand($@"UPDATE ""Покупки_товаров_пользователями"" SET ""пользователь_id""=@userId, ""дата_заказа""=@orderRegDate, ""цена_заказа""=@orderSum WHERE ""заказ_id""=@orderNo", conn, tx)
				{
					Parameters =
					{
						new("@userId",Int32.Parse(userId)),
						new("@orderRegDate",order.reg_date),
						new("@orderSum",decimal.Parse($@"{order.sum}",CultureInfo.InvariantCulture)),
						new("@orderNo", Int32.Parse(order.no))
					}
				};
				command.ExecuteNonQuery();			
			}
			else
			{
				using var command = new NpgsqlCommand($@"INSERT INTO ""Покупки_товаров_пользователями"" (""заказ_id"",""пользователь_id"", ""дата_заказа"", ""цена_заказа"") VALUES (@orderNo,@userId,@orderRegDate,@orderSum)", conn, tx)
				{
					Parameters =
					{
						new("@orderNo",order.no),
						new("@userId",userId),
						new("@orderRegDate",order.reg_date),
						new("@orderSum",order.sum)
					}
				};
				command.ExecuteNonQuery();		
			}
		}

		private bool RecordExists(string no, NpgsqlConnection conn, NpgsqlTransaction tx)
		{
			var check = "";
			using var command = new NpgsqlCommand($@"SELECT * FROM ""Покупки_товаров_пользователями"" WHERE заказ_id = @no", conn, tx)
			{
				Parameters =
				{
					new("@no",no)
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
		private string GetUserId(string email, NpgsqlConnection conn, NpgsqlTransaction tx)
		{
			var userId = "";
			using var command = new NpgsqlCommand($@"SELECT * FROM ""Пользователи"" WHERE email_пользователя = @email", conn, tx)
			{
				Parameters =
				{
					new("@email",email)
				}
			};
			{
				var reader = command.ExecuteReader();
				while (reader.Read())
				{
					userId = string.Format(reader.GetInt32(0).ToString());
				}
				reader.Close();
				return userId;
			}
		}

	}
}
