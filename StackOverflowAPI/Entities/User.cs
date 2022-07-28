namespace StackOverflowAPI.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string Nick { get; set; }
        public string Email { get; set; }
        public decimal Reputation { get; set; }

        public List<Question> Questions { get; set; } = new List<Question>();
        public List<Answer> Answers { get; set; } = new List<Answer>();

    }
}
