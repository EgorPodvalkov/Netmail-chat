using DAL.Context;
using DAL.Entities;
using DAL.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity>
        where TEntity : BaseEntity
    {
        protected NetmailChatDatabaseContext _db;

        protected BaseRepository(NetmailChatDatabaseContext db)
        {
            _db = db;
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await _db.Set<TEntity>()
                .ToListAsync();
        }

        public async Task<TEntity?> GetByIdAsync(Guid id)
        {
            return await _db.Set<TEntity>()
                .FirstOrDefaultAsync(x => x.ID == id);
        }

        public async Task AddAsync(TEntity entity)
        {
            await _db.Set<TEntity>()
                .AddAsync(entity);

            await _db.SaveChangesAsync();
        }

        public async Task UpdateAsync(TEntity entity)
        {
            _db.Set<TEntity>().Update(entity);
        }

        public async Task DeleteAsync(Guid id)
        {
            var entity = await GetByIdAsync(id);
            if (entity is not null)
            {
                _db.Set<TEntity>().Remove(entity);
            }
        }
    }
}
