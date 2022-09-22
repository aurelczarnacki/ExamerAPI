namespace ExamerAPI.Models
{
    public class Exam
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Code { get; set; }
        public bool IsOn { get; set; }
        public int UserId { get; set; }

    }
}
