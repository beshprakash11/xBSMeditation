using meditation.Core.Models;
using Microsoft.EntityFrameworkCore;
using meditation.Infrastructure.Repository.Interface;
using meditation.Infrastructure.DataStoreContext;

namespace meditation.Infrastructure.Repository.Implementation
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseModel
    {
        private readonly StoreContext _storeContext;

        public GenericRepository(StoreContext storeContext)
        {
            _storeContext = storeContext;
        }
        public async Task<T> CreateAsync(T TEntity)
        {
            await _storeContext.Set<T>().AddAsync(TEntity);
            await _storeContext.SaveChangesAsync(); 
            return TEntity;
        }
        

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _storeContext.Set<T>().ToListAsync();
        }

        public async Task<T?> GetByIdAsync(Guid id)
        {
            return await _storeContext.Set<T>().FirstOrDefaultAsync(g => g.Id == id);
        }

        public async Task<T?> GetByNameAsync(string TName)
        {
            var property = typeof(T).GetProperty("TName");
            if (property == null)
                throw new ArgumentException($"Type {typeof(T).Name} does not have a property named 'TName'.");

            return await _storeContext.Set<T>().FirstOrDefaultAsync(
                entity => property.GetValue(entity)!.ToString() == TName);
        }

        public async Task<T?> UpdateByIdAsync(T TEntity)
        {
            var existingEntity = await _storeContext.Set<T>().FirstOrDefaultAsync(g => g.Id == TEntity.Id);
            if (existingEntity != null)
            {
                _storeContext.Entry(existingEntity).CurrentValues.SetValues(TEntity);
                await _storeContext.SaveChangesAsync();
                return TEntity;
            }
            return null;
        }

        public async Task<T?> DeleteByIdAsync(Guid id)
        {
            var existingEntity = await _storeContext.Set<T>().FirstOrDefaultAsync(g => g.Id == id);
            if (existingEntity is null)
            {
                return null;
            }
            _storeContext.Set<T>().Remove(existingEntity);
            await _storeContext.SaveChangesAsync();
            return existingEntity;
        }        
    }
}
