using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                if (key == '0') return;
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
                if (key == '0') return;
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

                }
                else f = true;
            }
            LINQController();
        }

        public static void DBController()
        {

        }

        public static void JSONController()
        {

        }
    }
}
