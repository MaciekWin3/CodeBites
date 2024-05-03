using System.ComponentModel.DataAnnotations;

namespace API.Repo
{
    public abstract class BaseEntity
    {
        [Required]
        public long Id { get; }

        [MaxLength(255)]
        public string CreatedBy { get; set; } = string.Empty;

        [MaxLength(255)]
        public string ModifiedBy { get; set; } = string.Empty;

        public DateTime CreatedAt { get; set; }

        public DateTime ModifiedAt { get; set; }

        public bool IsDeleted { get; set; }

        public void Delete()
        {
            IsDeleted = true;
        }
    }
}
