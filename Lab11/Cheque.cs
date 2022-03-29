using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab11
{
	public class Cheque : Invoice //ЧЕК
	{
		string payment_method;
		string cashier_name;
		//ИНФОРМАЦИЯ О ДОКУМЕНТЕ
		public string PaymentMethod
		{
			get
			{
				return payment_method;
			}
			set
			{
				payment_method = value;
			}
		}
		public string CashierName
		{
			get
			{
				return cashier_name;
			}
			set
			{
				cashier_name = value;
			}
		}
		public override string ToString()
		{
			string temp = $"Чек\nДата: {Date}\nПокупатель {ProductsReciever}\nКомпания-продавец {ProductsGiver}\nМетод оплаты: {PaymentMethod}\nКассир {CashierName}\nТовары:\n";
			foreach (Product item in Products)
			{
				temp += "---";
				temp += item.GetInfo(true);
				temp += "\n";
			}
			temp += "Сумма за все товары: " + WholeSum.GetInString();
			return temp;
		}
		Cheque(DateTime date, Money CostOfDoc, List<Product> products, string receiver_name, string giver_name, string payment_method, string cashier_name) : base(date, CostOfDoc, products, receiver_name, giver_name)
		{
			PaymentMethod = payment_method;
			CashierName = cashier_name;
		}
		public Cheque() : base()
		{
			
		}
		public override Cheque Clone()
		{
			return new Cheque(Date, CostOfDocument, Products, ProductsReciever, ProductsGiver, PaymentMethod, CashierName);
		}
		public override Cheque ShallowCopy() //поверхностное копирование
		{
			return (Cheque)this.MemberwiseClone();
		}
		public override void Init()
		{
			Products = new List<Product>();
			Products.Add(new Product());
			Products.Add(new Product());
			Random a = new Random();
			CostOfDocument = Money.GetRandomMoney(ref a, 10, 100);
			Date = RandomDay(a);
			string[] random_names = new string[10];
			random_names[0] = "Рога и Копыта";
			random_names[1] = "Чук и Гик";
			random_names[2] = "Биокей";
			random_names[3] = "Varvar brew";
			random_names[4] = "Эль Мохнатый Шмель";
			random_names[5] = "Крабы, гады и вино";
			random_names[6] = "Нали-вали";
			random_names[7] = "Pill & pommer";
			random_names[8] = "9 марта";
			random_names[9] = "Халасё";
			string[] random_pay = new string[2];
			random_pay[0] = "Наличные";
			random_pay[1] = "Карта";
			string[] random_cashier = new string[5];
			random_cashier[0] = "Вася";
			random_cashier[1] = "Ваня";
			random_cashier[2] = "Саша";
			random_cashier[3] = "Никита";
			random_cashier[4] = "Любовь";
			ProductsGiver = random_names[a.Next(0, 10)];
			ProductsReciever = random_cashier[a.Next(0, 5)];
			PaymentMethod = random_pay[a.Next(0, 2)];
			CashierName = random_cashier[a.Next(0, 5)];
		}
		//Содержание
		//Дата создания
		//Какие товары list string
		//Сумма для оплаты
		//Кассир
		//Компания
	}
}
