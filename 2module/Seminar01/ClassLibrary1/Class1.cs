using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    interface IVocal
    {
        void DoSound();
    }

    abstract class Animal : IVocal
    {
        protected int Id;
        protected string Name;
        protected bool IsTakenCare;

        public void DoSound()
        {
            throw new NotImplementedException();
        }

        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }

    public class Class1
    {
    }
}
