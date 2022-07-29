using AutoMapper;
using StackOverflowAPI.Entities;
using StackOverflowAPI.Models;

namespace StackOverflowAPI.Mapping
{
    public class QuestionMappingProfile : Profile
    {
        public QuestionMappingProfile()
        {
            CreateMap<Question, QuestionDto>()
                .ForMember(m => m.AuthorNick, x => x.MapFrom(u => u.Author.Nick))

                //bez tych linijek mapper nie mapuje tagow i komentarzy :/
                .ForMember(m => m.TagDtos, x => x.MapFrom(t => t.Tags))
                .ForMember(m => m.CommentDtos, x => x.MapFrom(c => c.Comments));



            CreateMap<Comment, CommentDto>();
            CreateMap<Tag, TagDto>();


            CreateMap<CreateQuestionDto, Question>();

            CreateMap<UserDto, User>();

            CreateMap<Answer, AnswerDto>()
                .ForMember(m => m.AuthorNick, x => x.MapFrom(a => a.Author.Nick));

            CreateMap<CreateAnswerDto, Answer>();
        }
    }
}
