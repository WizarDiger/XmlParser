using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using testovoeXML2.Models;

namespace testovoeXML2.Repositories
{
	internal class UsersRepository
	{
		public async Task ProcessUserData(User user, NpgsqlConnection conn)
		{

			if (userExists(user.email, conn))
			{
				using (var command = new NpgsqlCommand($@"UPDATE ""Пользователи"" SET ""имя_пользователя""='{user.fio}' WHERE email_пользователя='{user.email}'", conn))
					command.ExecuteNonQuery();
			}
			else
			{
				using (var command = new NpgsqlCommand($@"INSERT INTO ""Пользователи"" (""имя_пользователя"", ""email_пользователя"") VALUES ('{user.fio}','{user.email}')", conn))
					command.ExecuteNonQuery();
			}
		}
		bool userExists(string email, NpgsqlConnection conn)
		{
			var check = "";
			using (var command = new NpgsqlCommand($@"SELECT * FROM ""Пользователи"" WHERE email_пользователя = '{email}'", conn))
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
