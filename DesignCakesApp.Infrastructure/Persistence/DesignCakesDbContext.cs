using DesignCakesApp.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace DesignCakesApp.Infrastructure.Persistence
{
    public class DesignCakesDbContext : DbContext
    {
        public DesignCakesDbContext(DbContextOptions<DesignCakesDbContext> options) : base(options)
        {
            SeedData();
        }
        public DbSet<Customers> Customers { get; set; }
        public DbSet<Complaints> Complaints { get; set; }
        public DbSet<Labels> Labels { get; set; }
        public DbSet<LovedOnes> LovedOnes { get; set; }
        public DbSet<Orders> Orders { get; set; }
        public DbSet<OrderStatuses> OrderStatuses { get; set; }
        public DbSet<Payments> Payments { get; set; }
        public DbSet<PaymentTypes> PaymentTypes { get; set; }
        public DbSet<ProductPrices> ProductPrices { get; set; }
        public DbSet<Products> Products { get; set; }
        public DbSet<ProductSizes> ProductSizes { get; set; }
        public DbSet<Roles> Roles { get; set; }
        public DbSet<Users> Users { get; set; }
        public DbSet<Suppliers> Suppliers { get; set; }

        public void SeedData()
        {
            // Check if there are any records in the Labels table, and only seed if empty
            if (!Labels.Any())
            {
                Labels.AddRange(
                    new Labels { Name = "New Customer" },
                    new Labels { Name = "Bad" },
                    new Labels { Name = "Prepayment Basis" },
                    new Labels { Name = "Baby Shower" }
                );


                if (!Roles.Any())
                {
                    Roles.AddRange(
                        new Roles { name = "Admin" },
                        new Roles { name = "User" }
                    );
                }

                if (!OrderStatuses.Any())
                {
                    OrderStatuses.AddRange(
                        new OrderStatuses { status= "Pending" },
                        new OrderStatuses { status = "Partially Paid" },
                        new OrderStatuses { status = "Billed" },
                        new OrderStatuses { status = "Cancelled" }
                        );
                }

                if (!ProductSizes.Any())
                {
                    ProductSizes.AddRange(
                        new ProductSizes { size="small"},
                        new ProductSizes { size = "medium" },
                        new ProductSizes { size = "large" },
                        new ProductSizes { size = "cupcakes" },
                        new ProductSizes { size = "slice" }
                        );
                }
                if (!PaymentTypes.Any())
                {
                    PaymentTypes.AddRange(
                        new PaymentTypes { name="Cash"},
                        new PaymentTypes { name="Ecocash"},
                         new PaymentTypes { name = "InnBucks " }
                        );
                }
                if (!Users.Any())
                {
                    Users.AddRange(
                        new Users { firstName="Tinashe", lastName="Chivaura" , userName="TinTin" , Role="Admin" , password="224490Hi"}
                        
                        );
                }

                SaveChanges(); // Persist the changes to the database
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            
             



        }
    }
}
