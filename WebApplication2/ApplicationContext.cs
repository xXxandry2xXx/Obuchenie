using Microsoft.EntityFrameworkCore;

namespace WebApplication2
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Models.User> Users { get; set; } = null!;
        public ApplicationContext(DbContextOptions<ApplicationContext> options)
            : base(options)
        {
            Database.EnsureCreated();   // создаем базу данных при первом обращении
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Models.User>().HasData(
                    new Models.User(),
                    new Models.User (),
                    new Models.User ()
            );
        }
    }
}
