using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Repository
{
    public interface IRepository<T>
    {
        Task<ICollection<T>> GetAll();
        Task<T> GetById(uint id);
        Task<T> Create(T entity);
        Task<T> Update(T entity);
        Task Delete(T entity);

    }
}