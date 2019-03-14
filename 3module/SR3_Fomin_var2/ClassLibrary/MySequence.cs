using System;
using System.Collections.Generic;

namespace ClassLibrary
{
    public class MySequence<T> : ILocalMinimum<T>
        where T: IComparable<T>
    {
        private List<T> _seq;

        public MySequence(List<T> seq)
        {
            if (seq == null) throw new ArgumentNullException("Передана пустая последовательность");
            _seq = seq;
        }

        public T this[int index]
        {
            get
            {
                if (index >= _seq.Count) throw new IndexOutOfRangeException("Неправильно указан индекс"); 
                return _seq[index];
            }
        }

        public bool IsAllEqual
        {
            get
            {
                for (int i = 1; i < _seq.Count; ++i)
                    if (this[0].CompareTo(this[i]) != 0) return false;
                return true;
            }
        }

        public int CountLocalMinimum()
        {
            int count = 0;
            for (int i = 1; i < _seq.Count - 1; ++i)
            {
                if (this[i].CompareTo(this[i - 1]) < 0 && this[i].CompareTo(this[i + 1]) < 0)
                {
                    ++count;
                }
            }
            return count;
        }
    }
}
