namespace StudentLogin.Model
{
    public class ExamTable
    {
        
            public int ExamId { get; set; }
            public string ExamTitle { get; set; }
            public TimeSpan ExamDurationMinutes { get; set; }
            public int ExamTeacherId { get; set; }
            public DateTime ExamDate { get; set; }
            public int TotalMarks { get; set; }
            public int PassingMarks { get; set; }
            public bool Status { get; set; }

            // Navigation property to represent the relationship with Teacher
        
       
    }
}
