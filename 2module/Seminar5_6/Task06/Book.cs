using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task06
{
    class Book
    {
        private int _countPages;
        private int _sectionNumber;

        public Book(int countPages, int sectionNumber)
        {
            _countPages = countPages;
            _sectionNumber = sectionNumber;
        }

        public int CountPages
        {
            get { return _countPages; }
        }
    }
}
