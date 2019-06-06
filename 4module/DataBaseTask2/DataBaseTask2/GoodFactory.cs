using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBaseTask2
{
    class GoodFactory : IEntityFactory<Good>
    {
        private static long _id = 1;

        private string _name;
        private string _category;
        
        public GoodFactory(string name, string category)
        {
            _name = name;
            _category = category;
        }

        public Good Instance => new Good(_id++, _name, _category);
    }
}
