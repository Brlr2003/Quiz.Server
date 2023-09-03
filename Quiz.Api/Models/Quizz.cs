namespace Quiz.Api.Models
{
    public class Quizz
    {
        public long Id { get; set; }
        public long SubjectId { get; set; }
        public long UserId { get; set; }
        public DateTime StartDate { get; set; }
        public int? Score { get; set; }
    }
}
