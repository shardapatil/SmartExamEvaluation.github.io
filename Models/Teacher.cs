using System.ComponentModel.DataAnnotations;

namespace Backend.Models
{
    public class Teacher
    {
        [Key]
        public int Teacherid { get; set; }
        public string TeacherFName { get; set; }
        public string TeacherMName { get; set; }
        public string TeacherLName { get; set; }

        public int TeacherGenderId { get; set; }

        public string TeacherUserName { get; set; }

        //public string TeacherEmail { get; set; }

        public string TeacherContact { get; set; }
        public string TeacherAddress { get; set; }
        public string TeacherPassword { get; set; }
        //public string TeacherCPassword { get; set; }


    }
}
