namespace ExamerAPI.Models
{
    public class Score
    {
        public int Id { get; set; }
        public int? UserId { get; set; }
        public User? User { get; set; }
        public string UserName { get; set; }
        public string UserLastName { get; set; }
        public int Max { get; set; }
        public int Points { get; set; }

        public int? ExamId { get; set; }
        public Exam? Exam { get; set; }
    }
}
