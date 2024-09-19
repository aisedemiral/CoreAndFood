using Microsoft.EntityFrameworkCore;


namespace CoreAndFood.Models
{
    public class Context : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=localhost,1401; Database=DbCoreFood; User Id=sa; Password=YourSTRONG!Passw0rd;TrustServerCertificate=true");
        }
        public DbSet<Food> Foods { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Admin> Admins { get; set; }
    }
}
