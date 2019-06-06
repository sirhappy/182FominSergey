using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBaseTask2
{
    class Buyer : IEntity
    {
        public long Id { get; private set; }
        public string Name { get; private set; }
        public string Surname { get; private set; }
        public string Address { get; private set; }
        public string City { get; private set; }
        public string Distinct { get; private set; }
        public string Country { get; private set; }
        public string PhoneNumber { get; private set; }

        public Buyer(long id, string name, string surname, string address, string city, string distinct, string country, string phoneNumber)
        {
            Id = id;
            Name = name;
            Surname = surname;
            Address = address;
            City = city;
            Distinct = distinct;
            Country = country;
            PhoneNumber = phoneNumber;
        }
    }
}
