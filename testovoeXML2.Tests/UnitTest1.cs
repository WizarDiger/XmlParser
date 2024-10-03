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
			orders = xmlParser.ParseXml("..\\TestXmls\\myXML.xml");
			Assert.AreEqual(no, orders.order[0].no, "Номер не совпадает");
		}
		[Test]
		public void CheckIfRegDateIsCorrectInFirstOrder()
		{
			var date = "2012.12.19";
			orders = xmlParser.ParseXml("..\\TestXmls\\myXML.xml");
			Assert.AreEqual(date, orders.order[0].reg_date, "Дата не совпадает");
		}
		[Test]
		public void CheckIfSumIsCorrectInFirstOrder()
		{
			var sum = "234022.25";
			orders = xmlParser.ParseXml("..\\TestXmls\\myXML.xml");
			Assert.AreEqual(sum, orders.order[0].sum, "Сумма не совпадает");
		}
		[Test]
		public void CheckIfFirstProductQunatityIsCorrectInFirstOrder()
		{
			var quantity = "2";
			orders = xmlParser.ParseXml("..\\TestXmls\\myXML.xml");
			Assert.AreEqual(quantity, orders.order[0].product[0].quantity, "Количество не совпадает");
		}
		[Test]
		public void CheckIfFirstProductNameIsCorrectInFirstOrder()
		{
			var name = "LG 1755";
			orders = xmlParser.ParseXml("..\\TestXmls\\myXML.xml");
			Assert.AreEqual(name, orders.order[0].product[0].name, "Имя не совпадает");
		}
		[Test]
		public void CheckIfFirstProductPriceIsCorrectInFirstOrder()
		{
			var price = "12000.75";
			orders = xmlParser.ParseXml("..\\TestXmls\\myXML.xml");
			Assert.AreEqual(price, orders.order[0].product[0].price, "Цена не совпадает");
		}
		[Test]
		public void CheckIfSecondProductQunatityIsCorrectInFirstOrder()
		{
			var quantity = "5";
			orders = xmlParser.ParseXml("..\\TestXmls\\myXML.xml");
			Assert.AreEqual(quantity, orders.order[0].product[1].quantity, "Количество не совпадает");
		}
		[Test]
		public void CheckIfSecondProductNameIsCorrectInFirstOrder()
		{
			var name = "Xiomi 12X";
			orders = xmlParser.ParseXml("..\\TestXmls\\myXML.xml");
			Assert.AreEqual(name, orders.order[0].product[1].name, "Имя не совпадает");
		}
		[Test]
		public void CheckIfSecondProductPriceIsCorrectInFirstOrder()
		{
			var price = "42000.75";
			orders = xmlParser.ParseXml("..\\TestXmls\\myXML.xml");
			Assert.AreEqual(price, orders.order[0].product[1].price, "Цена не совпадает");
		}
		[Test]
		public void CheckIfThirdProductQunatityIsCorrectInFirstOrder()
		{
			var quantity = "10";
			orders = xmlParser.ParseXml("..\\TestXmls\\myXML.xml");
			Assert.AreEqual(quantity, orders.order[0].product[2].quantity, "Количество не совпадает");
		}
		[Test]
		public void CheckIfThirdProductNameIsCorrectInFirstOrder()
		{
			var name = "Noname 14232";
			orders = xmlParser.ParseXml("..\\TestXmls\\myXML.xml");
			Assert.AreEqual(name, orders.order[0].product[2].name, "Имя не совпадает");
		}
		[Test]
		public void CheckIfThirdProductPriceIsCorrectInFirstOrder()
		{
			var price = "1.7";
			orders = xmlParser.ParseXml("..\\TestXmls\\myXML.xml");
			Assert.AreEqual(price, orders.order[0].product[2].price, "Цена не совпадает");
		}
		[Test]
		public void CheckIfUserNameIsCorrectInFirstOrder()
		{
			var name = "Иванов Иван Иванович";
			orders = xmlParser.ParseXml("..\\TestXmls\\myXML.xml");
			Assert.AreEqual(name, orders.order[0].user.fio, "Имя не совпадает");
		}
		[Test]
		public void CheckIfUserEmailIsCorrectInFirstOrder()
		{
			var email = "abc@email.com";
			orders = xmlParser.ParseXml("..\\TestXmls\\myXML.xml");
			Assert.AreEqual(email, orders.order[0].user.email, "Email не совпадает");
		}
		[Test]
		public void CheckIfNoIsCorrectInSecondOrder()
		{
			var no = "122";
			orders = xmlParser.ParseXml("..\\TestXmls\\myXML.xml");
			Assert.AreEqual(no, orders.order[1].no, "Номер не совпадает");
		}
		[Test]
		public void CheckIfRegDateIsCorrectInSecondOrder()
		{
			var date = "2018.01.09";
			orders = xmlParser.ParseXml("..\\TestXmls\\myXML.xml");
			Assert.AreEqual(date, orders.order[1].reg_date, "Дата не совпадает");
		}
		[Test]
		public void CheckIfSumIsCorrectInSecondOrder()
		{
			var sum = "126065.05";
			orders = xmlParser.ParseXml("..\\TestXmls\\myXML.xml");
			Assert.AreEqual(sum, orders.order[1].sum, "Сумма не совпадает");
		}
		[Test]
		public void CheckIfFirstProductQunatityIsCorrectInSecondOrder()
		{
			var quantity = "3";
			orders = xmlParser.ParseXml("..\\TestXmls\\myXML.xml");
			Assert.AreEqual(quantity, orders.order[1].product[0].quantity, "Количество не совпадает");
		}
		[Test]
		public void CheckIfFirstProductNameIsCorrectInSecondOrder()
		{
			var name = "Xiomi 12X";
			orders = xmlParser.ParseXml("..\\TestXmls\\myXML.xml");
			Assert.AreEqual(name, orders.order[1].product[0].name, "Имя не совпадает");
		}
		[Test]
		public void CheckIfFirstProductPriceIsCorrectInSecondOrder()
		{
			var price = "42000.75";
			orders = xmlParser.ParseXml("..\\TestXmls\\myXML.xml");
			Assert.AreEqual(price, orders.order[1].product[0].price, "Цена не совпадает");
		}
		public void CheckIfSecondProductQunatityIsCorrectInSecondOrder()
		{
			var quantity = "20";
			orders = xmlParser.ParseXml("..\\TestXmls\\myXML.xml");
			Assert.AreEqual(quantity, orders.order[1].product[1].quantity, "Количество не совпадает");
		}
		[Test]
		public void CheckIfSecondProductNameIsCorrectInSecondOrder()
		{
			var name = "Noname 222";
			orders = xmlParser.ParseXml("..\\TestXmls\\myXML.xml");
			Assert.AreEqual(name, orders.order[1].product[1].name, "Имя не совпадает");
		}
		[Test]
		public void CheckIfSecondProductPriceIsCorrectInSecondOrder()
		{
			var price = "3.14";
			orders = xmlParser.ParseXml("..\\TestXmls\\myXML.xml");
			Assert.AreEqual(price, orders.order[1].product[1].price, "Цена не совпадает");
		}
		[Test]
		public void CheckIfUserNameIsCorrectInSecondOrder()
		{
			var name = "Петров Виктор Семенович";
			orders = xmlParser.ParseXml("..\\TestXmls\\myXML.xml");
			Assert.AreEqual(name, orders.order[1].user.fio, "Имя не совпадает");
		}
		[Test]
		public void CheckIfUserEmailIsCorrectInSecondOrder()
		{
			var email = "xyz@email.com";
			orders = xmlParser.ParseXml("..\\TestXmls\\myXML.xml");
			Assert.AreEqual(email, orders.order[1].user.email, "Email не совпадает");
		}
	}
}