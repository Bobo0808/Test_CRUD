using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata.Ecma335;
using TEST.Models.Domain;

namespace TEST.Data
{
    public class MVCDemoDbContext : DbContext
    {
        public MVCDemoDbContext(DbContextOptions options) : base(options)
        {
       
        }
        //可以讓你使用Emplyees來做CRUD
        public DbSet<Employee> Employees { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
