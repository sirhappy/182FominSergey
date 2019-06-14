using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace DataBaseTask2
{
    [DataContract]
    class Buyer : IEntity
    {
        [DataMember]
        public long Id { get; private set; }
        [DataMember]
        public string Name { get; private set; }
        [DataMember]
        public string Surname { get; private set; }
        [DataMember]
        public string Address { get; private set; }
        [DataMember]
        public string City { get; private set; }
        [DataMember]
        public string Distinct { get; private set; }
        [DataMember]
        public string Country { get; private set; }
        [DataMember]
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
