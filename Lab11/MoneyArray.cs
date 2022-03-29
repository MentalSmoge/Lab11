using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab11
{
	public class MoneyArray
	{
		static int count;
		Money[] arr;//одномерный массив элементов типа Money
		int size;
		static public int Count
		{
			get
			{
				return count;
			}
		}
		public int Size
		{
			get
			{
				return size;
			}
		}
		public MoneyArray()
		{
			size = 0;
			arr = new Money[size];
			count++;
		}
		public MoneyArray(int size, bool random)
		{
			this.size = size;
			arr = new Money[Size];
			if (random)
            {
                Random a = new Random();
                for (int i = 0; i < size; i++)
				{
                    int rub = a.Next(0, 100);
                    int kop = a.Next(0, 100);
                    arr[i] = new Money(rub, kop);
				}
			}
			else
			{
				for (int i = 0; i < size; i++)
				{
					int kop;
					int rub;
					Menu.PrintColor("Введите руб. от 0 до 99 для " + (i + 1) + " элемента: ", line_break: false);
					rub = Menu.GetInput(0, 99, message: "Или число введено не верно, или число не может быть меньше 0");
					Menu.PrintColor("Введите коп. от 0 до 99 для " + (i + 1) + " элемента: ", line_break: false);
					kop = Menu.GetInput(0, 99, message: "Или число введено не верно, или число не может быть меньше 0");
					arr[i] = new Money(rub, kop);
				}
			}
			count++;
		}
		public string Print(bool line_break = true)
		{
			string message = "";
			if (Size == 0)
			{
				return "Массив пуст";
			}
			for (int i = 0; i < Size-1; i++)
			{
				if (line_break)
					message += ((i + 1) + ": ");
				message += arr[i].GetInString();
				if (line_break)
					message += "\n";
				else
					message += ", ";
			}
			if (line_break)
				message += ((Size) + ": ");
			message += arr[Size-1].GetInString();
			return message;
		}
		public Money this[int index]
		{
			get
			{
				if (index >= 0 && index < arr.Length)
					return arr[index];
				throw new IndexOutOfRangeException();
			}
			set
			{
				if (index >= 0 && index < arr.Length)
					arr[index] = value;
				else
					Menu.PrintColor("Выход за границу массива");
			}
		}
		~MoneyArray()
		{
			--count;
		}
		public Money FindBiggest()
		{
			Money result = new Money();
			for (int i = 0; i < Size; i++)
			{
				if (arr[i] >= result)
				{
					result = arr[i];
				}
			}
			return result.Clone();
		}
		public void Delete(int index)
		{
			Money[] new_m = new Money[Size - 1];
			int counter = 0;

			for (int i = 0; i < Size; i++)
			{
				if (i == index) 
					continue;
				new_m[counter] = arr[i];
				counter++;
			}
			size -= 1;
			arr = new_m;
		}
		public void InsertNew(int index, Money money)
		{
			Money[] new_m = new Money[Size + 1];
			int old_i = 0;
			for (int i = 0; i < new_m.Length; i++)
			{
				if (i == (index - 1))
				{
					new_m[i] = money;
				}
				else
				{
					new_m[i] = arr[old_i];
					old_i++;
				}
			}
			size += 1;
			arr = new_m;
		}
	}
}
