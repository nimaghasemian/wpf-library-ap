using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Wpf_library.Domain.Models;
using Wpf_library.Domain.Services;

namespace Wpf_library.EntityFramework.Services
{
    public class BookDataService:GenericDataService<Book>,IDataService<Book>
    {
        public BookDataService(WpfLibraryDbContextFactory contextFactory):base(contextFactory) { }
        
        public async Task<Book> GetByISBN(long ISBN)
        {
            using (WpfLibraryDBContext context = _contextFactory.CreateDbContext())
            {
                var e = await context.Set<Book>().FirstOrDefaultAsync(e => e.ISBN == ISBN);
                return e;
            }
        }

    }
}
