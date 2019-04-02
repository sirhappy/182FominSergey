using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CourseWork2019.Models
{
    public class TestContext : DbContext
    {
        public DbSet<Question> Questions { get; set; }
        public DbSet<Test> Tests { get; set; }

        public TestContext(DbContextOptions<TestContext> options)
            : base(options) {
            Database.EnsureCreated();
        }
    }
}
