

namespace VerifyEmailForgotPassword.Data
{
    //:DbContext 繼承
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {


        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Server=.;Database=userdb;Trusted_Connection=true;");
        }
        public DbSet<User> Users =>Set<User>();

    }
}
