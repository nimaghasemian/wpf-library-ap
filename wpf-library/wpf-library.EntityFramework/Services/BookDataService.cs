using System;
using System.Collections.Generic;
using System.Text;
using Wpf_library.Domain.Models;
using Wpf_library.Domain.Services;

namespace Wpf_library.EntityFramework.Services
{
    class BookDataService:GenericDataService<Book>,IDataService<Book>
    {
        public BookDataService(WpfLibraryDbContextFactory contextFactory):base(contextFactory) { }
        

    }
}
