using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab11
{
	public class Invoice : Document, IComparable //НАКЛАДНАЯ
	{
		List<Product> products = new List<Product>();
		string receiver_name;
		string giver_name;
		//ИНФОРМАЦИЯ О ДОКУМЕНТЕ
		public override bool Equals(object obj)
		{
			if (obj == null) return false;
			Document objAsPart = obj as Document;
			if (objAsPart == null) return false;
			else return Equals(objAsPart);
		}
		public bool Equals(Invoice other)
		{
			if (other == null) return false;
			return (this.Date.Equals(other.Date) & this.CostOfDocument.Equals(other.CostOfDocument) & this.ProductsReciever.Equals(other.ProductsReciever) & this.ProductsGiver.Equals(other.ProductsGiver) & this.Products.Equals(other.Products) & this.WholeSum.Equals(other.WholeSum));
		}
		public Document BaseDocument
		{
			get
			{
				return new Document(Date, CostOfDocument);//возвращает объект базового класса
			}
		}

		public List<Product> Products
		{
			get
			{
				return products;
			}
			set
			{
				products = value;
			}
		}
		public string ProductsReciever
		{
			get
			{
				return receiver_name;
			}
			set
			{
				receiver_name = value;
			}
		}
		public string ProductsGiver
		{
			get
			{
				return giver_name;
			}
			set
			{
				giver_name = value;
			}
		}
		public override Money WholeSum
		{
			get
			{
				Money temp = new Money();
				foreach (Product item in Products)
				{
					temp += (item.Price * item.Quantity);
				}
				return temp;
			}
		}


		public override string ToString()
		{
			string temp = $"Накладная\nДата: {Date}\nКомпания-получатель {ProductsReciever}\nКомпания-продавец {ProductsGiver}\nТовары:\n";
			foreach (Product item in Products)
			{
				temp += "---";
				temp += item.GetInfo(true);
				temp += "\n";
			}
			temp += "Сумма за все товары: " + WholeSum.GetInString();
			return temp;
		}
		public Invoice(DateTime date, Money CostOfDoc, List<Product> products, string receiver_name, string giver_name) : base(date, CostOfDoc)
		{
			Products = products;
			ProductsReciever = receiver_name;
			ProductsGiver = giver_name;
		}
		public Invoice() : base()
		{
			
		}
		public override Invoice Clone()
		{
			return new Invoice(Date, CostOfDocument, Products, ProductsReciever, ProductsGiver);
		}
		public override Invoice ShallowCopy() //поверхностное копирование
		{
			return (Invoice)this.MemberwiseClone();
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
		}
		//Дата создания
		//Что (Лист)
		//Кому
		//Кем
	}
	


}
