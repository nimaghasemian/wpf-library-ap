using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
namespace Wpf_library.EntityFramework
{
    public class WpfLibraryDbContextFactory : IDesignTimeDbContextFactory<WpfLibraryDBContext>
    {
        public WpfLibraryDBContext CreateDbContext(string[] args = null)
        {
            //setting up the options for connecting to the database using the entity framework
            var options = new DbContextOptionsBuilder();
            options.UseSqlServer("server=localhost\\SQLEXPRESS;Database=Library;Trusted_Connection=True;");

            return new WpfLibraryDBContext(options.Options);
        }

   
    }
}
