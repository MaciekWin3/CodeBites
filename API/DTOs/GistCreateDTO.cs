using API.Models;
using Microsoft.AspNetCore.Identity;

namespace API.DTOs
{
    public record GistCreateDTO
    {
        public bool Public { get; set; }
        public required string Title { get; set; }
        public string? Language { get; set; }
        public string? Description { get; set; }
        public required string Content { get; set; }

        public Gist ToModel(IdentityUser owner)
        {
            return new Gist
            {
                Id = Guid.NewGuid(),
                Public = Public,
                Title = Title,
                Language = Language,
                Description = Description,
                Content = Content,
                Upvotes = 0,
                Owner = owner
            };
        }
    }
}
