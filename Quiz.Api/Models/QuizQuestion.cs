namespace Quiz.Api.Models
{
    public class QuizQuestion
    {
        public long Id { get; set; }
        public long QuizId { get; set; }
        public long QuestionId { get; set; }
        public required string CorrectAnswer { get; set; }
        public long? AnswerId { get; set; }
    }
}
