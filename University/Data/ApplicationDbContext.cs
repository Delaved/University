using Microsoft.EntityFrameworkCore;
using University.Model;

namespace University.Data
{
    public class ApplicationDbContext : DbContext
    {
        //public DbSet<PizzaOrder> PizzaOrders { get; set; }
        public DbSet<Student> Student { get; set; }
        public DbSet<Course> Course { get; set; }
        public DbSet<Record> Record { get; set; }
        public DbSet<Specialization> Specialization { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
    }
}
