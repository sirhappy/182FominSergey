using System;

namespace ClassLibrary
{
    interface ILocalMinimum<T> where T : IComparable<T>
    {
        T this[int index] { get; }

        int CountLocalMinimum();

        bool IsAllEqual { get; }

    }
}
