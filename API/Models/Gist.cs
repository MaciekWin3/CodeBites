using API.Repo;
using Microsoft.AspNetCore.Identity;

namespace API.Models
{
    public class Gist : BaseEntity
    {
        public new Guid Id { get; set; }
        public bool Public { get; set; }
        public required string Title { get; set; }
        public string? Extension => Title.Split('.').LastOrDefault();
        public string? Language { get; set; }
        public string? Description { get; set; }
        public long Upvotes { get; set; }
        public required string Content { get; set; }
        public virtual required IdentityUser Owner { get; set; }
    }
}
