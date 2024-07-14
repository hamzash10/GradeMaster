namespace GradeMasterAPI.Controllers.DB.DBModels
{
    public class Attendence
    {
        public int Id {  get; set; } 
        public string RoomNumber {  get; set; }
        public DateTime start { get; set; }
        public int DurationMinuets {  get; set; }
        public string Status {  get; set; }
        public string Notes { get; set; }
        public int StudentId { get; set; }
        public int CourseId {  get; set; }

        public Student student { get; set; }
        public Course course { get; set; } 
    }
}
