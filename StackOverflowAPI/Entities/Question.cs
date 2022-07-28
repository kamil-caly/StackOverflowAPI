namespace StackOverflowAPI.Entities
{
    public class Question
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Message { get; set; }
        public DateTime AskedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public decimal Views { get; set; }
        public int Likes { get; set; }
        public User Author { get; set; }
        public int AuthorId { get; set; }
        public List<Comment> Comments { get; set; } = new List<Comment>();
        public List<Tag> Tags { get; set; }

    }
}
