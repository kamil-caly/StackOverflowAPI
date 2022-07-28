using StackOverflowAPI.Entities;

namespace StackOverflowAPI.Services
{
    public interface IQuestionService
    {
        public void Create(Question question);
        public List<Question> getAll();
    }
    public class QuestionService : IQuestionService
    {
        private readonly MyStackContext dbContext;
        public QuestionService(MyStackContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public void Create(Question question)
        {
            if (question is null)
            {
                return;
            }

            dbContext.Add(question);
            dbContext.SaveChanges();
        }

        public List<Question> getAll()
        {
            return dbContext.Questions.ToList();
        }
    }
}
