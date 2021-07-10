using System;
using System.Collections.Generic;
using System.Text;
using Wpf_library.Domain.Models;

namespace Wpf_library.EntityFramework.Services
{
    public class BookTransactionDataSerivce : GenericDataService<BookTransaction>
    {
        public BookTransactionDataSerivce(WpfLibraryDbContextFactory contextFactory) : base(contextFactory)
        {

        }
    }
}
