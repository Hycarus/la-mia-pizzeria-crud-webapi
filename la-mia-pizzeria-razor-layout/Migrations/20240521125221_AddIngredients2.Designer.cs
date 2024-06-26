﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using la_mia_pizzeria_static.Models;
using la_mia_pizzeria_static.Data;

#nullable disable

namespace la_mia_pizzeria_static.Migrations
{
    [DbContext(typeof(PizzaContext))]
    [Migration("20240521125221_AddIngredients2")]
    partial class AddIngredients2
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.30")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("la_mia_pizzeria_static.Models.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("categories");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Pizze Bianche"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Pizze Vegetariane"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Pizze di Mare"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Pizze Speciali"
                        },
                        new
                        {
                            Id = 5,
                            Name = "Calzoni"
                        },
                        new
                        {
                            Id = 6,
                            Name = "Pizze Fritte"
                        },
                        new
                        {
                            Id = 7,
                            Name = "Pizze al Padellino"
                        });
                });

            modelBuilder.Entity("la_mia_pizzeria_static.Models.Ingredient", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("PizzaId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PizzaId");

                    b.ToTable("ingredients");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Mozzarella"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Pomodoro"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Basilico"
                        });
                });

            modelBuilder.Entity("la_mia_pizzeria_static.Models.Pizza", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int?>("CategoryId")
                        .HasColumnType("int");

                    b.Property<string>("Image")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Overview")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<decimal?>("Price")
                        .IsRequired()
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("pizzas");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CategoryId = 1,
                            Image = "https://www.finedininglovers.it/sites/g/files/xknfdk1106/files/fdl_content_import_it/margherita-50kalo.jpg",
                            Name = "Margherita",
                            Overview = "Passata di pomodoro, Mozzarella",
                            Price = 6.50m
                        },
                        new
                        {
                            Id = 2,
                            CategoryId = 1,
                            Image = "https://www.petitchef.it/imgupl/recipe/pizza-4-stagioni--449891p695427.jpg",
                            Name = "4 Stagioni",
                            Overview = "Passata di pomodoro, Mozzarella, Prosciutto cotto, Carcofini, Funghi, Pomodorini",
                            Price = 8.00m
                        },
                        new
                        {
                            Id = 3,
                            CategoryId = 1,
                            Image = "https://www.pizzarecipe.org/wp-content/uploads/2019/01/Pizza-Marinara.jpg",
                            Name = "Marinara",
                            Overview = "Passata di pomodoro, Aglio, Olio",
                            Price = 5.50m
                        },
                        new
                        {
                            Id = 4,
                            CategoryId = 1,
                            Image = "https://i1.wp.com/www.piccolericette.net/piccolericette/wp-content/uploads/2019/10/4102_Pizza.jpg?resize=895%2C616&ssl=1",
                            Name = "Prosciutto e Funghi",
                            Overview = "Passata di pomodoro, Mozzarella, Prosciutto cotto, Funghi",
                            Price = 7.50m
                        });
                });

            modelBuilder.Entity("la_mia_pizzeria_static.Models.Ingredient", b =>
                {
                    b.HasOne("la_mia_pizzeria_static.Models.Pizza", null)
                        .WithMany("Ingredients")
                        .HasForeignKey("PizzaId");
                });

            modelBuilder.Entity("la_mia_pizzeria_static.Models.Pizza", b =>
                {
                    b.HasOne("la_mia_pizzeria_static.Models.Category", "Category")
                        .WithMany("Pizzas")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.Navigation("Category");
                });

            modelBuilder.Entity("la_mia_pizzeria_static.Models.Category", b =>
                {
                    b.Navigation("Pizzas");
                });

            modelBuilder.Entity("la_mia_pizzeria_static.Models.Pizza", b =>
                {
                    b.Navigation("Ingredients");
                });
#pragma warning restore 612, 618
        }
    }
}
