﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MoneyCheck.DataAcess.EntityFramework;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace MoneyCheck.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20240812190827_Initial")]
    partial class Initial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("MoneyCheck.Models.Account", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<decimal>("AccountBalance")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("numeric")
                        .HasDefaultValue(0m);

                    b.Property<string>("AccountName")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("character varying(15)");

                    b.Property<int>("UserId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Accounts", "MoneyCheck");
                });

            modelBuilder.Entity("MoneyCheck.Models.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("AccountId")
                        .HasColumnType("integer");

                    b.Property<string>("CategoryName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("CategoryOperationDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<decimal>("CategorySum")
                        .HasColumnType("numeric");

                    b.HasKey("Id");

                    b.HasIndex(new[] { "AccountId" }, "Category_AccountId")
                        .IsUnique();

                    b.ToTable("Categories", "MoneyCheck");
                });

            modelBuilder.Entity("MoneyCheck.Models.Operation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("CategoryId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("Operations", "MoneyCheck");
                });

            modelBuilder.Entity("MoneyCheck.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<decimal>("Balance")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("numeric")
                        .HasDefaultValue(0m);

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("character varying(15)");

                    b.HasKey("Id");

                    b.ToTable("Users", "MoneyCheck");
                });

            modelBuilder.Entity("MoneyCheck.Models.Account", b =>
                {
                    b.HasOne("MoneyCheck.Models.User", "UserNavigation")
                        .WithMany("UserAccounts")
                        .HasForeignKey("UserId")
                        .IsRequired()
                        .HasConstraintName("FK_UsersAccount_Users_UserId");

                    b.Navigation("UserNavigation");
                });

            modelBuilder.Entity("MoneyCheck.Models.Category", b =>
                {
                    b.HasOne("MoneyCheck.Models.Account", "Account")
                        .WithMany("AccountCategories")
                        .HasForeignKey("AccountId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Account");
                });

            modelBuilder.Entity("MoneyCheck.Models.Operation", b =>
                {
                    b.HasOne("MoneyCheck.Models.Category", "Category")
                        .WithMany("CategoryOperations")
                        .HasForeignKey("CategoryId")
                        .IsRequired()
                        .HasConstraintName("FK_CategoryOperations_Category_CategoryId");

                    b.Navigation("Category");
                });

            modelBuilder.Entity("MoneyCheck.Models.Account", b =>
                {
                    b.Navigation("AccountCategories");
                });

            modelBuilder.Entity("MoneyCheck.Models.Category", b =>
                {
                    b.Navigation("CategoryOperations");
                });

            modelBuilder.Entity("MoneyCheck.Models.User", b =>
                {
                    b.Navigation("UserAccounts");
                });
#pragma warning restore 612, 618
        }
    }
}