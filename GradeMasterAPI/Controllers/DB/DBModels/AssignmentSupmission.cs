namespace GradeMasterAPI.Controllers.DB.DBModels
{
    public class AssignmentSupmission
    {
        public int Id { get; set; }
        public string FilePath { get; set; }
        public int AssignmentId { get; set; }
        public int StudentId { get; set; }
        public DateTime SubmissionDate { get; set; }
        public string Feedback { get; set; }
        public int grade { get; set; }
        public Assignment assignment { get; set; }
        public Student student { get; set; }

    }
}
