namespace Backend.Models
{
    public class QuestionPaper
    {
        public int id { get; set; }
        public string question_name { get; set; }
        public string option_one { get; set; }
        public string option_two { get; set; }
        public string option_three { get; set; }
        public string option_four { get; set; }
        public string question_answer { get; set; }
        public int exam_id { get; set; }
        public string subject_name { get; set; }
        
    }
}
