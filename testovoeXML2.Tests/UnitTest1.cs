using Microsoft.VisualStudio.TestPlatform.TestHost;
using System.Runtime.CompilerServices;
using testovoeXML2;
using NUnit.Framework;
using testovoeXML2.Models;
namespace testovoeXML2.Tests
{
	public class Tests
	{
		private XmlParser xmlParser;
		private Orders orders;
		[SetUp]
		public void Setup()
		{
			xmlParser = new XmlParser();
		}

		[Test]
		public void TestIfNull()
		{
			Assert.That(orders != null,"Файла нет");
		}
		[Test]
		public void CheckIfNoIsCorrectInFirstOrder()
		{
			var no = "1";
			orders = xmlParser.ParseXml("myXML.xml");
			Assert.AreEqual(no, orders.Order[0].Number, "Номер не совпадает");
		}
		[Test]
		public void CheckIfRegDateIsCorrectInFirstOrder()
		{
			var date = "2012.12.19";
			orders = xmlParser.ParseXml("myXML.xml");
			Assert.AreEqual(date, orders.Order[0].RegistrationDate, "Дата не совпадает");
		}
		[Test]
		public void CheckIfSumIsCorrectInFirstOrder()
		{
			var sum = "234022.25";
			orders = xmlParser.ParseXml("myXML.xml");
			Assert.AreEqual(sum, orders.Order[0].Sum, "Сумма не совпадает");
		}
		[Test]
		public void CheckIfFirstProductQunatityIsCorrectInFirstOrder()
		{
			var quantity = "2";
			orders = xmlParser.ParseXml("myXML.xml");
			Assert.AreEqual(quantity, orders.Order[0].Product[0].Quantity, "Количество не совпадает");
		}
		[Test]
		public void CheckIfFirstProductNameIsCorrectInFirstOrder()
		{
			var name = "LG 1755";
			orders = xmlParser.ParseXml("myXML.xml");
			Assert.AreEqual(name, orders.Order[0].Product[0].Name, "Имя не совпадает");
		}
		[Test]
		public void CheckIfFirstProductPriceIsCorrectInFirstOrder()
		{
			var price = "12000.75";
			orders = xmlParser.ParseXml("myXML.xml");
			Assert.AreEqual(price, orders.Order[0].Product[0].Price, "Цена не совпадает");
		}
		[Test]
		public void CheckIfSecondProductQunatityIsCorrectInFirstOrder()
		{
			var quantity = "5";
			orders = xmlParser.ParseXml("myXML.xml");
			Assert.AreEqual(quantity, orders.Order[0].Product[1].Quantity, "Количество не совпадает");
		}
		[Test]
		public void CheckIfSecondProductNameIsCorrectInFirstOrder()
		{
			var name = "Xiomi 12X";
			orders = xmlParser.ParseXml("myXML.xml");
			Assert.AreEqual(name, orders.Order[0].Product[1].Name, "Имя не совпадает");
		}
		[Test]
		public void CheckIfSecondProductPriceIsCorrectInFirstOrder()
		{
			var price = "42000.75";
			orders = xmlParser.ParseXml("myXML.xml");
			Assert.AreEqual(price, orders.Order[0].Product[1].Price, "Цена не совпадает");
		}
		[Test]
		public void CheckIfThirdProductQunatityIsCorrectInFirstOrder()
		{
			var quantity = "10";
			orders = xmlParser.ParseXml("myXML.xml");
			Assert.AreEqual(quantity, orders.Order[0].Product[2].Quantity, "Количество не совпадает");
		}
		[Test]
		public void CheckIfThirdProductNameIsCorrectInFirstOrder()
		{
			var name = "Noname 14232";
			orders = xmlParser.ParseXml("myXML.xml");
			Assert.AreEqual(name, orders.Order[0].Product[2].Name, "Имя не совпадает");
		}
		[Test]
		public void CheckIfThirdProductPriceIsCorrectInFirstOrder()
		{
			var price = "1.7";
			orders = xmlParser.ParseXml("myXML.xml");
			Assert.AreEqual(price, orders.Order[0].Product[2].Price, "Цена не совпадает");
		}
		[Test]
		public void CheckIfUserNameIsCorrectInFirstOrder()
		{
			var name = "Иванов Иван Иванович";
			orders = xmlParser.ParseXml("myXML.xml");
			Assert.AreEqual(name, orders.Order[0].User.Fio, "Имя не совпадает");
		}
		[Test]
		public void CheckIfUserEmailIsCorrectInFirstOrder()
		{
			var email = "abc@email.com";
			orders = xmlParser.ParseXml("myXML.xml");
			Assert.AreEqual(email, orders.Order[0].User.Email, "Email не совпадает");
		}
		[Test]
		public void CheckIfNoIsCorrectInSecondOrder()
		{
			var no = "122";
			orders = xmlParser.ParseXml("myXML.xml");
			Assert.AreEqual(no, orders.Order[1].Number, "Номер не совпадает");
		}
		[Test]
		public void CheckIfRegDateIsCorrectInSecondOrder()
		{
			var date = "2018.01.09";
			orders = xmlParser.ParseXml("myXML.xml");
			Assert.AreEqual(date, orders.Order[1].RegistrationDate, "Дата не совпадает");
		}
		[Test]
		public void CheckIfSumIsCorrectInSecondOrder()
		{
			var sum = "126065.05";
			orders = xmlParser.ParseXml("myXML.xml");
			Assert.AreEqual(sum, orders.Order[1].Sum, "Сумма не совпадает");
		}
		[Test]
		public void CheckIfFirstProductQunatityIsCorrectInSecondOrder()
		{
			var quantity = "3";
			orders = xmlParser.ParseXml("myXML.xml");
			Assert.AreEqual(quantity, orders.Order[1].Product[0].Quantity, "Количество не совпадает");
		}
		[Test]
		public void CheckIfFirstProductNameIsCorrectInSecondOrder()
		{
			var name = "Xiomi 12X";
			orders = xmlParser.ParseXml("myXML.xml");
			Assert.AreEqual(name, orders.Order[1].Product[0].Name, "Имя не совпадает");
		}
		[Test]
		public void CheckIfFirstProductPriceIsCorrectInSecondOrder()
		{
			var price = "42000.75";
			orders = xmlParser.ParseXml("myXML.xml");
			Assert.AreEqual(price, orders.Order[1].Product[0].Price, "Цена не совпадает");
		}
		public void CheckIfSecondProductQunatityIsCorrectInSecondOrder()
		{
			var quantity = "20";
			orders = xmlParser.ParseXml("myXML.xml");
			Assert.AreEqual(quantity, orders.Order[1].Product[1].Quantity, "Количество не совпадает");
		}
		[Test]
		public void CheckIfSecondProductNameIsCorrectInSecondOrder()
		{
			var name = "Noname 222";
			orders = xmlParser.ParseXml("myXML.xml");
			Assert.AreEqual(name, orders.Order[1].Product[1].Name, "Имя не совпадает");
		}
		[Test]
		public void CheckIfSecondProductPriceIsCorrectInSecondOrder()
		{
			var price = "3.14";
			orders = xmlParser.ParseXml("myXML.xml");
			Assert.AreEqual(price, orders.Order[1].Product[1].Price, "Цена не совпадает");
		}
		[Test]
		public void CheckIfUserNameIsCorrectInSecondOrder()
		{
			var name = "Петров Виктор Семенович";
			orders = xmlParser.ParseXml("myXML.xml");
			Assert.AreEqual(name, orders.Order[1].User.Fio, "Имя не совпадает");
		}
		[Test]
		public void CheckIfUserEmailIsCorrectInSecondOrder()
		{
			var email = "xyz@email.com";
			orders = xmlParser.ParseXml("myXML.xml");
			Assert.AreEqual(email, orders.Order[1].User.Email, "Email не совпадает");
		}
	}
}