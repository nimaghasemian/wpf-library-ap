using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Wpf_library.Domain.Services;
using Wpf_library.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Wpf_library.EntityFramework.Services
{
    public abstract class GenericDataService<T> : IDataService<T> where T:class,BaseEntity
    {
        protected readonly WpfLibraryDbContextFactory _contextFactory;

        public GenericDataService(WpfLibraryDbContextFactory contextFactory)
        {
            this._contextFactory = contextFactory;
        }

        public async Task<T> Create(T entity)
        {
            using (WpfLibraryDBContext context = _contextFactory.CreateDbContext())
            {
                var e = await context.Set<T>().AddAsync(entity);
                await context.SaveChangesAsync();
                return e.Entity;
            }
            
        }

        public async Task<bool> Delete(long id)
        {
            using (WpfLibraryDBContext context = _contextFactory.CreateDbContext())
            {
                
                T entity = await context.Set<T>().FirstOrDefaultAsync(e => e.Id == id);
                context.Set<T>().Remove(entity);
                await context.SaveChangesAsync();
                return true;
            }
        }

        public async Task<T> Get(long id)
        {
            using (WpfLibraryDBContext context = _contextFactory.CreateDbContext())
            {

                T entity = await context.Set<T>().FirstOrDefaultAsync(e => e.Id == id);
                return entity;
            }
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            using (WpfLibraryDBContext context = _contextFactory.CreateDbContext())
            {

                IEnumerable<T> entities =  await context.Set<T>().ToListAsync();
                return entities;
            }
        }

        public async Task<T> Update(long id, T entity)
        {
            using (WpfLibraryDBContext context = _contextFactory.CreateDbContext())
            {

               
                entity.Id = id;
                context.Set<T>().Update(entity);
                await context.SaveChangesAsync();
                return entity;
            }
        }

         
    }
}
