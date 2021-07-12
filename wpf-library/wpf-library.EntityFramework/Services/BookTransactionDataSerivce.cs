using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wpf_library.Domain.Models;

namespace Wpf_library.EntityFramework.Services
{
    public class BookTransactionDataSerivce : GenericDataService<BookTransaction>
    {
        public BookTransactionDataSerivce(WpfLibraryDbContextFactory contextFactory) : base(contextFactory)
        {

        }

        public async Task<BookTransaction> GetByBookId(long bookId)
        {
            using (WpfLibraryDBContext context = _contextFactory.CreateDbContext())
            {
                var e = await context.Set<BookTransaction>().FirstOrDefaultAsync(e => e.RentedBook.Id == bookId);

                return e;
            }
        }
        public async Task<IEnumerable<BookTransaction>> GetByMemberID(long memberId)
        {
            using (WpfLibraryDBContext context = _contextFactory.CreateDbContext())
            {
                var e = await context.Set<BookTransaction>().AsQueryable().Where(e => e.RentingMember.Id == memberId).ToListAsync();
                return e;
            }
        }
    }
}
