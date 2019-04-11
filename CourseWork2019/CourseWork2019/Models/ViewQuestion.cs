using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CourseWork2019.Models
{
    public class ViewQuestion
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string QuestionContent { get; set; }
        public List<string> Answers { get; set; } = new List<string>();
    }
}
