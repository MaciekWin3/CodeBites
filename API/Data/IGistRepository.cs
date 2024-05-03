using API.Models;

namespace API.Data
{
    public interface IGistRepository
    {
        Task<Gist> CreateAsync(Gist gist);
        Task DeleteAsync(Gist gist);
        Task<Gist?> GetByIdAsync(Guid id);
        Task<List<Gist>> GetPublicGistsAsync();
        Task<List<Gist>> GetUserGistsAsync(string email);
        Task UpdateAsync(Gist gist);
    }
}