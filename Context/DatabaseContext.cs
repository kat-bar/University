using Microsoft.EntityFrameworkCore;
using University.Models;

namespace University.Context
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {

        }
        public DbSet<Student> Students { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<Curs> Curs { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
    }
}
