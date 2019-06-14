using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization.Json;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace DataBaseTask2
{
    class Menu
    {
        public static DataBase db;

        public static void DefaultController()
        {
            Console.WriteLine("0. Выйти из программы");
            Console.WriteLine("1. LINQ запросы");
            Console.WriteLine("2. Добавить запись");
            Console.WriteLine("3. Десериализовать");
            bool f = true;
            while (f)
            {
                f = false;
                char key = Console.ReadKey().KeyChar;
                Console.WriteLine();
                if (key == '0' || key == 27) return;
                else if (key == '1') LINQController();
                else if (key == '2') DBController();
                else if (key == '3') JSONController();
                else f = true;
            }
            DefaultController();
        }

        public static void LINQController()
        {
            Console.WriteLine("0. Назад");
            Console.WriteLine("1. Все товары, купленные покупателем с самым длинным именем");
            Console.WriteLine("2. Категория самого дорогого товара");
            Console.WriteLine("3. Город, в котором общая сумма всех продаж наименьшая");
            Console.WriteLine("4. Фамилии покупателей, купивших самый дорогой товар");
            Console.WriteLine("5. Количество магазинов в стране, где их меньше всего");
            Console.WriteLine("6. Покупки покупателя, сделанные не в его городе");
            Console.WriteLine("7. Общая стоимость всех покупок");
            bool f = true;
            while (f)
            {
                f = false;
                char key = Console.ReadKey().KeyChar;
                Console.WriteLine();
                if (key == '0' || key == 27) return;
                else if (key == '1')
                {
                    Buyer buyer = db.Table<Buyer>().OrderByDescending(w => w.Name.Length).First();
                    List<long> ids = db.Table<Sale>().Where(w => w.BuyerId == buyer.Id).Select(w => w.GoodId).ToList();
                    List<Good> goods = db.Table<Good>().Where(w => ids.Contains(w.Id)).ToList();
                    Console.WriteLine("Имя: " + buyer.Name);
                    foreach (var i in goods)
                    {
                        Console.WriteLine(i);
                    }
                }
                else if (key == '2')
                {
                    Sale sale = db.Table<Sale>().OrderByDescending(w => ((double)w.Price) / w.Amount).First();
                    Good good = db.Table<Good>().Where(w => w.Id == sale.GoodId).First();
                    Console.WriteLine(good.Category);
                }
                else if (key == '3')
                {
                    Dictionary<long, long> salesSum = new Dictionary<long, long>();
                    HashSet<long> shopIds = db.Table<Sale>().Select(w => w.ShopId).ToHashSet();
                    foreach (var i in shopIds) salesSum.Add(i, 0);
                    foreach (var i in db.Table<Sale>())
                        salesSum[i.ShopId] += i.Price;
                    Shop minCity = db.Table<Shop>().Where(w => w.Id == salesSum.Min(x => x.Key)).First();
                    Console.WriteLine($"Город: {minCity.City}; Сумма продаж: {salesSum[salesSum.Min(x => x.Key)]}.");
                }
                else if (key == '4')
                {
                    Dictionary<long, long> salesCount = new Dictionary<long, long>();
                    HashSet<long> goodIds = db.Table<Sale>().Select(w => w.GoodId).ToHashSet();
                    foreach (var i in goodIds) salesCount.Add(i, 0);
                    foreach (var i in db.Table<Sale>())
                        ++salesCount[i.GoodId];
                    Good bestseller = db.Table<Good>().Where(w => w.Id == salesCount.Max(x => x.Key)).FirstOrDefault();
                    HashSet<long> buyerIds = db.Table<Sale>().Where(w => w.GoodId == bestseller.Id).Select(w => w.BuyerId).ToHashSet();
                    List<Buyer> buyers = db.Table<Buyer>().Where(w => buyerIds.Contains(w.Id)).ToList();
                    Console.WriteLine("Фамилии покупателей самого популярного товара: ");
                    foreach (var i in buyers)
                        Console.WriteLine(i.Surname);
                }
                else if (key == '5')
                {
                    Dictionary<string, long> shopCount = new Dictionary<string, long>();
                    foreach (var i in db.Table<Shop>())
                    {
                        if (!shopCount.ContainsKey(i.Country)) shopCount.Add(i.Country, 0);
                        ++shopCount[i.Country];
                    }
                    Console.WriteLine($"Количество магазинов в стране, где их меньше всего: {shopCount.Min(x => x.Value)}");
                }
                else if (key == '6')
                {

                }
                else if (key == '7')
                {
                    long sum = 0;
                    foreach (var i in db.Table<Sale>()) sum += i.Price;
                    Console.WriteLine(sum);
                }
                else f = true;
            }
            LINQController();
        }

        public static void DBController()
        {
            Console.WriteLine("0. Назад");
            Console.WriteLine("1. Добавить покупателя");
            Console.WriteLine("2. Добавить товар");
            Console.WriteLine("3. Добавить магазин");
            Console.WriteLine("4. Добавить запись о продаже товара");
            bool f = true;
            while (f)
            {
                f = false;
                char key = Console.ReadKey().KeyChar;
                Console.WriteLine();
                if (key == '0' || key == 27) return;
                if (key == '1')
                {
                    Console.WriteLine("Введите имя: ");
                    string name = Console.ReadLine();
                    Console.WriteLine("Введите фамилию: ");
                    string surname = Console.ReadLine();
                    Console.WriteLine("Введите адрес: ");
                    string address = Console.ReadLine();
                    Console.WriteLine("Введите город: ");
                    string city = Console.ReadLine();
                    Console.WriteLine("Введите район: ");
                    string distinct = Console.ReadLine();
                    Console.WriteLine("Введите страну: ");
                    string country = Console.ReadLine();
                    Console.WriteLine("Введите номер телефона: ");
                    string phoneNumber = Console.ReadLine();
                    db.InsertInto(new BuyerFactory(name, surname, address, city, distinct, country, phoneNumber));
                }
                if (key == '2')
                {
                    Console.WriteLine("Введите название товара: ");
                    string name = Console.ReadLine();
                    Console.WriteLine("Введите категорию товара: ");
                    string category = Console.ReadLine();
                    db.InsertInto(new GoodFactory(name, category));
                }
                if (key == '3')
                {
                    Console.WriteLine("Введите название магазина: ");
                    string name = Console.ReadLine();
                    Console.WriteLine("Введите город: ");
                    string city = Console.ReadLine();
                    Console.WriteLine("Введите район: ");
                    string distinct = Console.ReadLine();
                    Console.WriteLine("Введите страну: ");
                    string country = Console.ReadLine();
                    Console.WriteLine("Введите номер телефона: ");
                    string phoneNumber = Console.ReadLine();
                    db.InsertInto(new ShopFactory(name, city, distinct, country, phoneNumber));
                }
                if (key == '4')
                {
                    Console.WriteLine("Введите id покупателя: ");
                    long buyerId = Parser.ReadLong(1, db.Table<Buyer>().Count(), "Неверный формат ввода/ID покупателя больше допустимого!");
                    Console.WriteLine("Введите id покупателя: ");
                    long shopId = Parser.ReadLong(1, db.Table<Shop>().Count(), "Неверный формат ввода/ID магазина больше допустимого!");
                    Console.WriteLine("Введите id покупателя: ");
                    long goodId = Parser.ReadLong(1, db.Table<Good>().Count(), "Неверный формат ввода/ID товара больше допустимого!");
                    Console.WriteLine("Введите количество товара: ");
                    long amount = Parser.ReadLong(1, 10000, "Неверный формат ввода / кол-во товара меньше одного или больше 10000!");
                    Console.WriteLine("Введите цену покупки: ");
                    long price = Parser.ReadLong(1, 100000, "Неверный формат ввода / сумма покупки меньше рубля или больше средней зарплаты Москвы!");
                    db.InsertInto(new SaleFactory(buyerId, shopId, goodId, amount, price));
                }
            }
            DBController();
        }
        public static void JSONController()
        {
            Console.WriteLine("Всё выгружается в папку с бинарником!");
            Console.WriteLine("0. Назад");
            Console.WriteLine("1. Выгрузить таблицу покупателей");
            Console.WriteLine("2. Выгрузить таблицу товаров");
            Console.WriteLine("3. Выгрузить таблицу продаж");
            Console.WriteLine("4. Выгрузить таблицу магазинов");
            bool f = true;
            while (f)
            {
                f = false;
                char key = Console.ReadKey().KeyChar;
                Console.WriteLine();
                if (key == '0' || key == 27) return;
                if (key == '1')
                {
                    DataContractJsonSerializer jsonSerializer = new DataContractJsonSerializer(typeof(Buyer[]));
                    using (FileStream fs = new FileStream("buyers.json", FileMode.OpenOrCreate))
                    {
                        jsonSerializer.WriteObject(fs, db.Table<Buyer>().ToArray());
                    }
                }
                if (key == '2')
                {
                    DataContractJsonSerializer jsonSerializer = new DataContractJsonSerializer(typeof(Good[]));
                    using (FileStream fs = new FileStream("goods.json", FileMode.OpenOrCreate))
                    {
                        jsonSerializer.WriteObject(fs, db.Table<Good>().ToArray());
                    }
                }
                if (key == '3')
                {
                    DataContractJsonSerializer jsonSerializer = new DataContractJsonSerializer(typeof(Sale[]));
                    using (FileStream fs = new FileStream("sales.json", FileMode.OpenOrCreate))
                    {
                        jsonSerializer.WriteObject(fs, db.Table<Sale>().ToArray());
                    }
                }
                if (key == '4')
                {
                    DataContractJsonSerializer jsonSerializer = new DataContractJsonSerializer(typeof(Shop[]));
                    using (FileStream fs = new FileStream("shops.json", FileMode.OpenOrCreate))
                    {
                        jsonSerializer.WriteObject(fs, db.Table<Shop>().ToArray());
                    }
                }
            }
            JSONController();
        }
    }
}
