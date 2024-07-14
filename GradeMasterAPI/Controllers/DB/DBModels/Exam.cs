namespace GradeMasterAPI.Controllers.DB.DBModels
{
    public class Exam
    {
        public int Id { get; set; }
        public string ExamName { get; set; }
        public DateTime ExamDate { get; set; }
        public string RoomNumber { get; set; }
        public int DurationMinutes { get; set; }
        public int CourseId { get; set; }
        public Course course { get; set; }
        public ICollection<ExamSupmission> ExamSupmissions { get; set; }

    }
}
