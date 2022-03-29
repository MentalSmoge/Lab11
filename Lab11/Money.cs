using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab11
{
	public class Money : IComparable
	{
		static int count = 0;
		private int rubles = 0;
		private int kopeks = 0;
		public int CompareTo(object obj)//реализация интерфейса. Сортировка по дате
		{
			Money temp = (Money)obj;//приведение к типу Money
			if (this > temp) return 1;
			if (this < temp) return -1;
			return 0;
		}
		public string GetInString()
		{
			return (Rubles + " руб. " + Kopeks + " коп.");
		}
		public override string ToString()
		{
			return (Rubles + " руб. " + Kopeks + " коп.");
		}
		public static int Count
		{
			get
			{
				return count;
			}
		}
		public int Rubles
		{
			get
			{
				return rubles;
			}
			set
			{
				if (value < 0)
				{
					rubles = 0;
                    kopeks = 0;
				}
				else
					rubles = value;
			}
		}
		public int Kopeks
		{
			get
			{
				return kopeks;
			}
			set
			{
				if (value < 0)
				{
					rubles = 0;
					kopeks = 0;
				}
				else
				{
					if (value > 99)
					{
						rubles += value / 100;
						kopeks = value % 100;
					}
					else
						kopeks = value;
				}
				
			}
		}
		public void DeductMoney(Money deductible, out Log log)
		{
			int temp_kopeks = Kopeks;
			int temp_rubles = Rubles;
			if (Kopeks < deductible.Kopeks)
			{
				temp_kopeks += 100;
				temp_rubles -= 1;
			}

			if (temp_rubles - deductible.Rubles < 0)
			{
				log = new Log("В результате вычитания получается отрицательный результат. Значение переменной не изменилось.", false);
			}
			else
			{
				temp_kopeks -= deductible.Kopeks;
				temp_rubles -= deductible.Rubles;
				log = new Log("Операция вычитания прошла успешно", true);
				Rubles = temp_rubles;
				Kopeks = temp_kopeks;
			}
		}
		public void DeductMoney(Money deductible)
		{
			int temp_kopeks = Kopeks;
			int temp_rubles = Rubles;
			if (Kopeks < deductible.Kopeks)
			{
				temp_kopeks += 100;
				temp_rubles -= 1;
			}

			if (temp_rubles - deductible.Rubles < 0)
			{
				
			}
			else
			{
				temp_kopeks -= deductible.Kopeks;
				temp_rubles -= deductible.Rubles;
				Rubles = temp_rubles;
				Kopeks = temp_kopeks;
			}
		}
		static public Money DeductMoney(Money deducted, Money deductible, out Log log)
		{
			int temp_kopeks = deducted.Kopeks;
			int temp_rubles = deducted.Rubles;
			if (deducted.Kopeks < deductible.Kopeks)
			{
				temp_kopeks += 100;
				temp_rubles -= 1;
			}
			if (temp_rubles - deductible.Rubles < 0)
			{
				log = new Log("В результате вычитания получается отрицательный результат. Возврат изначального значения Money.", false);
				return deducted.Clone();
			}
			else
			{
				temp_kopeks -= deductible.Kopeks;
				temp_rubles -= deductible.Rubles;
				log = new Log("Операция вычитания прошла успешно", true);
				return new Money(temp_rubles, temp_kopeks);
			}
		}
		static public Money DeductMoney(Money deducted, Money deductible)
		{
			int temp_kopeks = deducted.Kopeks;
			int temp_rubles = deducted.Rubles;
			if (deducted.Kopeks < deductible.Kopeks)
			{
				temp_kopeks += 100;
				temp_rubles -= 1;
			}
			if (temp_rubles - deductible.Rubles < 0)
			{
				return deducted.Clone();
			}
			else
			{
				temp_kopeks -= deductible.Kopeks;
				temp_rubles -= deductible.Rubles;
				return new Money(temp_rubles, temp_kopeks);
			}
		}
		public void Clone(Money paste)
		{
			paste.Rubles = Rubles;
			paste.Kopeks = Kopeks;
		}
		public Money Clone()
		{
			Money temp = new Money();
			temp.Rubles = Rubles;
			temp.Kopeks = Kopeks;
			return temp;
		}
		public Money(int Rubles, int Kopeks)
		{
			this.Rubles = Rubles;
			this.Kopeks = Kopeks;
			count += 1;
		}
		public Money()
		{
			Rubles = 0;
			Kopeks = 0;
			count += 1;
		}
		~Money()
		{
			--count;
		}
		public static Money operator ++(Money m)
		{
			m.Kopeks++;
			return m;
		}
		public static Money operator --(Money m)
		{
			if (m.Kopeks <= 0)
			{
				if (m.Rubles >= 1)
				{
					m.Kopeks += 99;
					m.Rubles -= 1;
				}
				else
				{
					m.Kopeks = 0;
				}
			}
			else
				m.Kopeks--;

			return m;
		}
		public static implicit operator int(Money m)
		{
			return m.Rubles;
		}
		public static explicit operator double(Money m)
		{
			return m.Kopeks / 100d;
		}
		public static Money operator *(int quantity, Money m)
		{
			int temp_kop = m.Kopeks * quantity;
			int temp_rub = m.Rubles * quantity;
			return new Money (temp_rub, temp_kop);
		}
		public static Money operator *(Money m, int quantity)
		{
			int temp_kop = m.Kopeks * quantity;
			int temp_rub = m.Rubles * quantity;
			return new Money(temp_rub, temp_kop);
		}
		public static Money operator +(Money m1, Money m2)
		{
			Money temp = m1.Clone();
			temp.Rubles += m2.Rubles;
			temp.Kopeks += m2.Kopeks;
			return temp;
		}
		public static Money operator -(Money m, int kop)
		{
			Money temp = FromIntToKopeks(kop);
			return Money.DeductMoney(m, temp);
		}
		public static Money operator -(int kop, Money m)
		{
			Money temp = FromIntToKopeks(kop);
			return Money.DeductMoney(temp, m);
		}
		public static Money operator -(Money m1, Money m2)
		{
			return DeductMoney(m1, m2);
		}
		public static Money FromIntToKopeks(int kop)
		{
			return new Money(kop / 100, kop % 100);
		}
		public static bool operator ==(Money m1, Money m2)
		{
			return m1.Rubles == m2.Rubles && m1.Kopeks == m2.Kopeks;
		}
		public static bool operator !=(Money m1, Money m2)
		{
			return !(m1.Rubles == m2.Rubles && m1.Kopeks == m2.Kopeks);
		}
		public static bool operator >(Money m1, Money m2)
		{
			if (m1.Rubles > m2.Rubles)
				return true;
			else
			{
				if (m1.Rubles < m2.Rubles)
					return false;
				else
				{
					if (m1.Rubles == m2.Rubles)
					{
						if (m1.Kopeks > m2.Kopeks)
							return true;
						else
							return false;
					}
					else
						return false; //НЕДОСТИЖИМЫЙ КОД (В НОРМАЛЬНЫХ УСЛОВИЯХ)
				}
			}
		}
		public static bool operator <(Money m1, Money m2)
		{
			if (m1.Rubles < m2.Rubles)
				return true;
			else
			{
				if (m1.Rubles > m2.Rubles)
					return false;
				else
				{
					if (m1.Rubles == m2.Rubles)
					{
						if (m1.Kopeks < m2.Kopeks)
							return true;
						else
							return false;
					}
					else
						return false; //НЕДОСТИЖИМЫЙ КОД (В НОРМАЛЬНЫХ УСЛОВИЯХ)
				}
			}
		}
		public static bool operator >=(Money m1, Money m2)
		{
			if (m1.Rubles > m2.Rubles)
				return true;
			else
			{
				if (m1.Rubles < m2.Rubles)
					return false;
				else
				{
					if (m1.Rubles == m2.Rubles)
					{
						if (m1.Kopeks >= m2.Kopeks)
							return true;
						else
							return false;
					}
					else
						return false; //НЕДОСТИЖИМЫЙ КОД (В НОРМАЛЬНЫХ УСЛОВИЯХ)
				}
			}
		}
		public static bool operator <=(Money m1, Money m2)
		{
			if (m1.Rubles < m2.Rubles)
				return true;
			else
			{
				if (m1.Rubles > m2.Rubles)
					return false;
				else
				{
					if (m1.Rubles == m2.Rubles)
					{
						if (m1.Kopeks <= m2.Kopeks)
							return true;
						else
							return false;
					}
					else
						return false; //НЕДОСТИЖИМЫЙ КОД (В НОРМАЛЬНЫХ УСЛОВИЯХ)
				}
			}
		}
		public static Money GetRandomMoney(ref Random a, int min, int max)
		{
			int rub = a.Next(min, max);
			int kop = a.Next(0, 100);
			return new Money(rub, kop);
		}
		public override bool Equals(object obj)
		{
			Money money = (Money)obj;
			return (this.Rubles == money.Rubles) && (this.Kopeks == money.Kopeks);
		}
	}
}
