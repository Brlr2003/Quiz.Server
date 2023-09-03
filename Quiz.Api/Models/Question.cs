namespace Quiz.Api.Models
{
    public class Question
    {
        public long Id { get; set; }
        public required string Description { get; set; }
        public long SubjectID { get; set; }
    }
}
