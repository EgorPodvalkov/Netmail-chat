using DAL.Entities;

namespace DAL.Interfaces
{
    public interface IBaseRepository<TEntity> where TEntity : BaseEntity
    {
        /// <summary>
        /// Get all entities from db
        /// </summary>
        Task<IEnumerable<TEntity>> GetAllAsync();

        /// <summary>
        /// Gets entity by ID from db
        /// </summary>
        Task<TEntity?> GetByIdAsync(Guid id);

        /// <summary>
        /// Adds entity to db
        /// </summary>
        Task AddAsync(TEntity entity);

        /// <summary>
        /// Modifies entity in db
        /// </summary>
        Task UpdateAsync(TEntity entity);

        /// <summary>
        /// Removes entity by ID in db
        /// </summary>
        Task DeleteAsync(Guid id);
    }
}
