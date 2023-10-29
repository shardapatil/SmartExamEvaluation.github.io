using System.ComponentModel.DataAnnotations;

namespace Backend.Models
{
    public class QuestionCreationModel
    {
       

        [Required]
        public string? Questext { get; set; }

        public string Option1 { get; set; }
        public string Option2 { get; set; }

        public string Option3 { get; set; }
        public string Option4 { get; set; }

        [Required]
        public int? Answer { get; set; }
    }
}
