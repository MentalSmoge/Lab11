using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace Lab11
{
	class Menu
	{
		public static void PrintColor(string message, ConsoleColor color = ConsoleColor.Gray, bool line_break = true) //Цветной вывод в консоль
		{
			Console.ForegroundColor = color;
			Console.Write(message);
			if (line_break)
				Console.WriteLine();
			Console.ResetColor();
		}
		public static void PrintColor(Money money, ConsoleColor color = ConsoleColor.Gray, bool line_break = true) //Цветной вывод в консоль
		{
			Console.ForegroundColor = color;
			Console.Write(money.GetInString());
			if (line_break)
				Console.WriteLine();
			Console.ResetColor();
		}
		public static void PrintColor(Hashtable hashtable, bool line_break = true) //Цветной вывод в консоль
		{
			foreach (DictionaryEntry item in hashtable)
			{
				PrintColor(item.Key.ToString() + ":", ConsoleColor.Green);
				PrintColor(item.Value.ToString() + "\n", ConsoleColor.Yellow);
			}
			if (line_break)
				Console.WriteLine();
			Console.ResetColor();
		}
		public static void PrintColor(Dictionary<string, Document> dictionary, bool line_break = true) //Цветной вывод в консоль
		{
			foreach (var item in dictionary)
			{
				PrintColor(item.Key.ToString() + ":", ConsoleColor.Green);
				PrintColor(item.Value.ToString() + "\n", ConsoleColor.Yellow);
			}
			if (line_break)
				Console.WriteLine();
			Console.ResetColor();
		}
		public static void PrintColor(Log log) //Цветной вывод в консоль
		{
			if (log.color == ConsoleColor.White) // Стандартное значение цвета - белый
			{
				if (log.success)
					Console.ForegroundColor = ConsoleColor.Green;
				else
					Console.ForegroundColor = ConsoleColor.Red;
			}
			else
			{
				Console.ForegroundColor = log.color; //Если специально указан цвет - не рассматривать success
			}

			if (log.message != "")
			{
				Console.Write(log.message);
				Console.WriteLine();
			}
			else
			{

			}
			Console.ResetColor();
		}
		public static int GetInput(int min, int max, bool line_break = true, string message = "Число введено не верно!") //Проверка ввода с границами
		{
			string buf;
			bool ok;
			int output;
			do
			{
				buf = Console.ReadLine();
				ok = int.TryParse(buf, out output);
				if (!ok || output < min || output > max)
				{
					PrintColor(message, ConsoleColor.Red);
					ok = false;
				}
			} while (!ok);
			if (line_break)
				Console.WriteLine();
			return output;
		}
		public static string GetInputString(bool line_break = true) //Проверка ввода с границами
		{
			string buf;
			buf = Console.ReadLine();
			if (line_break)
				Console.WriteLine();
			return buf;
		}
		public static void Clear()
		{
			Console.Clear();
		}
	}
}
