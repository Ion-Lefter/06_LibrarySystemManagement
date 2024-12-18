﻿// <auto-generated />
using System;
using LibraryData;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace LibraryData.Migrations
{
    [DbContext(typeof(LibraryBookContext))]
    partial class LibraryBookContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("LibraryDomain.BorrowTransaction", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime?>("BorrowDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("LibraryItemId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("ReturnDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("LibraryItemId");

                    b.ToTable("BorrowTransactions");
                });

            modelBuilder.Entity("LibraryDomain.LibraryItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Author")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("YearPublished")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("LibraryItems", (string)null);

                    b.UseTptMappingStrategy();
                });

            modelBuilder.Entity("LibraryDomain.Book", b =>
                {
                    b.HasBaseType("LibraryDomain.LibraryItem");

                    b.Property<string>("ISBN")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.ToTable("Books", (string)null);
                });

            modelBuilder.Entity("LibraryDomain.EBook", b =>
                {
                    b.HasBaseType("LibraryDomain.LibraryItem");

                    b.Property<string>("FileFormat")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("FileSizeMB")
                        .HasColumnType("float");

                    b.ToTable("EBooks", (string)null);
                });

            modelBuilder.Entity("LibraryDomain.Magazine", b =>
                {
                    b.HasBaseType("LibraryDomain.LibraryItem");

                    b.Property<int>("IssueNumber")
                        .HasColumnType("int");

                    b.ToTable("Magazines", (string)null);
                });

            modelBuilder.Entity("LibraryDomain.BorrowTransaction", b =>
                {
                    b.HasOne("LibraryDomain.LibraryItem", "LibraryItem")
                        .WithMany()
                        .HasForeignKey("LibraryItemId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("LibraryItem");
                });

            modelBuilder.Entity("LibraryDomain.Book", b =>
                {
                    b.HasOne("LibraryDomain.LibraryItem", null)
                        .WithOne()
                        .HasForeignKey("LibraryDomain.Book", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("LibraryDomain.EBook", b =>
                {
                    b.HasOne("LibraryDomain.LibraryItem", null)
                        .WithOne()
                        .HasForeignKey("LibraryDomain.EBook", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("LibraryDomain.Magazine", b =>
                {
                    b.HasOne("LibraryDomain.LibraryItem", null)
                        .WithOne()
                        .HasForeignKey("LibraryDomain.Magazine", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
