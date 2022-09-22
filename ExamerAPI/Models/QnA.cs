namespace ExamerAPI.Models
{
    public class QnA
    {
        public int Id { get; set; }
        public string QText { get; set; }
        public string? ImageName { get; set; }
        public string A1 { get; set; }
        public string A2 { get; set; }
        public string A3 { get; set; }
        public string A4 { get; set; }
        public string ACorrect { get; set; }
        public int? ExamId { get; set; }
        public Exam? Exam { get; set; }

    }
}
