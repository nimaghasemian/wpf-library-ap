using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Wpf_library.Domain.Models;
using Wpf_library.Domain.Services;

namespace Wpf_library.EntityFramework.Services
{
    public class UserDataService<USER>:GenericDataService<USER>,IDataService<USER> where USER:BasePerson
    {
        public UserDataService(WpfLibraryDbContextFactory contextFactory) :base(contextFactory) { }

        public async Task<USER> GetByEmail(string email) 
        {
            using (WpfLibraryDBContext context = _contextFactory.CreateDbContext())
            {
                var e = await context.Set<USER>().FirstOrDefaultAsync(e => e.Email == email);
               
                return e;
            }
        }

    }
}
