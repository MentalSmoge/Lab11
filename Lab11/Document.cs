using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab11
{
	public class Document : IComparable, ICloneable, IInit, IEquatable<Document> //ДОКУМЕНТ
	{
		private DateTime date;
		public Money CostOfDocument;
		public override bool Equals(object obj)
		{
			if (obj == null) return false;
			Document objAsPart = obj as Document;
			if (objAsPart == null) return false;
			else return Equals(objAsPart);
		}
		public bool Equals(Document other)
		{
			if (other == null) return false;
			return (this.Date.Equals(other.Date) & this.CostOfDocument.Equals(other.CostOfDocument));
		}
		public virtual string Content
		{
			get
			{
				return this.ToString();
			}
		}
		public DateTime Date
		{
			get
			{
				return date;
			}
			set
			{
				date = value;
			}
		}
		public virtual Money WholeSum
		{
			get
			{
				return new Money();
			}
		}
		public override int GetHashCode()
		{
			return HashCode.Combine(Date, CostOfDocument);
		}
		public virtual int CompareTo(object obj)//реализация интерфейса. Сортировка по дате
		{
			Document temp = (Document)obj;//приведение к типу Document
			return this.Date.CompareTo(temp.Date);
			return 0;
		}
		public override string ToString()
		{
			return "Это пустой документ созданный " + Date;
		}
		static public DateTime RandomDay(Random a)
		{
			DateTime start = new DateTime(1995, 1, 1);
			int range = (DateTime.Today - start).Days;
			start = start.AddSeconds(a.Next(1, 86400));
			return start.AddDays(a.Next(range));
		}
		public Document(DateTime date, Money CostOfDoc)
		{
			Date = date;
			CostOfDocument = new Money(CostOfDoc.Rubles, CostOfDoc.Kopeks);
		}
		public Document()
		{
			Init();
		}
		public virtual object Clone()
		{
			return new Document(this.Date, this.CostOfDocument);
		}
		public virtual Document ShallowCopy() //поверхностное копирование
		{
			return (Document)this.MemberwiseClone();
		}

		public virtual void Init()
		{
			Random a = new Random();
			Date = RandomDay(a);
			CostOfDocument = Money.GetRandomMoney(ref a, 10, 100);
		}

	}
	public class SortByDate : IComparer
	{
		int IComparer.Compare(object ob1, object ob2)
		{
			Document s1 = (Document)ob1;
			Document s2 = (Document)ob2;
			return DateTime.Compare(s1.Date, s2.Date);
		}

	}
	public class SortByMoney : IComparer
	{
		int IComparer.Compare(object ob1, object ob2)
		{
			Document s1 = (Document)ob1;
			Document s2 = (Document)ob2;
			return s1.WholeSum.CompareTo(s2.WholeSum);
		}

	}
}