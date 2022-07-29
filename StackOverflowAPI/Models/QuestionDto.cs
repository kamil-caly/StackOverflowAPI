namespace StackOverflowAPI.Models
{
    public class QuestionDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Message { get; set; }
        public DateTime AskedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public decimal Views { get; set; }
        public int Likes { get; set; }
        public string AuthorNick { get; set; }
        public List<CommentDto> CommentDtos { get; set; } 
        public List<TagDto> TagDtos { get; set; } 
    }
}
