﻿using meditation.Core.Models;
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

        public Task<T?> GetByNameAsync(string TName)
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
