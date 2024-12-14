using meditation.Core.Models;

namespace meditation.Infrastructure.Repository.Interface
{
    public interface IGenericRepository<T> where T : BaseModel
    {
        Task<T> CreateAsync(T TEntity);
        Task<IEnumerable<T>> GetAllAsync();
        Task<T?> GetByIdAsync(Guid id);
        Task<T?> UpdateByIdAsync(T TEntity);
        Task<T?> DeleteByIdAsync(Guid id);
    }
}
