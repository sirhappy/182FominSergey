using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBaseTask2
{
    class Good : IEntity
    {
        public long Id { get; private set; }

        public string Name { get; private set; }
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
