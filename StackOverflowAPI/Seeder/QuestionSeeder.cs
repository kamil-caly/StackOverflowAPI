using StackOverflowAPI.Entities;

namespace StackOverflowAPI.Seeder
{
    public class QuestionSeeder
    {
        private readonly MyStackContext dbContext;

        public QuestionSeeder(MyStackContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public void Seed()
        {
            if (dbContext.Database.CanConnect())
            {
                if (!dbContext.Questions.Any())
                {
                    dbContext.Questions.AddRange(GetQuestions());
                    dbContext.SaveChanges();
                }
            }
        }

        private IEnumerable<Question> GetQuestions()
        {
            var questions = new List<Question>()
            {
                new Question()
                {
                    Title = "quest1",
                    Message = "Message to quest1",
                    Author = new User()
                    {
                        Nick = "user2",
                        Email = "testEmail@user2.com"
                    },

                    Tags = new List<Tag>()
                    {
                        new Tag()
                        {
                            Value = "testTag1"
                        },

                        new Tag()
                        {
                            Value = "newQuestionTag"
                        }
                    }
                }
            };
            return questions;
        }
    }
}
