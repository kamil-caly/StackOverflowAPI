namespace StackOverflowAPI.Models
{
    public class AnswerDto
    {
        public int Id { get; set; }
        public string Message { get; set; }
        public DateTime CreatedDate { get; set; }
        public int Likes { get; set; }
        public string AuthorNick { get; set; }
        public List<CommentDto> CommentDtos { get; set; }
    }
}
