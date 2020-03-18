using DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace DAL.DataContext
{
    public class DatabaseContext : DbContext
    {
        public class OptionsBuild
        {
            public OptionsBuild()
            {
                Settings = new AppConfiguration();
                OpsBuilder = new DbContextOptionsBuilder<DatabaseContext>();
                if (Settings.DbProvider == "InMemory")
                {
                    OpsBuilder.UseInMemoryDatabase(Settings.DbConnectionString);
                }
                else
                {
                    OpsBuilder.UseSqlServer(Settings.DbConnectionString);
                }
                DbOptions = OpsBuilder.Options;
            }

            public DbContextOptionsBuilder<DatabaseContext> OpsBuilder { get; set; }
            public DbContextOptions<DatabaseContext> DbOptions { get; set; }
            private AppConfiguration Settings { get; set; }
        }

        public static OptionsBuild ops = new OptionsBuild();

        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options) {
            Database.EnsureCreated();
        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<CustomerRentalItem> CustomersRentalItems { get; set; }
        public DbSet<RentalItem> RentalItems { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Change table names
            /*modelBuilder.Entity<Customer>().ToTable("Customer");
			modelBuilder.Entity<CustomerRentalItem>().ToTable("Customer_Rental_Item");
			modelBuilder.Entity<RentalItem>().ToTable("Rental_Item");*/

            modelBuilder.Entity<RentalItem>().HasIndex(p => p.RentalItemId).IsUnique(false);

            // Seed tables with data
            modelBuilder.Entity<Customer>().HasData(
                new Customer { CustomerId = 1, FirstName = "Josef", LastName = "Gabrielsson", CustomerType = CustomerTypeEnum.Member },
                new Customer { CustomerId = 2, FirstName = "Kalle", LastName = "Anka", CustomerType = CustomerTypeEnum.Regular },
                new Customer { CustomerId = 3, FirstName = "Bill", LastName = "Gates", CustomerType = CustomerTypeEnum.Regular });

            modelBuilder.Entity<RentalItem>().HasData(
                new RentalItem { RentalItemId = 1, Title = "Blade Runner", Price = 30, RentalItemType = RentalItemTypeEnum.DVD, ImageUrl = "https://m.media-amazon.com/images/M/MV5BNzQzMzJhZTEtOWM4NS00MTdhLTg0YjgtMjM4MDRkZjUwZDBlXkEyXkFqcGdeQXVyNjU0OTQ0OTY@._V1_UX182_CR0,0,182,268_AL_.jpg" },
                new RentalItem { RentalItemId = 2, Title = "Alien", Price = 30, RentalItemType = RentalItemTypeEnum.DVD, ImageUrl = "https://m.media-amazon.com/images/M/MV5BMmQ2MmU3NzktZjAxOC00ZDZhLTk4YzEtMDMyMzcxY2IwMDAyXkEyXkFqcGdeQXVyNzkwMjQ5NzM@._V1_UX182_CR0,0,182,268_AL_.jpg" },
                new RentalItem { RentalItemId = 3, Title = "The Terminator", Price = 30, RentalItemType = RentalItemTypeEnum.DVD, ImageUrl = "https://m.media-amazon.com/images/M/MV5BYTViNzMxZjEtZGEwNy00MDNiLWIzNGQtZDY2MjQ1OWViZjFmXkEyXkFqcGdeQXVyNzkwMjQ5NzM@._V1_UX182_CR0,0,182,268_AL_.jpg" },
                new RentalItem { RentalItemId = 4, Title = "Looper", Price = 30, RentalItemType = RentalItemTypeEnum.DVD, ImageUrl = "https://m.media-amazon.com/images/M/MV5BMTg5NTA3NTg4NF5BMl5BanBnXkFtZTcwNTA0NDYzOA@@._V1_UX182_CR0,0,182,268_AL_.jpg" },
                new RentalItem { RentalItemId = 5, Title = "Titanic", Price = 30, RentalItemType = RentalItemTypeEnum.DVD, ImageUrl = "https://m.media-amazon.com/images/M/MV5BMDdmZGU3NDQtY2E5My00ZTliLWIzOTUtMTY4ZGI1YjdiNjk3XkEyXkFqcGdeQXVyNTA4NzY1MzY@._V1_UX182_CR0,0,182,268_AL_.jpg" },
                new RentalItem { RentalItemId = 6, Title = "Star Wars: The Rise of Skywalker", Price = 90, RentalItemType = RentalItemTypeEnum.BLURAY, ImageUrl = "https://m.media-amazon.com/images/M/MV5BMDljNTQ5ODItZmQwMy00M2ExLTljOTQtZTVjNGE2NTg0NGIxXkEyXkFqcGdeQXVyODkzNTgxMDg@._V1_UX182_CR0,0,182,268_AL_.jpg" },
                new RentalItem { RentalItemId = 7, Title = "Avatar", Price = 50, RentalItemType = RentalItemTypeEnum.BLURAY, ImageUrl = "https://m.media-amazon.com/images/M/MV5BMTc5MDE2ODcwNV5BMl5BanBnXkFtZTgwMzI2NzQ2NzM@._V1_UX182_CR0,0,182,268_AL_.jpg" },
                new RentalItem { RentalItemId = 8, Title = "Avengers: End Game", Price = 80, RentalItemType = RentalItemTypeEnum.BLURAY, ImageUrl = "https://m.media-amazon.com/images/M/MV5BMTYwOTEwNjAzMl5BMl5BanBnXkFtZTcwODc5MTUwMw@@._V1_UX182_CR0,0,182,268_AL_.jpg" });

            modelBuilder.Entity<CustomerRentalItem>().HasData(
                new CustomerRentalItem { CustomerRentalId = 1, RentalItemId = 7, Discount = 15, CustomerId = 1 }, // Avatar (Blu-Ray)
                new CustomerRentalItem { CustomerRentalId = 2, RentalItemId = 8, Discount = 15, CustomerId = 1 }, // Avengers: End Game (Blu-Ray)
                new CustomerRentalItem { CustomerRentalId = 3, RentalItemId = 3, Discount = 10, CustomerId = 1 }, // The Terminator (DVD)
                new CustomerRentalItem { CustomerRentalId = 4, RentalItemId = 4, Discount = 10, CustomerId = 1 }, // Looper (DVD)
                new CustomerRentalItem { CustomerRentalId = 5, RentalItemId = 2, Discount = 10, CustomerId = 1 }, // Alien (DVD)

                new CustomerRentalItem { CustomerRentalId = 6, RentalItemId = 6, Discount = 0, CustomerId = 2 }, // Star Wars: The Rise of Skywalker (Blue-Ray)
                new CustomerRentalItem { CustomerRentalId = 7, RentalItemId = 1, Discount = 0, CustomerId = 2 }, // Blade Runner
                new CustomerRentalItem { CustomerRentalId = 8, RentalItemId = 5, Discount = 0, CustomerId = 2 }); // Titanic
        }
    }
}
