using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace University
{
    abstract public class Work
    {
        public Work(string name, int[] marks, string group)
        {
            _group = group;
            this.name = name;
            Marks = marks;
        }

        private string _group;
        readonly string name;
        string GetGroupName
        {
            get => _group;
        }

        private int[] _marks;
        int[] Marks
        {
            set
            {
                _marks = new int[value.Length];
                for (int i = 0; i < value.Length; ++i)
                {
                    if (value[i] < 0 || value[i] > 10) throw new ArgumentOutOfRangeException($"value[{i}]", "Оценка должна быть в диапазоне [0; 10]");
                    _marks[i] = value[i];
                }
            }
        }

        public int this[int i]
        {
            get
            {
                return _marks[i];
            }
        }

        public virtual string GetStudentInfo()
        {
            return $"I am {name} from {GetGroupName} group. My marks: {this[0]} {this[1]} {this[2]} {this[3]} {this[4]}";
        }
    }
}
