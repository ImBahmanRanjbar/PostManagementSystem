using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PostManagementSystem.Models;

namespace PostManagementSystem.Mapping
{
    public class PostMapping : IEntityTypeConfiguration<Post>
    {
        public void Configure(EntityTypeBuilder<Post> builder)
        {
            builder.ToTable("Posts");
            builder.HasKey(p => p.ID);

            builder.Property(p => p.urlImage).IsRequired()
              .HasAnnotation("eror", "the image is required");
            builder.Property(p => p.Description)
                .IsRequired()
              .HasAnnotation("eror", "the des is required");
            builder.Property(p => p.IsDeleted)
                .IsRequired();

            builder.HasOne(p => p.User)
                .WithMany(p => p.Post)
                .HasForeignKey(p => p.UserID);

        }
    }
}
