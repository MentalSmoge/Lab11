using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab11
{
	public class Receipt : Invoice //КВИТАНЦИЯ
	{
		//ИНФОРМАЦИЯ О ДОКУМЕНТЕ
		string type;
		public string Type
		{
			get
			{
				return type;
			}
			set
			{
				type = value;
			}
		}
		public override string ToString()
		{
			string temp = $"Квитанция\nДата: {Date}\nКомпания-перевозчик {ProductsReciever}\nКомпания-владелец {ProductsGiver}\nМетод транспортировки: {Type}\nТовары:\n";
			foreach (Product item in Products)
			{
				temp += "---";
				temp += item.GetInfo(true);
				temp += "\n";
			}
			temp += "Сумма за все товары: " + WholeSum.GetInString();
			return temp;
		}
		Receipt(DateTime date, Money CostOfDoc, List<Product> products, string receiver_name, string giver_name, string type) : base(date, CostOfDoc, products, receiver_name, giver_name)
		{
			Type = type;
		}
		public Receipt() : base()
		{
			
		}
		public override Receipt Clone()
		{
			return new Receipt(Date, CostOfDocument, Products, ProductsReciever, ProductsGiver, Type);
		}
		public override Receipt ShallowCopy() //поверхностное копирование
		{
			return (Receipt)this.MemberwiseClone();
		}
		public override void Init()
		{
			Products = new List<Product>();
			Products.Add(new Product());
			Products.Add(new Product());
			Random a = new Random();
			Date = RandomDay(a);
			string[] random_names = new string[10];
			CostOfDocument = Money.GetRandomMoney(ref a, 10, 100);
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
			ProductsReciever = random_names[a.Next(0, 10)];
			ProductsGiver = random_names[a.Next(0, 10)];
			string[] random_type = new string[5];
			random_type[0] = "Самолет";
			random_type[1] = "Вертолет";
			random_type[2] = "Автомобиль";
			random_type[3] = "Почта";
			random_type[4] = "Корабль";
			Type = random_type[a.Next(0, 5)];
		}
		//Какие товары list string
		//Сумма для оплаты
		//Имя оплатившего
		//ИНН тому кому платили
		//Содержание
		//Дата создания
	}
}
