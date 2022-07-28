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

            builder.HasMany(q => q.Comments)
                .WithOne(c => c.Question)
                .HasForeignKey(c => c.QuestionId);

            builder.HasMany(q => q.Tags)
                .WithMany(t => t.Questions)
                .UsingEntity<QuestionTag>(
                    w => w.HasOne(qt => qt.Tag)
                    .WithMany()
                    .HasForeignKey(qt => qt.TagId),

                    w => w.HasOne(qt => qt.Question)
                    .WithMany()
                    .HasForeignKey(qt => qt.QuestionId),

                    qt =>
                    {
                        qt.HasKey(x => new { x.TagId, x.QuestionId });
                        qt.Property(x => x.PublicationDate)
                        .HasDefaultValueSql("getutcdate()");
                    }
                );
        }
    }
}
