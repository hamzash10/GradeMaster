namespace GradeMasterAPI.Controllers.DB.DBModels
{
    public class Grade
    {
        public int Id { get; set; }
        public int StudentId { get; set; }
        public int CourseId { get; set; }
        public int FinalGrade { get; set; }
        public int SubmissionGrade { get; set; }
        public int AttendanceGrade { get; set; }
        public Student student { get; set; }
        public Course course { get; set; }
    }
}
