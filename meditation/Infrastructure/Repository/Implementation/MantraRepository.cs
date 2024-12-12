using meditation.Core.Models.Domain;
using meditation.Infrastructure.Repository.Interface;

namespace meditation.Infrastructure.Repository.Implementation
{
    public class MantraRepository : IMantraRepository
    {
        public MantraRepository()
        {
            
        }
        public Task<MantraModel> CreateMantrasAsync(MantraModel mantras)
        {
            throw new NotImplementedException();
        }


        public Task<IEnumerable<MantraModel>> GetAllMantrasAsync()
        {
            throw new NotImplementedException();
        }

        public Task<MantraModel> GetMantrasByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<MantraModel> GetMantrasByNameAsync(string mantraname)
        {
            throw new NotImplementedException();
        }

        public Task<MantraModel> UpdateMantrasAsync(MantraModel mantras)
        {
            throw new NotImplementedException();
        }
        public Task<MantraModel> DeleteMantrasAsync(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
