using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace API.Models
{
    public class GistConfiguration : IEntityTypeConfiguration<Gist>
    {
        public void Configure(EntityTypeBuilder<Gist> builder)
        {
            builder.ToTable("Gists")
                .HasKey(g => g.Id);

            builder.Property(p => p.Description)
                .HasMaxLength(500);

            builder.HasQueryFilter(p => !p.IsDeleted);
        }
    }
}
