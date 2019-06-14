using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization.Json;
using System.Runtime.Serialization;

namespace DataBaseTask2
{
    [DataContract]
    class Shop : IEntity
    {
        [DataMember]
        public long Id { get; private set; }

        [DataMember]
        public string Name { get; private set; }
        [DataMember]
        public string City { get; private set; }
        [DataMember]
        public string Distinct { get; private set; }
        [DataMember]
        public string Country { get; private set; }
        [DataMember]
        public string PhoneNumber { get; private set; }

        public Shop(long id, string name, string city, string distinct, string country, string phoneNumber)
        {
            Id = id;
            Name = name;
            City = city;
            Distinct = distinct;
            Country = country;
            PhoneNumber = phoneNumber;
        }
    }
}
