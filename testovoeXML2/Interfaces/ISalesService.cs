﻿using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using testovoeXML2.Models;

namespace testovoeXML2.Interfaces
{
	internal interface ISalesService
	{
		void ProcessSales(Order order, NpgsqlConnection conn, NpgsqlTransaction tx);
	}
}
