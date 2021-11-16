using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace bigHm
{
    public class DBContext:DbContext
    {

        public DbSet<PrivateInfo> privateInfo { get; set; }
        public DbSet<Product> products { get; set; }

        public DBContext(DbContextOptions options) : base(options)
        {
        
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().ToTable("product", "Production");
            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
         
            optionsBuilder.UseSqlServer(@"Server=localhost\sqlexpress;Database=AdventureWorks2017;Trusted_Connection=True;");
        }



    }
    
    public class Product
    {
        [Key]
        public int ProductId { get; set; }
        public string Name { get; set; }
        public string ProductNumber { get; set; }
        public string Color { get; set; } 
        public string Size { get; set; }
        public decimal ListPrice { get; set; } 
    }
    public class PrivateInfo
    {
        [Key]

        public string LoginPerson { get; set; } 
        public string PasswordPerson { get; set; }
    }

}
