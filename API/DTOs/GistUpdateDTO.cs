using API.Models;

namespace API.DTOs
{
    public class GistUpdateDTO
    {
        public Guid Id { get; set; }
        public bool Public { get; set; }
        public required string Title { get; set; }
        public string? Language { get; set; }
        public string? Description { get; set; }
        public required string Content { get; set; }

        public Gist ToModel(Gist existingGist)
        {
            existingGist.Public = Public;
            existingGist.Title = Title;
            existingGist.Language = Language;
            existingGist.Description = Description;
            existingGist.Content = Content;
            return existingGist;
        }

        public static GistUpdateDTO FromModel(Gist model)
        {
            return new GistUpdateDTO
            {
                Id = model.Id,
                Public = model.Public,
                Title = model.Title,
                Language = model.Language,
                Description = model.Description,
                Content = model.Content
            };
        }
    }
}
