namespace GradeMasterAPI.Controllers.DB.DBModels
{
    public class ExamSupmission
    {
        public int Id { get; set; }
        public string FilePath { get; set; }
        public int ExamId { get; set; }
        public int StudentId { get; set; }
        public DateTime SubmissionDate { get; set; }
        public int grade { get; set; }
        public Exam exam { get; set; }
        public Student student { get; set; }
    }
}
