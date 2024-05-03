using API.Models;
using API.Utils;

namespace API.Services
{
    public interface IGistService
    {
        Task<Result<Gist>> CreateAsync(Gist gist);
        Task<Result> DeleteAsync(Gist gist);
        Task<Result> DownvoteAsync(Gist gist);
        Task<Result<Gist>> GetByIdAsync(Guid id);
        Task<Result<List<Gist>>> GetPublicGistsAsync();
        Task<Result<List<Gist>>> GetUserGistsAsync(string email);
        Task<Result> UpdateAsync(Gist gist);
        Task<Result> UpvoteAsync(Gist gist);
    }
}