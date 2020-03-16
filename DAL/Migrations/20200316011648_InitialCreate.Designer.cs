﻿// <auto-generated />
using DAL.DataContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DAL.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    [Migration("20200316011648_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("DAL.Entities.Customer", b =>
                {
                    b.Property<int>("CustomerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CustomerType")
                        .HasColumnType("int");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.HasKey("CustomerId");

                    b.ToTable("Customers");

                    b.HasData(
                        new
                        {
                            CustomerId = 1,
                            CustomerType = 1,
                            FirstName = "Josef",
                            LastName = "Gabrielsson"
                        },
                        new
                        {
                            CustomerId = 2,
                            CustomerType = 0,
                            FirstName = "Kalle",
                            LastName = "Anka"
                        },
                        new
                        {
                            CustomerId = 3,
                            CustomerType = 0,
                            FirstName = "Bill",
                            LastName = "Gates"
                        });
                });

            modelBuilder.Entity("DAL.Entities.CustomerRentalItem", b =>
                {
                    b.Property<int>("CustomerRentalId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CustomerId")
                        .HasColumnType("int");

                    b.Property<short>("Discount")
                        .HasColumnType("smallint");

                    b.Property<int>("RentalItemId")
                        .HasColumnType("int");

                    b.HasKey("CustomerRentalId");

                    b.HasIndex("CustomerId");

                    b.HasIndex("RentalItemId")
                        .IsUnique();

                    b.ToTable("CustomersRentalItems");

                    b.HasData(
                        new
                        {
                            CustomerRentalId = 1,
                            CustomerId = 1,
                            Discount = (short)15,
                            RentalItemId = 7
                        },
                        new
                        {
                            CustomerRentalId = 2,
                            CustomerId = 1,
                            Discount = (short)15,
                            RentalItemId = 8
                        },
                        new
                        {
                            CustomerRentalId = 3,
                            CustomerId = 1,
                            Discount = (short)10,
                            RentalItemId = 3
                        },
                        new
                        {
                            CustomerRentalId = 4,
                            CustomerId = 1,
                            Discount = (short)10,
                            RentalItemId = 4
                        },
                        new
                        {
                            CustomerRentalId = 5,
                            CustomerId = 1,
                            Discount = (short)10,
                            RentalItemId = 2
                        },
                        new
                        {
                            CustomerRentalId = 6,
                            CustomerId = 2,
                            Discount = (short)0,
                            RentalItemId = 6
                        },
                        new
                        {
                            CustomerRentalId = 7,
                            CustomerId = 2,
                            Discount = (short)0,
                            RentalItemId = 1
                        },
                        new
                        {
                            CustomerRentalId = 8,
                            CustomerId = 2,
                            Discount = (short)0,
                            RentalItemId = 5
                        });
                });

            modelBuilder.Entity("DAL.Entities.RentalItem", b =>
                {
                    b.Property<int>("RentalItemId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ImageUrl")
                        .HasColumnType("nvarchar(255)")
                        .HasMaxLength(255);

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("RentalItemType")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(128)")
                        .HasMaxLength(128);

                    b.HasKey("RentalItemId");

                    b.HasIndex("RentalItemId");

                    b.ToTable("RentalItems");

                    b.HasData(
                        new
                        {
                            RentalItemId = 1,
                            ImageUrl = "https://m.media-amazon.com/images/M/MV5BNzQzMzJhZTEtOWM4NS00MTdhLTg0YjgtMjM4MDRkZjUwZDBlXkEyXkFqcGdeQXVyNjU0OTQ0OTY@._V1_UX182_CR0,0,182,268_AL_.jpg",
                            Price = 30m,
                            RentalItemType = 0,
                            Title = "Blade Runner"
                        },
                        new
                        {
                            RentalItemId = 2,
                            ImageUrl = "https://m.media-amazon.com/images/M/MV5BMmQ2MmU3NzktZjAxOC00ZDZhLTk4YzEtMDMyMzcxY2IwMDAyXkEyXkFqcGdeQXVyNzkwMjQ5NzM@._V1_UX182_CR0,0,182,268_AL_.jpg",
                            Price = 30m,
                            RentalItemType = 0,
                            Title = "Alien"
                        },
                        new
                        {
                            RentalItemId = 3,
                            ImageUrl = "https://m.media-amazon.com/images/M/MV5BYTViNzMxZjEtZGEwNy00MDNiLWIzNGQtZDY2MjQ1OWViZjFmXkEyXkFqcGdeQXVyNzkwMjQ5NzM@._V1_UX182_CR0,0,182,268_AL_.jpg",
                            Price = 30m,
                            RentalItemType = 0,
                            Title = "The Terminator"
                        },
                        new
                        {
                            RentalItemId = 4,
                            ImageUrl = "https://m.media-amazon.com/images/M/MV5BMTg5NTA3NTg4NF5BMl5BanBnXkFtZTcwNTA0NDYzOA@@._V1_UX182_CR0,0,182,268_AL_.jpg",
                            Price = 30m,
                            RentalItemType = 0,
                            Title = "Looper"
                        },
                        new
                        {
                            RentalItemId = 5,
                            ImageUrl = "https://m.media-amazon.com/images/M/MV5BMDdmZGU3NDQtY2E5My00ZTliLWIzOTUtMTY4ZGI1YjdiNjk3XkEyXkFqcGdeQXVyNTA4NzY1MzY@._V1_UX182_CR0,0,182,268_AL_.jpg",
                            Price = 30m,
                            RentalItemType = 0,
                            Title = "Titanic"
                        },
                        new
                        {
                            RentalItemId = 6,
                            ImageUrl = "https://m.media-amazon.com/images/M/MV5BMDljNTQ5ODItZmQwMy00M2ExLTljOTQtZTVjNGE2NTg0NGIxXkEyXkFqcGdeQXVyODkzNTgxMDg@._V1_UX182_CR0,0,182,268_AL_.jpg",
                            Price = 90m,
                            RentalItemType = 1,
                            Title = "Star Wars: The Rise of Skywalker"
                        },
                        new
                        {
                            RentalItemId = 7,
                            ImageUrl = "https://m.media-amazon.com/images/M/MV5BMTc5MDE2ODcwNV5BMl5BanBnXkFtZTgwMzI2NzQ2NzM@._V1_UX182_CR0,0,182,268_AL_.jpg",
                            Price = 50m,
                            RentalItemType = 1,
                            Title = "Avatar"
                        },
                        new
                        {
                            RentalItemId = 8,
                            ImageUrl = "https://m.media-amazon.com/images/M/MV5BMTYwOTEwNjAzMl5BMl5BanBnXkFtZTcwODc5MTUwMw@@._V1_UX182_CR0,0,182,268_AL_.jpg",
                            Price = 80m,
                            RentalItemType = 1,
                            Title = "Avengers: End Game"
                        });
                });

            modelBuilder.Entity("DAL.Entities.CustomerRentalItem", b =>
                {
                    b.HasOne("DAL.Entities.Customer", "Customer")
                        .WithMany("CustomerRentalItem")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DAL.Entities.RentalItem", "RentalItem")
                        .WithOne("CustomerRentalItem")
                        .HasForeignKey("DAL.Entities.CustomerRentalItem", "RentalItemId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}