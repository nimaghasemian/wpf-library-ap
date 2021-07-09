using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Wpf_library.Domain.Models;

namespace Wpf_library.EntityFramework
{
    public class WpfLibraryDBContext:DbContext
    {
        public WpfLibraryDBContext(DbContextOptions options) : base(options)
        {
        }

        DbSet<Member> Members { get; set; }
        DbSet<Employee> Employees { get; set; }
        DbSet<Manager> Managers { get; set; }
        DbSet<Book> Books { get; set; }
        DbSet<BookTransaction> BookTransactions { get; set; }

    }
}
