using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PostManagementSystem.Models;

namespace PostManagementSystem.Mapping
{
    public class UserMapping : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("Users");
            builder.HasKey(p => p.ID)
                ;
            builder.Property(p => p.Name)
                .IsRequired()
                .HasAnnotation("Eror", "the Name is Required");
            builder.Property(p => p.Email)
                .IsRequired()
                .HasAnnotation("Eror", "the Email is Required");
            builder.HasIndex(p => p.UserName)
                .IsUnique()
                .HasAnnotation("Eror", "the UserName is Required and must be Unique");
            builder.Property(p => p.Password)
              .IsRequired()
              .HasAnnotation("Eror", "the Password is Required");
            builder.Property(p => p.IsDeleted);

            builder.HasMany(c => c.Post)
               .WithOne(p => p.User)
               .HasForeignKey(t => t.UserID);
        }
    }
}
