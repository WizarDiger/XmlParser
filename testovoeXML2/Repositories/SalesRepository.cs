﻿using Npgsql;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using testovoeXML2.Interfaces;
using testovoeXML2.Models;

namespace testovoeXML2.Repositories
{
	internal class SalesRepository:ISalesService
	{		
		public void ProcessSales(Order order, NpgsqlConnection conn, NpgsqlTransaction tx)
		{
			if (order == null || order.Product == null || order.RegistrationDate == null || order.User == null || order.Sum == null) throw new Exception("Некорректные данные о продажах");
			var userId = GetUserId(order.User.Email,conn,tx);
			if (RecordExists(order.Number,conn,tx))
			{
				using var command = new NpgsqlCommand($@"UPDATE ""Покупки_товаров_пользователями"" SET ""пользователь_id""=@userId, ""дата_заказа""=@orderRegDate, ""цена_заказа""=@orderSum WHERE ""заказ_id""=@orderNo", conn, tx)
				{
					Parameters =
					{
						new("@userId",Int32.Parse(userId)),
						new("@orderRegDate",DateTime.Parse(order.RegistrationDate)),
						new("@orderSum",decimal.Parse($@"{order.Sum}",CultureInfo.InvariantCulture)),
						new("@orderNo", Int32.Parse(order.Number))
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
						new("@orderNo",Int32.Parse(order.Number)),
						new("@userId",Int32.Parse(userId)),
						new("@orderRegDate",DateTime.Parse(order.RegistrationDate)),
						new("@orderSum",decimal.Parse($@"{order.Sum}",CultureInfo.InvariantCulture))
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
					new("@no",Int32.Parse(no))
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
