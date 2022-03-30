using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace Lab11
{
	class TestCollections
	{
		public List<Invoice> list_invoice = new List<Invoice>();
		List<string> list_string = new List<string>();
		SortedDictionary<Document, Invoice> sortedDic_doc = new SortedDictionary<Document, Invoice>();
		SortedDictionary<string, Invoice> sortedDic_string = new SortedDictionary<string, Invoice>();
		Invoice First;
		Invoice Last;
		Invoice Middle;
		Invoice NotInTheList = new Invoice(DateTime.MinValue, new Money(), new List<Product>(), "Сева", "Сева"); //НЕ В ЛИСТЕ

		public TestCollections()
		{
			for (int i = 0; i < 1000; i++)
			{
				Invoice invoice;
				do
				{
					invoice = new Invoice();
				} while (list_invoice.Contains(invoice));
				if (i == 1)
				{
					First = invoice;
				}
				if (i == 500)
				{
					Middle = invoice;
				}
				if (i == 999)
				{
					Last = invoice;
				}
				list_invoice.Add(invoice);
				list_string.Add(invoice.ToString());
				sortedDic_doc.Add((Document)invoice.BaseDocument, invoice.Clone());
				sortedDic_string.Add(invoice.ToString(), invoice.Clone());
			}
		}
		public TestCollections RemoveElement(ref Log log)
		{
			list_invoice.Remove(First);
			list_string.Remove(First.ToString());
			sortedDic_doc.Remove(First.BaseDocument);
			sortedDic_string.Remove(First.ToString());

			log = new Log("Удален первый элемент", true);
			First = list_invoice[0];
			Middle = list_invoice[list_invoice.Count / 2];
			Last = list_invoice[list_invoice.Count - 1];
			return this;
		}
		public TestCollections AddElement(ref Log log)
		{
			Invoice invoice;
			do
			{
				invoice = new Invoice();
			} while (list_invoice.Contains(invoice));

			list_invoice.Add(invoice);
			list_string.Add(invoice.ToString());
			sortedDic_doc.Add((Document)invoice.BaseDocument, invoice.Clone());
			sortedDic_string.Add(invoice.ToString(), invoice.Clone());

			log = new Log("Добавлен элемент", true);
			First = list_invoice[0];
			Middle = list_invoice[list_invoice.Count / 2];
			Last = list_invoice[list_invoice.Count - 1];
			return this;
		}
		//ДОБАВЛЕНИЕ И УДАЛЕНИЕ ЭЛЕМЕНТОВ
		//ПОИСК ПЕРВОГО, ПОСЛЕДНЕГО, СЕРЕДИННОГО И НЕСУЩЕСТВУЮЩЕГО
		public void FindInlist_invoice(ref Log log)
		{
			log.message += "Время на поиск в List<Invoice>:\n";
			//создаем объект
			Stopwatch stopwatch = new Stopwatch();
			//засекаем время начала операции
			stopwatch.Start();

			if (list_invoice.Contains(First))
			{
				log.message += "Найден\n";
			}
			else
			{
				log.message += "Нет\n";
			}
			stopwatch.Stop();
			log.message += $"Первый: {stopwatch.ElapsedTicks}\n";
			stopwatch.Reset();
			stopwatch.Start();
			if (list_invoice.Contains(Middle))
			{
				log.message += "Найден\n";
			}
			else
			{
				log.message += "Нет\n";
			}
			stopwatch.Stop();
			log.message += $"Середина: {stopwatch.ElapsedTicks}\n";
			stopwatch.Reset();
			stopwatch.Start();
			if (list_invoice.Contains(Last))
			{
				log.message += "Найден\n";
			}
			else
			{
				log.message += "Нет\n";
			}
			stopwatch.Stop();
			log.message += $"Последний: {stopwatch.ElapsedTicks}\n";
			stopwatch.Reset();
			stopwatch.Start();
			if (list_invoice.Contains(NotInTheList))
			{
				log.message += "Найден\n";
			}
			else
			{
				log.message += "Нет\n";
			}
			stopwatch.Stop();
			log.message += $"Не в списке: {stopwatch.ElapsedTicks}\n\n";
			stopwatch.Reset();
			//смотрим сколько миллисекунд было затрачено на выполнение
		}
		public void FindInlist_string(ref Log log)
		{
			log.message += "Время на поиск в List<string>:\n";
			//создаем объект
			Stopwatch stopwatch = new Stopwatch();
			//засекаем время начала операции

			//ПОИСК ПЕРВОГО
			string find = First.ToString();
			stopwatch.Start();
			if (list_string.Contains(find))
			{
				log.message += "Найден\n";
			}
			else
			{
				log.message += "Нет\n";
			}
			stopwatch.Stop();
			log.message += $"Первый: {stopwatch.ElapsedTicks}\n";
			stopwatch.Reset();

			//ПОИСК СЕРЕДИННОГО
			find = Middle.ToString();
			stopwatch.Start();
			if (list_string.Contains(find))
			{
				log.message += "Найден\n";
			}
			else
			{
				log.message += "Нет\n";
			}
			stopwatch.Stop();
			log.message += $"Середина: {stopwatch.ElapsedTicks}\n";
			stopwatch.Reset();
			stopwatch.Start();

			//ПОИСК ПОСЛЕДНЕГО
			find = Last.ToString();
			if (list_string.Contains(find))
			{
				log.message += "Найден\n";
			}
			else
			{
				log.message += "Нет\n";
			}
			stopwatch.Stop();
			log.message += $"Последний: {stopwatch.ElapsedTicks}\n";
			stopwatch.Reset();
			stopwatch.Start();

			//ПОИСК НЕ В СПИСКЕ
			find = NotInTheList.ToString();
			if (list_string.Contains(find))
			{
				log.message += "Найден\n";
			}
			else
			{
				log.message += "Нет\n";
			}
			stopwatch.Stop();
			log.message += $"Не в списке: {stopwatch.ElapsedTicks}\n\n";
			stopwatch.Reset();
			//смотрим сколько миллисекунд было затрачено на выполнение
		}
		public void FindInsortedDic_docKey(ref Log log)
		{
			log.message += "Время на поиск по ключу в SortedDictionary<Document, Invoice>:\n";
			//создаем объект
			Stopwatch stopwatch = new Stopwatch();
			//засекаем время начала операции


			//ПОИСК ПЕРВОГО
			Document find = null;
			find = (Document)First.BaseDocument;
			stopwatch.Start();
			Menu.PrintColor("Первый");
			if (sortedDic_doc.ContainsKey(find))
			{
				log.message += "Найден\n";
			}
			else
			{
				log.message += "Нет\n";
			}
			stopwatch.Stop();
			log.message += $"Первый: {stopwatch.ElapsedTicks}\n";
			stopwatch.Reset();



			//ПОИСК СЕРЕДИННОГО
			find = (Document)Middle.BaseDocument;
			stopwatch.Start();
			if (sortedDic_doc.ContainsKey(find))
			{
				log.message += "Найден\n";
			}
			else
			{
				log.message += "Нет\n";
			}
			stopwatch.Stop();
			log.message += $"Середина: {stopwatch.ElapsedTicks}\n";
			stopwatch.Reset();



			//ПОИСК ПОСЛЕДНЕГО
			find = (Document)Last.BaseDocument;
			stopwatch.Start();
			Menu.PrintColor("Последний");
			if (sortedDic_doc.ContainsKey(find))
			{
				log.message += "Найден\n";
			}
			else
			{
				log.message += "Нет\n";
			}
			stopwatch.Stop();
			log.message += $"Последний: {stopwatch.ElapsedTicks}\n";
			stopwatch.Reset();




			//ПОИСК НЕ В СПИСКЕ
			find = (Document)NotInTheList;
			stopwatch.Start();
			if (sortedDic_doc.ContainsKey(find))
			{
				log.message += "Найден\n";
			}
			else
			{
				log.message += "Нет\n";
			}
			stopwatch.Stop();
			log.message += $"Не в списке: {stopwatch.ElapsedTicks}\n\n";
			stopwatch.Reset();
			//смотрим сколько миллисекунд было затрачено на выполнение
		}
		public void FindInsortedDic_stringKey(ref Log log)
		{
			log.message += "Время на поиск по ключу в SortedDictionary<string, Invoice>:\n";
			//создаем объект
			Stopwatch stopwatch = new Stopwatch();
			//засекаем время начала операции
			string find = First.ToString();
			stopwatch.Start();


			//ПОИСК ПЕРВОГО
			if (sortedDic_string.ContainsKey(find))
			{
				log.message += "Найден\n";
			}
			else
			{
				log.message += "Нет\n";
			}
			stopwatch.Stop();
			log.message += $"Первый: {stopwatch.ElapsedTicks}\n";
			stopwatch.Reset();



			//ПОИСК СЕРЕДИННОГО
			find = Middle.ToString();
			stopwatch.Start();
			if (sortedDic_string.ContainsKey(find))
			{
				log.message += "Найден\n";
			}
			else
			{
				log.message += "Нет\n";
			}
			stopwatch.Stop();
			log.message += $"Середина: {stopwatch.ElapsedTicks}\n";
			stopwatch.Reset();



			//ПОИСК ПОСЛЕДНЕГО
			find = Last.ToString();
			stopwatch.Start();
			if (sortedDic_string.ContainsKey(find))
			{
				log.message += "Найден\n";
			}
			else
			{
				log.message += "Нет\n";
			}
			stopwatch.Stop();
			log.message += $"Последний: {stopwatch.ElapsedTicks}\n";
			stopwatch.Reset();



			//ПОИСК НЕ В СПИСКЕ
			find = NotInTheList.ToString();
			stopwatch.Start();
			if (sortedDic_string.ContainsKey(find))
			{
				log.message += "Найден\n";
			}
			else
			{
				log.message += "Нет\n";
			}
			stopwatch.Stop();
			log.message += $"Не в списке: {stopwatch.ElapsedTicks}\n\n";
			stopwatch.Reset();
			//смотрим сколько миллисекунд было затрачено на выполнение
		}
		public void FindInsortedDic_docValue(ref Log log)
		{
			log.message += "Время на поиск по значению в SortedDictionary<Document, Invoice>:\n";
			//создаем объект
			Stopwatch stopwatch = new Stopwatch();
			//засекаем время начала операции
			stopwatch.Start();


			//ПОИСК ПЕРВОГО
			if (sortedDic_doc.ContainsValue(First))
			{
				log.message += "Найден\n";
			}
			else
			{
				log.message += "Нет\n";
			}
			stopwatch.Stop();
			log.message += $"Первый: {stopwatch.ElapsedTicks}\n";
			stopwatch.Reset();



			//ПОИСК СЕРЕДИННОГО
			stopwatch.Start();
			if (sortedDic_doc.ContainsValue(Middle))
			{
				log.message += "Найден\n";
			}
			else
			{
				log.message += "Нет\n";
			}
			stopwatch.Stop();
			log.message += $"Середина: {stopwatch.ElapsedTicks}\n";
			stopwatch.Reset();



			//ПОИСК ПОСЛЕДНЕГО
			stopwatch.Start();
			if (sortedDic_doc.ContainsValue(Last))
			{
				log.message += "Найден\n";
			}
			else
			{
				log.message += "Нет\n";
			}
			stopwatch.Stop();
			log.message += $"Последний: {stopwatch.ElapsedTicks}\n";
			stopwatch.Reset();



			//ПОИСК НЕ В СПИСКЕ
			stopwatch.Start();
			if (sortedDic_doc.ContainsValue(NotInTheList))
			{
				log.message += "Найден\n";
			}
			else
			{
				log.message += "Нет\n";
			}
			stopwatch.Stop();
			log.message += $"Не в списке: {stopwatch.ElapsedTicks}\n";
			stopwatch.Reset();
			//смотрим сколько миллисекунд было затрачено на выполнение
		}
	}
}