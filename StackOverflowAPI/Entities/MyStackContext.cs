using Microsoft.EntityFrameworkCore;

namespace StackOverflowAPI.Entities
{
    public class MyStackContext : DbContext
    {
        public MyStackContext(DbContextOptions<MyStackContext> options) : base(options)
        {

        }

        public DbSet<User> Users { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Answer> Answers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        { 
            modelBuilder.ApplyConfigurationsFromAssembly(this.GetType().Assembly);
        }
    }
}
