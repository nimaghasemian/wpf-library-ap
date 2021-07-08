﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using wpf_library.EntityFramework;

namespace wpf_library.EntityFramework.Migrations
{
    [DbContext(typeof(WpfLibraryDBContext))]
    partial class WpfLibraryDBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.7")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Wpf_library.Domain.Models.Book", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Author")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Genre")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ISBN")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Remaining")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Books");
                });

            modelBuilder.Entity("Wpf_library.Domain.Models.BookTransaction", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long?>("RentedBookId")
                        .HasColumnType("bigint");

                    b.Property<bool>("RetrunStatus")
                        .HasColumnType("bit");

                    b.Property<DateTime>("ReturnDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("RentedBookId");

                    b.ToTable("BookTransactions");
                });

            modelBuilder.Entity("Wpf_library.Domain.Models.Employee", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long>("Balance")
                        .HasColumnType("bigint");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("isLoggedIn")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.ToTable("Employees");
                });

            modelBuilder.Entity("Wpf_library.Domain.Models.Manager", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("LibBalance")
                        .HasColumnType("bigint");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("isLoggedIn")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.ToTable("Managers");
                });

            modelBuilder.Entity("Wpf_library.Domain.Models.Member", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long>("Balance")
                        .HasColumnType("bigint");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("LastePayDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("MemberShipDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("isLoggedIn")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.ToTable("Members");
                });

            modelBuilder.Entity("Wpf_library.Domain.Models.BookTransaction", b =>
                {
                    b.HasOne("Wpf_library.Domain.Models.Book", "RentedBook")
                        .WithMany()
                        .HasForeignKey("RentedBookId");

                    b.Navigation("RentedBook");
                });
#pragma warning restore 612, 618
        }
    }
}
