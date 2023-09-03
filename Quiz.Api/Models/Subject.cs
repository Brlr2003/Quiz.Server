namespace Quiz.Api.Models
{
    public class Subject
    {
        public long Id { get; set; }
        public required string Name { get; set; }
        public long DepartmentID { get; set; }
    }
}
