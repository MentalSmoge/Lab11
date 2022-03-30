using System;
using System.Collections;
using System.Linq;
using System.Collections.Generic;

namespace Lab11
{
	class Program
	{
		static void Main(string[] args)
		{
			MainMenu();
		}
		static Hashtable HashtableAdd(Hashtable hashtable, ref Log log)
		{
			bool flag = true;
			string key;
			do
			{
				Menu.PrintColor("Введите ключ элемента");
				key = Menu.GetInputString();
				flag = hashtable.ContainsKey(key);
				if (flag)
				{
					Menu.PrintColor("Указанный ключ уже есть в таблице. Пожалуйста, введите уникальный ключ", ConsoleColor.Red);
				}
			} while (flag);

			Menu.PrintColor("Введите тип элемента");
			Menu.PrintColor("1) Документ");
			Menu.PrintColor("2) Накладная");
			Menu.PrintColor("3) Чек");
			Menu.PrintColor("4) Квитанция");
			int type = Menu.GetInput(1, 4);
			switch (type)
			{
				case 1:
					hashtable.Add(key, new Document());
					log = new Log($"Добавлен элемент с ключем {key} типа Документ", true);
					break;
				case 2:
					hashtable.Add(key, new Invoice());
					log = new Log($"Добавлен элемент с ключем {key} типа Накладная", true);
					break;
				case 3:
					hashtable.Add(key, new Cheque());
					log = new Log($"Добавлен элемент с ключем {key} типа Чек", true);
					break;
				case 4:
					hashtable.Add(key, new Receipt());
					log = new Log($"Добавлен элемент с ключем {key} типа Квитанция", true);
					break;
				default:
					break;
			}
			return hashtable;
		}
		static Hashtable HashtableDelete(Hashtable hashtable, ref Log log)
		{
			bool flag = false;
			string key;
			do
			{
				Menu.PrintColor("Введите ключ элемента");
				key = Menu.GetInputString();
				flag = hashtable.ContainsKey(key);
				if (!flag)
				{
					Menu.PrintColor("Указанного ключа нет в таблице. Пожалуйста, введите существующий ключ", ConsoleColor.Red);
				}
			} while (!flag);
			hashtable.Remove(key);
			log = new Log($"Удален элемент с ключом {key}", true);
			return hashtable;
		}
		static Log HashtableCount(Hashtable hashtable)
		{
			int doc=0, inv=0, che=0, rec=0;
			foreach (DictionaryEntry item in hashtable)
			{
				if (item.Value.GetType() == typeof(Document))
				{
					doc += 1;
				}
				if (item.Value.GetType() == typeof(Invoice))
				{
					inv += 1;
				}
				if (item.Value.GetType() == typeof(Cheque))
				{
					che += 1;
				}
				if (item.Value.GetType() == typeof(Receipt))
				{
					rec += 1;
				}
			}
			Log log = new Log("Всего:\n", true);
			log.message += $"{doc} типа Документ\n";
			log.message += $"{inv} типа Накладная\n";
			log.message += $"{che} типа Чек\n";
			log.message += $"{rec} типа Квитанция\n";
			return log;
		}
		static Log HashtableFind(Hashtable hashtable)
		{
			Menu.PrintColor("Введите тип элемента");
			Menu.PrintColor("1) Документ");
			Menu.PrintColor("2) Накладная");
			Menu.PrintColor("3) Чек");
			Menu.PrintColor("4) Квитанция");
			int type = Menu.GetInput(1, 4);
			Log log = new Log("Ключи найденных элементов:\n", true);
			switch (type)
			{
				case 1:
					foreach (DictionaryEntry item in hashtable)
					{
						if (item.Value.GetType() == typeof(Document))
						{
							log.message += item.Key.ToString();
							log.message += "\n";
						}
					}
					break;
				case 2:
					foreach (DictionaryEntry item in hashtable)
					{
						if (item.Value.GetType() == typeof(Invoice))
						{
							log.message += item.Key.ToString();
							log.message += "\n";
						}
					}
					break;
				case 3:
					foreach (DictionaryEntry item in hashtable)
					{
						if (item.Value.GetType() == typeof(Cheque))
						{
							log.message += item.Key.ToString();
							log.message += "\n";
						}
					}
					break;
				case 4:
					foreach (DictionaryEntry item in hashtable)
					{
						if (item.Value.GetType() == typeof(Receipt))
						{
							log.message += item.Key.ToString();
							log.message += "\n";
						}
					}
					break;
				default:
					break;
			}
			return log;
		}
		static Log HashtableSum(Hashtable hashtable)
		{
			Menu.PrintColor("Введите тип элемента");
			Menu.PrintColor("1) Документ");
			Menu.PrintColor("2) Накладная");
			Menu.PrintColor("3) Чек");
			Menu.PrintColor("4) Квитанция");
			int type = Menu.GetInput(1, 4);
			Log log = new Log("Сумма найденных элементов:\n", true);
			Money money = new Money();
			switch (type)
			{
				case 1:
					Document f1;
					foreach (DictionaryEntry item in hashtable)
					{
						if (item.Value.GetType() == typeof(Document))
						{
							f1 = item.Value as Document;
							money += (f1.WholeSum);
						}
					}
					break;
				case 2:
					Invoice f2;
					foreach (DictionaryEntry item in hashtable)
					{
						if (item.Value.GetType() == typeof(Invoice))
						{
							f2 = item.Value as Invoice;
							money += (f2.WholeSum);
						}
					}
					break;
				case 3:
					Cheque f3;
					foreach (DictionaryEntry item in hashtable)
					{
						if (item.Value.GetType() == typeof(Cheque))
						{
							f3 = item.Value as Cheque;
							money += (f3.WholeSum);
						}
					}
					break;
				case 4:
					Receipt f4;
					foreach (DictionaryEntry item in hashtable)
					{
						if (item.Value.GetType() == typeof(Receipt))
						{
							f4 = item.Value as Receipt;
							money += (f4.WholeSum);
						}
					}
					break;
				default:
					break;
			}
			log.message += $"{money}";
			return log;
		}
		static Hashtable HashtableClone(Hashtable hashtable)
		{
			Hashtable clone = new Hashtable();
			foreach (DictionaryEntry item in hashtable)
			{
				Document document = item.Value as Document;
				clone[item.Key] = document.Clone();
			}
			return clone;
		}
		static void MenuHashtable()
		{
			bool exit = false;
			int output;
			Log log = new Log();
			Hashtable Documents = new Hashtable();
			Documents.Add("Пустой док", new Document());
			Documents.Add("Накладная", new Invoice());
			Documents.Add("Чек", new Cheque());
			Documents.Add("Квитанция", new Receipt());
			while (!exit)
			{
				Menu.Clear();
				Menu.PrintColor("Хэш-таблица:", ConsoleColor.White);
				Menu.PrintColor(Documents);
				Menu.PrintColor(log);
				log.Clear();
				Menu.PrintColor("1) Добавить элемент.");
				Menu.PrintColor("2) Удалить элемент по ключу.");
				Menu.PrintColor("3) Вывести кол-во элементов каждого типа");
				Menu.PrintColor("4) Вывести все элементы определенного типа");
				Menu.PrintColor("5) Посчитать сумму всех элементов определенного типа");
				Menu.PrintColor("6) Клонировать коллекцию");
				Menu.PrintColor("7) Найти элемент по ключу в коллекции");
				Menu.PrintColor("8) Выход");

				output = Menu.GetInput(1, 8, message: "Число введено не верно, или оно не подходит ни к одному из вариантов");
				switch (output)
				{
					case 1:
						HashtableAdd(Documents, ref log);
						break;
					case 2:
						if (Documents.Count <= 0)
						{
							log = new Log("Хэш-таблица пуста. Удаление невозможно. Пожалуйста, добавьте элементов", false);
						}
						else
						{
							HashtableDelete(Documents, ref log);
						}
						break;
					case 3:
						log = HashtableCount(Documents);
						break;
					case 4:
						log = HashtableFind(Documents);
						break;
					case 5:
						log = HashtableSum(Documents);
						break;
					case 6:
						Documents = HashtableClone(Documents);
						break;
					case 7:
						if (Documents.Count <= 0)
						{
							log = new Log("Хэш-таблица пуста. Поиск невозможен. Пожалуйста, добавьте элементов", false);
						}
						else
						{
							log = HashtableFindValue(Documents);
						}
						break;
					case 8:
						exit = true;
						break;
				}
			}
		}
		static Log HashtableFindValue(Hashtable hashtable)
		{
			bool flag = false;
			string key;
			do
			{
				Menu.PrintColor("Введите ключ элемента");
				key = Menu.GetInputString();
				flag = hashtable.ContainsKey(key);
				if (!flag)
				{
					Menu.PrintColor("Указанного ключа нет в таблице. Пожалуйста, введите существующий ключ", ConsoleColor.Red);
				}
			} while (!flag);
			Document document = (Document)hashtable[key];
			Log log = new Log(document.ToString(), true);
			return log;
		}
		static Dictionary<string, Document> DictionaryAdd(Dictionary<string, Document> dictionary, ref Log log)
		{
			bool flag = true;
			string key;
			do
			{
				Menu.PrintColor("Введите ключ элемента");
				key = Menu.GetInputString();
				flag = dictionary.ContainsKey(key);
				if (flag)
				{
					Menu.PrintColor("Указанный ключ уже есть в таблице. Пожалуйста, введите уникальный ключ", ConsoleColor.Red);
				}
			} while (flag);

			Menu.PrintColor("Введите тип элемента");
			Menu.PrintColor("1) Документ");
			Menu.PrintColor("2) Накладная");
			Menu.PrintColor("3) Чек");
			Menu.PrintColor("4) Квитанция");
			int type = Menu.GetInput(1, 4);
			switch (type)
			{
				case 1:
					dictionary.Add(key, new Document());
					log = new Log($"Добавлен элемент с ключем {key} типа Документ", true);
					break;
				case 2:
					dictionary.Add(key, new Invoice());
					log = new Log($"Добавлен элемент с ключем {key} типа Накладная", true);
					break;
				case 3:
					dictionary.Add(key, new Cheque());
					log = new Log($"Добавлен элемент с ключем {key} типа Чек", true);
					break;
				case 4:
					dictionary.Add(key, new Receipt());
					log = new Log($"Добавлен элемент с ключем {key} типа Квитанция", true);
					break;
				default:
					break;
			}
			return dictionary;
		}
		static Dictionary<string, Document> DictionaryDelete(Dictionary<string, Document> dictionary, ref Log log)
		{
			bool flag = false;
			string key;
			do
			{
				Menu.PrintColor("Введите ключ элемента");
				key = Menu.GetInputString();
				flag = dictionary.ContainsKey(key);
				if (!flag)
				{
					Menu.PrintColor("Указанного ключа нет в таблице. Пожалуйста, введите существующий ключ", ConsoleColor.Red);
				}
			} while (!flag);
			dictionary.Remove(key);
			log = new Log($"Удален элемент с ключом {key}", true);
			return dictionary;
		}
		static Log DictionaryCount(Dictionary<string, Document> dictionary)
		{
			int doc = 0, inv = 0, che = 0, rec = 0;
			foreach (var item in dictionary)
			{
				if (item.Value.GetType() == typeof(Document))
				{
					doc += 1;
				}
				if (item.Value.GetType() == typeof(Invoice))
				{
					inv += 1;
				}
				if (item.Value.GetType() == typeof(Cheque))
				{
					che += 1;
				}
				if (item.Value.GetType() == typeof(Receipt))
				{
					rec += 1;
				}
			}
			Log log = new Log("Всего:\n", true);
			log.message += $"{doc} типа Документ\n";
			log.message += $"{inv} типа Накладная\n";
			log.message += $"{che} типа Чек\n";
			log.message += $"{rec} типа Квитанция\n";
			return log;
		}
		static Log DictionaryFind(Dictionary<string, Document> dictionary)
		{
			Menu.PrintColor("Введите тип элемента");
			Menu.PrintColor("1) Документ");
			Menu.PrintColor("2) Накладная");
			Menu.PrintColor("3) Чек");
			Menu.PrintColor("4) Квитанция");
			int type = Menu.GetInput(1, 4);
			Log log = new Log("Ключи найденных элементов:\n", true);
			switch (type)
			{
				case 1:
					foreach (var item in dictionary)
					{
						if (item.Value.GetType() == typeof(Document))
						{
							log.message += item.Key.ToString();
							log.message += "\n";
						}
					}
					break;
				case 2:
					foreach (var item in dictionary)
					{
						if (item.Value.GetType() == typeof(Invoice))
						{
							log.message += item.Key.ToString();
							log.message += "\n";
						}
					}
					break;
				case 3:
					foreach (var item in dictionary)
					{
						if (item.Value.GetType() == typeof(Cheque))
						{
							log.message += item.Key.ToString();
							log.message += "\n";
						}
					}
					break;
				case 4:
					foreach (var item in dictionary)
					{
						if (item.Value.GetType() == typeof(Receipt))
						{
							log.message += item.Key.ToString();
							log.message += "\n";
						}
					}
					break;
				default:
					break;
			}
			return log;
		}
		static Log DictionarySum(Dictionary<string, Document> dictionary)
		{
			Menu.PrintColor("Введите тип элемента");
			Menu.PrintColor("1) Документ");
			Menu.PrintColor("2) Накладная");
			Menu.PrintColor("3) Чек");
			Menu.PrintColor("4) Квитанция");
			int type = Menu.GetInput(1, 4);
			Log log = new Log("Сумма найденных элементов:\n", true);
			Money money = new Money();
			switch (type)
			{
				case 1:
					foreach (var item in dictionary)
					{
						if (item.Value.GetType() == typeof(Document))
						{
							money += (item.Value.WholeSum);
						}
					}
					break;
				case 2:
					foreach (var item in dictionary)
					{
						if (item.Value.GetType() == typeof(Invoice))
						{
							money += (item.Value.WholeSum);
						}
					}
					break;
				case 3:
					foreach (var item in dictionary)
					{
						if (item.Value.GetType() == typeof(Cheque))
						{
							money += (item.Value.WholeSum);
						}
					}
					break;
				case 4:
					foreach (var item in dictionary)
					{
						if (item.Value.GetType() == typeof(Receipt))
						{
							money += (item.Value.WholeSum);
						}
					}
					break;
				default:
					break;
			}
			log.message += $"{money}";
			return log;
		}
		static Dictionary<string, Document> DictionaryClone(Dictionary<string, Document> dictionary)
		{
			Dictionary<string, Document> clone = new Dictionary<string, Document>();
			foreach (var item in dictionary)
			{
				clone[item.Key] = (Document)item.Value.Clone();
			}
			return clone;
		}
		static void MenuDictionary()
		{
			bool exit = false;
			int output;
			Log log = new Log();
			Dictionary<string, Document> Documents = new Dictionary<string, Document>();
			Documents.Add("Пустой док", new Document());
			Documents.Add("Накладная", new Invoice());
			Documents.Add("Чек", new Cheque());
			Documents.Add("Квитанция", new Receipt());
			while (!exit)
			{
				Menu.Clear();
				Menu.PrintColor("Словарь:", ConsoleColor.White);
				Menu.PrintColor(Documents);
				Menu.PrintColor(log);
				log.Clear();
				Menu.PrintColor("1) Добавить элемент.");
				Menu.PrintColor("2) Удалить элемент по ключу.");
				Menu.PrintColor("3) Вывести кол-во элементов каждого типа");
				Menu.PrintColor("4) Вывести все элементы определенного типа");
				Menu.PrintColor("5) Посчитать сумму всех элементов определенного типа");
				Menu.PrintColor("6) Клонировать коллекцию");
				Menu.PrintColor("7) Отсортировать и найти элемент по ключу в коллекции");
				Menu.PrintColor("8) Выход");

				output = Menu.GetInput(1, 8, message: "Число введено не верно, или оно не подходит ни к одному из вариантов");
				switch (output)
				{
					case 1:
						DictionaryAdd(Documents, ref log);
						break;
					case 2:
						if (Documents.Count <= 0)
						{
							log = new Log("Словарь пуст. Удаление невозможно. Пожалуйста, добавьте элементов", false);
						}
						else
						{
							DictionaryDelete(Documents, ref log);
						}
						break;
					case 3:
						log = DictionaryCount(Documents);
						break;
					case 4:
						log = DictionaryFind(Documents);
						break;
					case 5:
						log = DictionarySum(Documents);
						break;
					case 6:
						Documents = DictionaryClone(Documents);
						break;
					case 7:
						if (Documents.Count <= 0)
						{
							log = new Log("Хэш-таблица пуста. Поиск невозможен. Пожалуйста, добавьте элементов", false);
						}
						else
						{
							log = DictionarySortAndFindValue(Documents);
						}
						break;
					case 8:
						exit = true;
						break;
				}
			}
		}
		static Log DictionarySortAndFindValue(Dictionary<string, Document> keyValuePairs)
		{

			bool flag = false;
			string key;
			do
			{
				Menu.PrintColor("Введите ключ элемента");
				key = Menu.GetInputString();
				flag = keyValuePairs.ContainsKey(key);
				if (!flag)
				{
					Menu.PrintColor("Указанного ключа нет в таблице. Пожалуйста, введите существующий ключ", ConsoleColor.Red);
				}
			} while (!flag);
			Document document = keyValuePairs[key];
			Log log = new Log(document.ToString(), true);
			return new Log();
		}
		static void MenuTestCollection()
		{
			bool exit = false;
			int output;
			Log log = new Log();
			TestCollections testCollections = new TestCollections();
			while (!exit)
			{
				Menu.Clear();
				Menu.PrintColor(log);
				log.Clear();
				Menu.PrintColor("1) Время поиска в List");
				Menu.PrintColor("2) Добавить элемент.");
				Menu.PrintColor("3) Удалить элемент");
				Menu.PrintColor("4) Выход");

				output = Menu.GetInput(1, 4, message: "Число введено не верно, или оно не подходит ни к одному из вариантов");
				switch (output)
				{
					case 1:
						log = new Log("", ConsoleColor.Green);
						testCollections.FindInsortedDic_docKey(ref log);
						testCollections.FindInlist_invoice(ref log);
						testCollections.FindInlist_string(ref log);
						testCollections.FindInsortedDic_stringKey(ref log);
						testCollections.FindInsortedDic_docValue(ref log);
						break;
					case 2:
						testCollections = testCollections.AddElement(ref log);
						break;
					case 3:
						if (testCollections.list_invoice.Count <= 5)
						{
							log = new Log("Слишком мало элементов", false);
						}
						else
						{
							testCollections = testCollections.RemoveElement(ref log);
						}
						break;
					case 4:
						exit = true;
						break;
				}
			}
		}


		static void MainMenu()
		{
			bool exit = false;
			int output;
			while (!exit)
			{
				Menu.Clear();
				Menu.PrintColor("1) Hashtable");
				Menu.PrintColor("2) Dictionary <string, Document>");
				Menu.PrintColor("3) TestCollections");
				Menu.PrintColor("4) Выход");

				output = Menu.GetInput(1, 5, message: "Число введено не верно, или оно не подходит ни к одному из вариантов");
				switch (output)
				{
					case 1:
						MenuHashtable();
						break;
					case 2:
						MenuDictionary();
						break;
					case 3:
						MenuTestCollection();
						break;
					case 4:
						exit = true;
						break;
				}
			}
		}
	}
}
