using System;
using System.Linq;

namespace DataBaseTask2
{
    class Program
    {
        static void Main(string[] args)
        {
            DataBase db = new DataBase("ShopDataBase");
            Menu.db = db;

            db.CreateTable<Good>();
            db.CreateTable<Shop>();
            db.CreateTable<Buyer>();
            db.CreateTable<Sale>();

            db.InsertInto(new ShopFactory("Auchan", "Mocsow", "Airport", "Russia", "+78006003020"));
            db.InsertInto(new ShopFactory("Magnit", "Moscow", "Belorusskaya", "Russia", "+78001234560"));
            
            db.InsertInto(new GoodFactory("Pepsi", "Drinks"));
            db.InsertInto(new GoodFactory("3 korochki", "Snacks"));
            db.InsertInto(new GoodFactory("Ohota", "Drinks"));
            db.InsertInto(new GoodFactory("Lays", "Snacks"));

            db.InsertInto(new BuyerFactory("Sergey", "Fomin", "Dormitory", "Odintsovo", "Odintsovo", "Russia", "+79881234567"));
            db.InsertInto(new BuyerFactory("Illarion", "Illarionov", "Gallery", "Moscow", "Airport", "Russia", "+79621324567"));


            db.InsertInto(new SaleFactory(1, 1, 1, 1, 60));
            db.InsertInto(new SaleFactory(1, 1, 4, 2, 80));
            db.InsertInto(new SaleFactory(2, 2, 3, 2, 100));
            db.InsertInto(new SaleFactory(2, 2, 2, 2, 60));

            Menu.DefaultController();

            Console.ReadKey();
        }
    }
}