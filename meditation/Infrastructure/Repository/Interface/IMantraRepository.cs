using meditation.Core.Models.Domain;

namespace meditation.Infrastructure.Repository.Interface
{
    public interface IMantraRepository
    {
        Task<MantraModel> CreateMantrasAsync(MantraModel mantras);
        Task<IEnumerable<MantraModel>> GetAllMantrasAsync();
        Task<MantraModel> GetMantrasByIdAsync(Guid id);
        Task<MantraModel> GetMantrasByNameAsync(string mantraname);
        Task<MantraModel> UpdateMantrasAsync(MantraModel mantras);
        Task<MantraModel> DeleteMantrasAsync(Guid id);
    }
}
