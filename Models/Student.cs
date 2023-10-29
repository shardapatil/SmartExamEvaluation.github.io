using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Backend.Models
{
    public class Student
    {
        [Key]
        public int StudentID { get; set; }

        [Required]
        public string? StudentFName { get; set; }

        [Required]
        public string? StudentMName { get; set; }

        [Required]
        public string? StudentLName { get; set; }

        public int GenderID { get; set; }

        [Required]
        [Column("StudentEmail")]
        public string? StudentEmail { get; set; }

        [Required]
        public string? StudentContact { get; set; }
    
        public string? StudentAddress { get; set; }

        [Required]
        public string? StudentUsername { get; set; }

        [Required]
        public string? StudentPassword { get; set; }
    }
}
