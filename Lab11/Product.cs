using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab11
{
	public class Product : IInit
	{
		Money price;
		int quantity;
		string name;
		public virtual void Init()
		{
			Random a = new Random();
			Quantity = a.Next(2, 10);
			Price = Money.GetRandomMoney(ref a, 20, 150);
			string[] random_names = new string[10];
			random_names[0] = "Вода";
			random_names[1] = "Хлеб ржаной";
			random_names[2] = "Хлеб белый";
			random_names[3] = "Печенье";
			random_names[4] = "Конфета";
			random_names[5] = "Туалетная бумага";
			random_names[6] = "Тетрадь";
			random_names[7] = "Зефир";
			random_names[8] = "Кефир";
			random_names[9] = "Молоко";
			Name = random_names[a.Next(0, 10)];
		}
		public int Quantity
		{
			get
			{
				return quantity;
			}
			set
			{
				if (value <= 0)
				{
					quantity = 0;
				}
				else
					quantity = value;
			}
		}
		public Money Price
		{
			get
			{
				return price;
			}
			set
			{
				price = value;
			}
		}
		public string Name
		{
			get
			{
				return name;
			}
			set
			{
				name = value;
			}
		}
		public Product(Money price, int quantity, string name)
		{
			Price = price;
			Name = name;
			Quantity = quantity;
		}
		public Product()
		{
			Init();
		}
		public string GetInfo(bool withPrices)
		{
			string temp;
			if (withPrices)
				temp = (name + ", " + Price.GetInString() + ", кол-во: " + Quantity + " шт. Итоговая цена: " + (Quantity*Price).GetInString());
			else
				temp = (name + ", кол-во: " + Quantity + " шт.");
			return temp;
		}
		public override string ToString()
		{
			return name + ", " + Price.GetInString() + ", кол-во: " + Quantity + " шт. Итоговая цена: " + (Quantity * Price).GetInString(); ;
		}
	}
}
