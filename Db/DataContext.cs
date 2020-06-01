using Microsoft.EntityFrameworkCore;

namespace Market.Models
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions op): base(op){  

        }
        public DbSet<Category> Categories{get;set;}
        public DbSet<Product> Products{get;set;}
        protected override void OnModelCreating(ModelBuilder builder){
            builder.Entity<Category>().HasData(
                new Category{ Id = 1, Name = "All"},
                new Category{ Id = 2, Name = "Bakery Products"},
                new Category{ Id = 3, Name = "Confectionery"},
                new Category{ Id = 4, Name = "Meat Products"},
                new Category{ Id = 5, Name = "Seafood"},
                new Category{ Id = 6, Name = "Fruits and vegetables"},
                new Category{ Id = 7, Name = "Dairy Produce"}              
            );
        }
    }
}