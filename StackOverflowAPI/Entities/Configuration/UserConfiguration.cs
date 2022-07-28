using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace StackOverflowAPI.Entities.Configuration
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.Property(q => q.Reputation)
                .HasPrecision(10, 2);

            builder.Property(u => u.Reputation)
                .HasDefaultValue(0);

            builder.HasMany(u => u.Questions)
                .WithOne(q => q.Author)
                .HasForeignKey(q => q.AuthorId);

            builder.HasMany(u => u.Answers)
                .WithOne(a => a.Author)
                .HasForeignKey(a => a.AuthorId);

            builder.HasMany(u => u.Comments)
                .WithOne(c => c.Author)
                .HasForeignKey(c => c.AuthorId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasData(new User()
            {
                Id = 1,
                Nick = "NickTest",
                Email = "testMail@test.com",
            });
        }
    }
}
