using Microsoft.EntityFrameworkCore;
using Online_IT_Preparation.Models;

namespace Online_IT_Preparation.Data
{
    public class OnlineITDbContext: Microsoft.EntityFrameworkCore.DbContext
    {
        public OnlineITDbContext(DbContextOptions<OnlineITDbContext> options)
        : base(options)
        {
        }

        
        public DbSet<AccountModel> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AccountModel>().ToTable("Users");

            modelBuilder.Entity<AccountModel>()
                .HasKey(u => u.Id);

            modelBuilder.Entity<AccountModel>()
                .Property(u => u.Id)
                .ValueGeneratedOnAdd();  
            base.OnModelCreating(modelBuilder);  
        }

    }
}
