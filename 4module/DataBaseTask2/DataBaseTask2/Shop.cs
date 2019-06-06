using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBaseTask2
{
    class Shop : IEntity
    {
        public long Id { get; private set; }

        public string Name { get; private set; }
        public string City { get; private set; }
        public string District { get; private set; }
        public string Country { get; private set; }
        public string PhoneNumber { get; private set; }

        public Shop(long id, string name, string city, string district, string country, string phoneNumber)
        {
            Id = id;
            Name = name;
            City = city;
            District = district;
            Country = country;
            PhoneNumber = phoneNumber;
        }
    }
}
