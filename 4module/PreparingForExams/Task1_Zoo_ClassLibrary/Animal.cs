using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1_Zoo_ClassLibrary
{
    abstract public class Animal : IVocal
    {
        private static int _id = 1;
        public int Id { get; } = _id++;
        public string Name { get; set; }
        public bool IsTakenCare { get; set; }

        public event Action OnSound;

        public Animal(string name, bool isTakenCare)
        {
            Name = name;
            IsTakenCare = isTakenCare; 
        }

        public void DoSound()
        {
            OnSound?.Invoke();
        }

        public override string ToString()
        {
            return $"Type: {this.GetType().Name}; Id: {Id}; Name: {Name}; Is taken care: {IsTakenCare}";
        }
    }

    public class Mammal : Animal
    {
        public int Paws { get; set; }

        public Mammal(string name, bool isTakenCare, int paws) : base(name, isTakenCare)
        {
            Paws = paws;
        }

        public override string ToString()
        {
            return $"{base.ToString()}; Paws: {Paws}";
        }
    }

    public class Bird : Animal
    {
        public Bird(string name, bool isTakenCare, int speed) : base(name, isTakenCare)
        {
            Speed = speed;
        }

        public int Speed { get; set; }

        public override string ToString()
        {
            return $"{base.ToString()}; Speed: {Speed}";
        }
    }
}
