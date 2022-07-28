using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace StackOverflowAPI.Entities.Configuration
{
    public class QuestionConfiguration : IEntityTypeConfiguration<Question>
    {
        public void Configure(EntityTypeBuilder<Question> builder)
        {
            builder.Property(q => q.AskedDate)
                .HasDefaultValueSql("getutcdate()");

            builder.Property(q => q.Likes)
                .HasDefaultValue(0);

            builder.Property(q => q.ModifiedDate)
                .ValueGeneratedOnUpdate();
        }
    }
}
