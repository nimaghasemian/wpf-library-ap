using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Wpf_library.Domain.Models;

namespace wpf_library.EntityFramework
{
    public class WpfLibraryDBContext:DbContext
    {
        DbSet<Member> Members { get; set; }
        DbSet<Employee> Employees { get; set; }
        DbSet<Manager> Managers { get; set; }
        DbSet<Book> Books { get; set; }
        DbSet<BookTransaction> BookTransactions { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=localhost\\SQLEXPRESS;Database=Library;Trusted_Connection=True;");
            base.OnConfiguring(optionsBuilder);
        }
    }
}
