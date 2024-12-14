using meditation.Core.Models;
using Microsoft.EntityFrameworkCore;
using meditation.Infrastructure.Repository.Interface;

namespace meditation.Infrastructure.Repository.Implementation
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseModel
    {
        public Task<T> CreateAsync(T TEntity)
        {
            throw new NotImplementedException();
        }
        

        public Task<IEnumerable<T>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<T?> GetByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<T?> UpdateByIdAsync(T TEntity)
        {
            throw new NotImplementedException();
        }

        public Task<T?> DeleteByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
