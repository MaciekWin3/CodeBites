using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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

        [Column(TypeName = "datetime2(2)")]
        public DateTime CreatedAt { get; set; }

        [Column(TypeName = "datetime2(2)")]
        public DateTime ModifiedAt { get; set; }

        public bool IsDeleted { get; set; }

        public void Delete()
        {
            IsDeleted = true;
        }
    }
}
