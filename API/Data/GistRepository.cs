using API.Models;
using API.Repo;
using Microsoft.EntityFrameworkCore;

namespace API.Data
{
    public class GistRepository : BaseRepository, IGistRepository
    {
        public GistRepository(DataContext context) : base(context) { }

        public async Task<List<Gist>> GetUserGistsAsync(string email)
        {
            return await context.Gists
                .Include(g => g.Owner)
                .Where(g => g.Owner.Email == email)
                .ToListAsync();
        }

        public async Task<List<Gist>> GetPublicGistsAsync()
        {
            return await context.Gists
                .Include(g => g.Owner)
                .Where(g => g.Public)
                .ToListAsync();
        }

        public async Task<Gist?> GetByIdAsync(Guid id)
        {
            return await context.Gists
                .Include(g => g.Owner)
                .FirstOrDefaultAsync(g => g.Id == id);
        }

        public async Task<Gist> CreateAsync(Gist gist)
        {
            await context.Gists.AddAsync(gist);
            await context.SaveChangesAsync();
            return gist;
        }

        public async Task UpdateAsync(Gist gist)
        {
            context.Gists.Update(gist);
            await context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Gist gist)
        {
            context.Gists.Remove(gist);
            await context.SaveChangesAsync();
        }
    }
}
