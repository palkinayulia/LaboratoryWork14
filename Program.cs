using ClassLibrary10Lab;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using Лабораторная_работа_12_4;
namespace Лабораторная_работа_14
{
    public class Program
    {
        [ExcludeFromCodeCoverage]
        static List<Watch> MakeCollection(int length)
        {
            var list = new List<Watch>();
            for (int i = 0; i < length; i++)
            {
                Watch c = new Watch();
                c.RandomInit();
                list.Add(c);
            }
            return list;
        }
        [ExcludeFromCodeCoverage]
        static Dictionary<string, List<Watch>> MakeDictionary(int length)
        {
            var dictionary = new Dictionary<string, List<Watch>>();
            var list = new List<Watch>();
            for (int i = 0; i < length; i++)
            {
                Console.WriteLine($"Количество элементов в {i + 1} магазине: ");
                list = MakeCollection(NumberCheck());
                int n = i + 1;
                string number = "Магазин" + n.ToString();
                dictionary.Add(number, list);
            }
            return dictionary;
        }
        [ExcludeFromCodeCoverage]
        static void PrintCollection(List<Watch> list)
        {
            if (list.Count == 0)
            {
                Console.WriteLine("Empty collection");
            }
            foreach (var item in list)
            {
                Console.WriteLine(item);
            }
        }
        [ExcludeFromCodeCoverage]
        static void PrintDictionary(Dictionary<string, List<Watch>> d)
        {
            if (d.Count == 0)
            {
                Console.WriteLine("Empty collection");
            }
            foreach (var item in d)
            {
                Console.Write(item.Key + ": ");
                PrintCollection(item.Value); //список часов для данного магазина
                Console.WriteLine();
            }
        }
        [ExcludeFromCodeCoverage]
        static int NumberCheck() //проверка ввода числа
        {
            bool isConvert;
            int n;
            do
            {
                Console.Write("Введите число: ");
                string input = Console.ReadLine();
                isConvert = int.TryParse(input, out n);
                if (!isConvert || n <= 0) Console.WriteLine("Неправильно введено число \nПопробуйте еще раз.");
            } while (!isConvert || n <= 0);
            return n;
        }

        public static List<Watch> WhereLINQ(Dictionary<string, List<Watch>> dictionary)
        {
            var res = from item in dictionary.Values
                      from watch in item
                      where watch is Watch && ((Watch)watch).YearIssue > 1900
                      select (Watch)watch;
            return res.ToList();
        }
        public static List<Watch> WhereExtencion(Dictionary<string, List<Watch>> dictionary)
        {
            var res = dictionary.SelectMany(x => x.Value)
                        .Where(watch => watch.YearIssue > 1900)
                        .ToList();
            return res;
        }
        public static List<Watch> UnionExtencion(Dictionary<string, List<Watch>> dictionary, Dictionary<string, List<Watch>> dictionary2)
        {
            var res = dictionary.Values.SelectMany(x => x)
                .Union(dictionary2.Values.SelectMany(x => x))
                .ToList();
            return res;
        }
        public static List<Watch> UnionLINQ(Dictionary<string, List<Watch>> dictionary, Dictionary<string, List<Watch>> dictionary2)
        {

            var res = (from item1 in dictionary.Values select item1)
                .Concat(from item in dictionary2.Values select item)
                .Distinct()
                .SelectMany(x => x)
                .ToList();
            return res;
        }
        public static int MaxLINQ(Dictionary<string, List<Watch>> dictionary)
        {

            var res = (from item in dictionary.Values
                       from item2 in item
                       where item2 is Watch
                       select ((Watch)item2).YearIssue).Max();
            return res;
        }
        public static int MaxExtencion(Dictionary<string, List<Watch>> dictionary)
        {

            var res = dictionary.Values.SelectMany(list => list)
                                 .Where(item => item is Watch watch)
                                 .Select(watch => watch.YearIssue)
                                 .Max();
            return res;
        }
        public static int MinLINQ(Dictionary<string, List<Watch>> dictionary)
        {

            var res = (from item in dictionary.Values
                       from item2 in item
                       where item2 is Watch
                       select ((Watch)item2).YearIssue).Min();
            return res;
        }
        public static int MinExtencion(Dictionary<string, List<Watch>> dictionary)
        {

            var res = dictionary.Values.SelectMany(list => list)
                                 .Where(item => item is Watch watch)
                                 .Select(watch => watch.YearIssue)
                                 .Min();
            return res;
        }
        public static IEnumerable<IGrouping<int, Watch>> GroupLINQ(Dictionary<string, List<Watch>> dictionary)
        {

            var res = from item in dictionary.Values
                      from item2 in item
                      group item2 by item2.YearIssue;
            return res;
        }
        public static IEnumerable<IGrouping<int, Watch>> GroupExtencion(Dictionary<string, List<Watch>> dictionary)
        {

            var res = dictionary.Values.SelectMany(list => list)
                                 .Where(item => item is Watch watch)
                                 .GroupBy(watch => watch.YearIssue);
            return res;
        }
        [ExcludeFromCodeCoverage]
        static void TwoPartMenu()
        {
            MyCollection<Watch> collection = new MyCollection<Watch>();
            int size = 0;
            int numberMenu;
            do //меню для 2 части
            {
                Console.WriteLine("1.Создать коллекцию");
                Console.WriteLine("2.Вывести коллекцию");
                Console.WriteLine("3.Запросы");
                Console.WriteLine("4.Выход");
                numberMenu = NumberCheck();
                switch (numberMenu)
                {
                    case 1: //создание коллекции
                        {
                            Console.Write("Введите количество элементов таблицы - ");
                            size = NumberCheck();
                            collection = new MyCollection<Watch>(size); //создаем таблицу
                            for (int i = 0; i < size; i++)
                            {
                                Watch c = new Watch();
                                c.RandomInit();
                                collection.AddItem(c);
                            }
                            Console.WriteLine("Коллекция создана");//сообщение для пользователя
                            break;
                        };
                    case 2://печать коллекции
                        {
                            collection.Print(); //выводим коллекцию
                            break;
                        };
                    case 3://запросы
                        {
                            Console.WriteLine("Выборка данных(год выпуска > 1900): ");
                            var res1 = from item in collection
                                       where item is Watch && ((Watch)item).YearIssue > 1900
                                       select (Watch)item;
                            Console.WriteLine("LINQ");
                            foreach (var item in res1)
                            {
                                Console.WriteLine(item);
                            }
                            Console.WriteLine("Метод расширения");
                            var res2 = collection.Where(watch => watch.YearIssue > 1900)
                                                 .ToList();
                            foreach (var item in res2)
                            {
                                Console.WriteLine(item);
                            }
                            Console.WriteLine();
                            Console.WriteLine("Количество элементов: ");
                            var res3 = (from item in collection where item.Brand == "Casio" select item).Count<Watch>();
                            Console.Write("LINQ ");
                            Console.WriteLine($"Часoв с брендом Casio - {res3}");
                            Console.Write("Метод расширения ");
                            var res4 = collection.Where(watch => watch.Brand == "Casio").Count();
                            Console.WriteLine($"Часoв с брендом Casio - {res4}");
                            Console.WriteLine();
                            Console.WriteLine("Средний год: ");
                            var res5 = (from item2 in collection
                                        where item2 is Watch
                                        select ((Watch)item2).YearIssue).Average();
                            Console.Write("LINQ ");
                            Console.WriteLine($"Средний год выпуска часов - {res5}");
                            Console.Write("Метод расширения ");
                            var res6 = collection.Where(item => item is Watch watch)
                                 .Select(watch => watch.YearIssue)
                                 .Average();
                            Console.WriteLine($"Средний год выпуска часов - {res6}");
                            Console.WriteLine();
                            Console.WriteLine("Группировка");
                            var res9 = from item2 in collection
                                       group item2 by item2.YearIssue;
                            Console.WriteLine("LINQ");
                            foreach (var item in res9)
                            {
                                Console.WriteLine(item.Key);
                                foreach (var gr in item)
                                {
                                    Console.WriteLine(gr);
                                }
                            }
                            Console.WriteLine("Метод расширения");
                            var res10 = collection.Where(item => item is Watch watch)
                                 .GroupBy(watch => watch.YearIssue);
                            foreach (var item in res10)
                            {
                                Console.WriteLine(item.Key);
                                foreach (var gr in item)
                                {
                                    Console.WriteLine(gr);
                                }
                            }
                            break;
                        }
                    case 4: { break; } //возвращение в главное меню
                    default: { Console.WriteLine("Неправильно задан пункт меню \nПопробуйте еще раз"); break; };
                }
            } while (numberMenu != 4);
        }
        static void Main(string[] args)
        {
            var dictionary = new Dictionary<string, List<Watch>>();
            int size = 0;
            int numberMenu;
            do //меню для 2 части
            {
                Console.WriteLine("1.Создать коллекцию");
                Console.WriteLine("2.Вывести коллекцию");
                Console.WriteLine("3.Запрос часов выпущенных после 1900 года(Where)");
                Console.WriteLine("4.Объединение двух словарей(Union)");
                Console.WriteLine("5.Часы с максимальным годом выпуска(Max)");
                Console.WriteLine("6.Часы с минимальным годом выпуска(Min)");
                Console.WriteLine("7.Группировка по году(Group by)");
                Console.WriteLine("8.Вторая часть");
                Console.WriteLine("9.Выход");
                numberMenu = NumberCheck();
                switch (numberMenu)
                {
                    case 1: //создание коллекции
                        {
                            Console.Write("Введите количество магазинов - ");
                            size = NumberCheck();
                            dictionary = MakeDictionary(size);
                            Console.WriteLine("Коллекция создана");//сообщение для пользователя
                            break;
                        };
                    case 2://печать коллекции
                        {
                            PrintDictionary(dictionary); //выводим коллекцию
                            break;
                        };
                    case 3://where
                        {
                            var res1 = WhereLINQ(dictionary);
                            Console.WriteLine("LINQ");
                            if (res1.Count == 0) Console.WriteLine("Таких элементов нет");
                            foreach (var item in res1)
                            {
                                Console.WriteLine(item);
                            }
                            Console.WriteLine("Метод расширения");
                            var res2 = WhereExtencion(dictionary);
                            foreach (var item in res2)
                            {
                                Console.WriteLine(item);
                            }
                            break;
                        };
                    case 4://объединение
                        {
                            var dictionary2 = new Dictionary<string, List<Watch>>();
                            dictionary2 = MakeDictionary(3);
                            var res3 = UnionExtencion(dictionary, dictionary2);
                            Console.WriteLine("Метод расширения");
                            foreach (var item in res3)
                            {
                                Console.WriteLine(item);
                            }
                            var res4 = UnionLINQ(dictionary, dictionary2);
                            Console.WriteLine("LINQ");
                            foreach (var item in res4)
                            {
                                Console.WriteLine(item);
                            }
                            break;
                        };
                    case 5://максимальный год часов
                        {
                            var res5 = MaxLINQ(dictionary);
                            Console.WriteLine($"LINQ - Максимальный год часов: {res5}");
                            var res6 = MaxExtencion(dictionary);
                            Console.WriteLine($"Метод расширения - Максимальный год часов: {res6}");
                            break;
                        }
                    case 6://минимальный год часов
                        {
                            var res7 = MinLINQ(dictionary);
                            Console.WriteLine($"LINQ - Минимальный год часов: {res7}");
                            var res8 = MinExtencion(dictionary);
                            Console.WriteLine($"Метод расширения - Минимальный год часов: {res8}");
                            break;
                        }
                    case 7://группировка
                        {
                            var res9 = GroupLINQ(dictionary);
                            Console.WriteLine("LINQ");
                            foreach (var item in res9)
                            {
                                Console.WriteLine(item.Key);
                                foreach(var gr in item)
                                {
                                    Console.WriteLine(gr);
                                }
                            }
                            Console.WriteLine("Метод расширения");
                            var res10 = GroupExtencion(dictionary);
                            foreach (var item in res10)
                            {
                                Console.WriteLine(item.Key);
                                foreach (var gr in item)
                                {
                                    Console.WriteLine(gr);
                                }
                            }
                            break;
                        }
                    case 8: 
                        {
                            TwoPartMenu();
                            break; 
                        } 
                    case 9: { break; } //возвращение в главное меню
                    default: { Console.WriteLine("Неправильно задан пункт меню \nПопробуйте еще раз"); break; };
                }
            } while (numberMenu != 9);
        }
    }
}
