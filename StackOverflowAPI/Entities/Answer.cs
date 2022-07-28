namespace StackOverflowAPI.Entities
{
    public class Answer
    {
        public int Id { get; set; }
        public string Message { get; set; }
        public DateTime CreatedDate { get; set; }
        public int Likes { get; set; }
    }
}
