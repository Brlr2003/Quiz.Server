namespace Quiz.Api.Models
{
    public class Answer
    {
        public long Id { get; set; }
        public long QuestionID { get; set; }
        public required string AnswerText { get; set; }
        public bool IsCorrect { get; set; }

    }
}
