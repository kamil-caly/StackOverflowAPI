namespace StackOverflowAPI.Models
{
    public class CreateQuestionDto
    {
        public string Title { get; set; }
        public string Message { get; set; }
        public DateTime AskedDate { get; set; } 

    }
}
