using AutoMapper;
using Microsoft.EntityFrameworkCore;
using StackOverflowAPI.Entities;
using StackOverflowAPI.Models;

namespace StackOverflowAPI.Services
{
    public interface IAnswerService
    {
        public IEnumerable<AnswerDto> getAll();
        public void Create(CreateAnswerDto dto, int userId);
    }
    public class AnswerService : IAnswerService
    {
        private readonly MyStackContext dbContext;
        private readonly IMapper mapper;

        public AnswerService(MyStackContext dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }

        public void Create(CreateAnswerDto dto, int userId)
        {
            var user = dbContext.Users.FirstOrDefault(x => x.Id == userId);

            var answer = mapper.Map<Answer>(dto);
            answer.Author = user;

            dbContext.Answers.Add(answer);
            dbContext.SaveChanges();
        }

        public IEnumerable<AnswerDto> getAll()
        {
            var answers = dbContext
                .Answers
                .Include(q => q.Author)
                .ToList();
                

            var answersDto = mapper.Map<List<AnswerDto>>(answers);

            return answersDto;
        }
    }
}
