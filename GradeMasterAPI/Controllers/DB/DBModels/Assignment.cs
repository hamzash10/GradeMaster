﻿namespace GradeMasterAPI.Controllers.DB.DBModels
{
    public class Assignment
    {
        
        public int Id { get; set; }
        public int CourseId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime DueDate { get; set; }

        public Course Course { get; set; }

    }
}
