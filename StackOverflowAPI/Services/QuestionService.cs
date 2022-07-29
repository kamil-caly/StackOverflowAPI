using AutoMapper;
using Microsoft.EntityFrameworkCore;
using StackOverflowAPI.Entities;
using StackOverflowAPI.Models;

namespace StackOverflowAPI.Services
{
    public interface IQuestionService
    {
        public void Create(CreateQuestionDto dto, int userId);
        public IEnumerable<QuestionDto> getAll();
        public QuestionDto Get(int id);
    }
    public class QuestionService : IQuestionService
    {
        private readonly MyStackContext dbContext;
        private readonly IMapper mapper;

        public QuestionService(MyStackContext dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }

        public void Create(CreateQuestionDto dto, int userId)
        {
            var user = dbContext.Users.FirstOrDefault(x => x.Id == userId);

            var question = mapper.Map<Question>(dto);
            question.Author = user;

            dbContext.Questions.Add(question);
            dbContext.SaveChanges();
        }

        public IEnumerable<QuestionDto> getAll()
        {
            var questions = dbContext
                .Questions
                .Include(q => q.Author)
                .Include(q => q.Comments)
                .Include(q => q.Tags)
                .ToList();

            var questionDto = mapper.Map<List<QuestionDto>>(questions);

            return questionDto;
        }

        public QuestionDto Get(int id)
        {
            var question = dbContext
                .Questions
                .Include(q => q.Author)
                .Include(q => q.Comments)
                .Include(q => q.Tags)
                .FirstOrDefault(x => x.Id == id);

            var questionDto = mapper.Map<QuestionDto>(question);

            return questionDto;
        }
    }
}
