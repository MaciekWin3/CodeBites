using API.Data;
using API.Models;
using API.Utils;

namespace API.Services
{
    public class GistService : IGistService
    {
        private readonly IGistRepository gistRepository;

        public GistService(IGistRepository gistRepository)
        {
            this.gistRepository = gistRepository;
        }

        public async Task<Result<List<Gist>>> GetUserGistsAsync(string email)
        {
            var gists = await gistRepository.GetUserGistsAsync(email);
            return Result.Ok(gists);
        }

        public async Task<Result<List<Gist>>> GetPublicGistsAsync()
        {
            var gists = await gistRepository.GetPublicGistsAsync();
            return Result.Ok(gists);
        }

        public async Task<Result<Gist>> GetByIdAsync(Guid id)
        {
            var gist = await gistRepository.GetByIdAsync(id);
            return gist is null ? Result.Fail<Gist>("Gist not found") : Result.Ok(gist);
        }

        public async Task<Result<Gist>> CreateAsync(Gist gist)
        {
            var createdGist = await gistRepository.CreateAsync(gist);
            return Result.Ok(createdGist);
        }

        public async Task<Result> UpdateAsync(Gist gist)
        {
            await gistRepository.UpdateAsync(gist);
            return Result.Ok();
        }

        public async Task<Result> DeleteAsync(Gist gist)
        {
            await gistRepository.DeleteAsync(gist);
            return Result.Ok();
        }

        public async Task<Result> UpvoteAsync(Gist gist)
        {
            gist.Upvotes++;
            await gistRepository.UpdateAsync(gist);
            return Result.Ok();
        }

        public async Task<Result> DownvoteAsync(Gist gist)
        {
            gist.Upvotes--;
            await gistRepository.UpdateAsync(gist);
            return Result.Ok();
        }
    }
}
