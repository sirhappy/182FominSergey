using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Seminar08
{
    class Storage<T>
    {
        private List<T> _storage;

        public Storage(ICollection<T> storage)
        {
            _storage = new List<T>();
            foreach (T item in storage)
                _storage.Add(item);
        }
        

        public Storage() : this(new List<T>()) { }


        public void Add(T item)
        {
            _storage.Add(item);
        }

        public void Add(ICollection<T> storage)
        {
            foreach (T item in storage)
                _storage.Add(item);
        }

        public void Delete(int index)
        {
            if (index >= _storage.Capacity) throw new IndexOutOfRangeException();
            _storage.RemoveAt(index);
        }

        public void Delete(T item)
        {
            _storage.Remove(item);
        }

        public T GetIndex(int index) => _storage[index];
        
        public int Length { get => _storage.Capacity; } 
    }
    class Program
    {
        static void Main(string[] args)
        {
            Storage<int> storage = new Storage<int>();
            storage.Add(1);
            storage.Add(2);
            storage.Add(3);
            storage.Delete(4);
            Console.ReadKey();
        }
    }
}
