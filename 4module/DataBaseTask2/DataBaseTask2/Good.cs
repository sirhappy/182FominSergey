using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace DataBaseTask2
{
    [DataContract]
    class Good : IEntity
    {
        [DataMember]
        public long Id { get; private set; }

        [DataMember]
        public string Name { get; private set; }
        [DataMember]
        public string Category { get; private set; }

        public Good(long id, string name, string category)
        {
            Id = id;
            Name = name;
            Category = category;
        }

        public override string ToString()
        {
            return $"Товар: {Name}; Категория: {Category}";
        }
    }
}
