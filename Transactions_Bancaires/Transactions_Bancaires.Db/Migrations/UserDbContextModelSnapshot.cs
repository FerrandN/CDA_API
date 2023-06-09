﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Transactions_Bancaires.Db;

#nullable disable

namespace Transactions_Bancaires.Db.Migrations
{
    [DbContext(typeof(UserDbContext))]
    partial class UserDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Transactions_Bancaires.Models.BankTransaction", b =>
                {
                    b.Property<int>("transaction_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("transaction_id"));

                    b.Property<float?>("transaction_amount")
                        .IsRequired()
                        .HasColumnType("real");

                    b.Property<DateTime?>("transaction_date")
                        .IsRequired()
                        .HasColumnType("datetime2");

                    b.Property<string>("transaction_from")
                        .IsRequired()
                        .HasMaxLength(11)
                        .HasColumnType("nvarchar(11)");

                    b.Property<string>("transaction_to")
                        .IsRequired()
                        .HasMaxLength(11)
                        .HasColumnType("nvarchar(11)");

                    b.HasKey("transaction_id");

                    b.ToTable("BankTransaction");
                });
#pragma warning restore 612, 618
        }
    }
}
