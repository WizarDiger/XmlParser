using Npgsql;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using testovoeXML2.Models;

namespace testovoeXML2.Repositories
{
	internal class SalesRepository
	{		
		public void ProcessSales(Order order, NpgsqlConnection conn)
		{
			var userId = getUserId(order.user.email,conn);
			if (recordExists(order.no,conn))
			{
				using (var command = new NpgsqlCommand($@"UPDATE ""Покупки_товаров_пользователями"" SET ""пользователь_id""='{userId}', ""дата_заказа""='{order.reg_date}', ""цена_заказа""={order.sum} WHERE ""заказ_id""='{order.no}'", conn))
				command.ExecuteNonQuery();			
			}
			else
			{
				using (var command = new NpgsqlCommand($@"INSERT INTO ""Покупки_товаров_пользователями"" (""заказ_id"",""пользователь_id"", ""дата_заказа"", ""цена_заказа"") VALUES ({order.no},{userId},'{order.reg_date}',{order.sum})", conn))
				command.ExecuteNonQuery();		
			}
		}

		bool recordExists(string no, NpgsqlConnection conn)
		{
			var check = "";
			using (var command = new NpgsqlCommand($@"SELECT * FROM ""Покупки_товаров_пользователями"" WHERE заказ_id = {no}", conn))
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
		string getUserId(string email, NpgsqlConnection conn)
		{
			var userId = "";
			using (var command = new NpgsqlCommand($@"SELECT * FROM ""Пользователи"" WHERE email_пользователя = '{email}'", conn))
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
