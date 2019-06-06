using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBaseTask2
{
    class BuyerFactory : IEntityFactory<Buyer>
    {
        private static long _id = 1;

        private string _name;
        private string _surname;
        private string _address;
        private string _city;
        private string _distinct;
        private string _country;
        private string _phoneNumber;

        public BuyerFactory(string name, string surname, string address, string city, string distinct, string country, string phoneNumber)
        {
            _name = name;
            _surname = surname;
            _address = address;
            _city = city;
            _distinct = distinct;
            _country = country;
            _phoneNumber = phoneNumber;
        }

        public Buyer Instance => new Buyer(_id++, _name, _surname, _address, _city, _distinct, _country, _phoneNumber);
    }
}
