namespace GradeMasterAPI.Controllers.DB.DBModels
{
    public class Course
    {
        public int ID {  get; set; }
        public string CourseName { get; set; }
        public string CourseDescription {  get; set; }
        public int TeacherId { get; set; }
        public Teacher Teacher {  get; set; }

        #region -----NAVIGATION PROPERTIES-----
        public ICollection<Exam> Exams{ get; set; } = new List<Exam>();
        public ICollection<Assignment> Assignment { get; set; } = new List<Assignment>();
        public ICollection<Enrollment> Enrollments { get; set; } = new List<Enrollment>();
        public ICollection<Grade> FinalGrades { get; set; }

        #endregion
    }
}
