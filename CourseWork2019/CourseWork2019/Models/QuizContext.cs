using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CourseWork2019.Models
{
    public class QuizContext : DbContext
    {
        public DbSet<Question> Questions { get; set; }
        public DbSet<Test> Tests { get; set; }
        public DbSet<TestQuestion> TestQuestions { get; set; }
        public DbSet<User> Users { get; set; }

        public QuizContext(DbContextOptions<QuizContext> options)
            : base(options) {
            Database.EnsureCreated();
        }
    }
}
