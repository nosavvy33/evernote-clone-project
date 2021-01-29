using System.Collections.Generic;
using System.Threading.Tasks;

namespace Evernote.Domain.IRepositories
{
    public interface IGenericRepository<TEntity>
    {
        Task<IEnumerable<TEntity>> GetAll();
        Task<TEntity> AddAsync(TEntity entity);
        Task<TEntity> UpdateAsync(TEntity entity);
    }
}
