using meditation.Core.Models.Domain;
using meditation.Infrastructure.DataStoreContext;
using meditation.Infrastructure.Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace meditation.Infrastructure.Repository.Implementation
{
    public class MantraRepository : IMantraRepository
    {
        private readonly StoreContext _storeContext;

        public MantraRepository(StoreContext storeContext)
        {
            _storeContext = storeContext;
        }
        public async Task<MantraModel> CreateMantrasAsync(MantraModel mantras)
        {
            await _storeContext.Mantras.AddAsync(mantras);  
            await _storeContext.SaveChangesAsync();
            return mantras;
        }


        public async Task<IEnumerable<MantraModel>> GetAllMantrasAsync()
        {
            return await _storeContext.Mantras.ToListAsync();
        }

        public async Task<MantraModel> GetMantrasByIdAsync(Guid id)
        {
            return await _storeContext.Mantras.FirstOrDefaultAsync(m => m.Id == id);
        }

        public async Task<MantraModel> GetMantrasByNameAsync(string mantraname)
        {
            return await _storeContext.Mantras.FirstOrDefaultAsync(m => m.MantraName == mantraname);
        }

        public async Task<MantraModel> UpdateMantrasAsync(MantraModel mantras)
        {
            var existingMantras = await _storeContext.Mantras.FirstOrDefaultAsync(m=>m.Id == mantras.Id);
            if (existingMantras != null)
            {
                _storeContext.Entry(existingMantras).CurrentValues.SetValues(mantras);
                await _storeContext.SaveChangesAsync();
                return mantras;
            }
            return null;
        }
        public async Task<MantraModel> DeleteMantrasAsync(Guid id)
        {
            var existingMantras = await _storeContext.Mantras.FirstOrDefaultAsync(m => m.Id == id);
            if (existingMantras != null)
            {
                return null;
            }

            _storeContext.Mantras.Remove(existingMantras);
            await _storeContext.SaveChangesAsync();
            return existingMantras;
        }
    }
}
