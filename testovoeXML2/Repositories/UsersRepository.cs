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
		public void ProcessUserData(User user, NpgsqlConnection conn, NpgsqlTransaction tx)
		{
			if (user == null || user.email == null || user.fio == null) throw new Exception("Некорректные данные о пользователе");
			if (UserExists(user.email, conn, tx))
			{
				using var command = new NpgsqlCommand($@"UPDATE ""Пользователи"" SET ""имя_пользователя""=@userFio WHERE email_пользователя=@userEmail", conn, tx)
				{
					Parameters =
					{
						new("@userFio",user.fio),
						new("@userEmail",user.email)
					}
				};
					command.ExecuteNonQuery();
			}
			else
			{
				using var command = new NpgsqlCommand($@"INSERT INTO ""Пользователи"" (""имя_пользователя"", ""email_пользователя"") VALUES (@userFio,@userEmail)", conn, tx)
				{
					Parameters =
					{
						new("@userFio",user.fio),
						new("@userEmail",user.email)
					}
				};
					command.ExecuteNonQuery();
			}
		}
		private bool UserExists(string email, NpgsqlConnection conn, NpgsqlTransaction tx)
		{
			var check = "";
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
					check = string.Format(reader.GetInt32(0).ToString());
				}
				reader.Close();
				if (check.Length > 0) return true;
				return false;
			}
		}
	}
}
