namespace GradeMasterAPI.Controllers.DB.DBModels
{
    public class Student
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateBirth {  get; set; }
        public string Gender {  get; set; }
        public string PhoneNumber {  get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public DateTime EnrollmentDate {  get; set; }


        //this are the connections one to one and one to manny ...
        //using ICollection instead of list is great for using any container when implementing
        public ICollection<Enrollment> Enrollments { get; set; }
        public ICollection<AssignmentSupmission> AssignmentSupmissions { get; set; }
        public ICollection<ExamSupmission> ExamSupmissions { get; set; }
        public ICollection<Attendence> Attendences { get; set; }
        public ICollection<Grade> FinalGrades { get; set; }


    }
}
