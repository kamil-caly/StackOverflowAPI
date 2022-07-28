namespace StackOverflowAPI.Entities
{
    public class Comment
    {
        public int Id { get; set; }
        public string Message { get; set; }
        public User Author { get; set; }
        public int AuthorId { get; set; }
        public DateTime CreatedDate { get; set; }
        public Question Question { get; set; }
        public int QuestionId { get; set; }
        public Answer Answer { get; set; }
        public int AnswerId { get; set; }

    }
}
