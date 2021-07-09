using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wpf_library.Domain.Services
{
    public interface IDataService<T>
    {
        Task<IEnumerable<T>> GetAll();
        Task<T> Get(long id);
        Task<T> Create(T entity);
        Task<T> Update(long id, T entity);
        Task<bool> Delete(long id); 
    }
}
