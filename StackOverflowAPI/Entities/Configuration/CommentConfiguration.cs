using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace StackOverflowAPI.Entities.Configuration
{
    public class CommentConfiguration : IEntityTypeConfiguration<Comment>
    {
        public void Configure(EntityTypeBuilder<Comment> builder)
        {
            builder.Property(q => q.CreatedDate)
               .HasDefaultValueSql("getutcdate()");

            builder.HasOne(c => c.Question)
                .WithMany(a => a.Comments)
                .HasForeignKey(c => c.QuestionId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
