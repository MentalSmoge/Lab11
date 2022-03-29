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
		List<Invoice> list_invoice = new List<Invoice>();
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
				Invoice invoice = new Invoice();
				if (i == 0)
				{
					First = invoice.Clone();
				}
				if (i == 500)
				{
					Middle = invoice.Clone();
				}
				if (i == 999)
				{
					Last = invoice.Clone();
				}
				list_invoice.Add(invoice.Clone());
				list_string.Add(invoice.ToString());
				sortedDic_doc.Add((Document)invoice.BaseDocument.Clone(), invoice.Clone());
				sortedDic_string.Add(invoice.ToString(), invoice.Clone());
			}
		}
		public TestCollections RemoveElement()
		{
			return this;
		}
		public TestCollections AddElement()
		{
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
			Document find = (Document)First.BaseDocument.Clone();
			stopwatch.Start();


			//ПОИСК ПЕРВОГО
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
			find = (Document)Middle.BaseDocument.Clone();
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
			find = (Document)Last.BaseDocument.Clone();
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
			log.message += $"Последний: {stopwatch.ElapsedTicks}\n";
			stopwatch.Reset();



			//ПОИСК НЕ В СПИСКЕ
			find = (Document)NotInTheList.BaseDocument.Clone();
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
