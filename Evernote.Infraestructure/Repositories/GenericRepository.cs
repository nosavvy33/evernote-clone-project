using Microsoft.EntityFrameworkCore;
using Evernote.API.Data;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Evernote.Domain.IRepositories;

namespace Evernote.Infrastructure.Repositories
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class, new()
    {
        private readonly EvernoteDbContext DbContext;

        public GenericRepository(EvernoteDbContext _dbContext)
        {
            DbContext = _dbContext;
        }

        public async Task<TEntity> AddAsync(TEntity entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException($"{nameof(AddAsync)} entity must not be null");
            }

            try
            {
                await DbContext.AddAsync(entity);
                await DbContext.SaveChangesAsync();

                return entity;
            }
            catch (Exception ex)
            {
                throw new Exception($"{nameof(entity)} could not be saved: {ex.Message}");
            }
        }

        public async Task<IEnumerable<TEntity>> GetAll()
        {
            try
            {
                return await DbContext.Set<TEntity>().ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception($"Couldn't retrieve entities: {ex.Message}");
            }
        }

        public async Task<TEntity> UpdateAsync(TEntity entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException($"{nameof(AddAsync)} entity must not be null");
            }

            try
            {
                DbContext.Update(entity);
                await DbContext.SaveChangesAsync();

                return entity;
            }
            catch (Exception ex)
            {
                throw new Exception($"{nameof(entity)} could not be updated: {ex.Message}");
            }
        }
    }
}
