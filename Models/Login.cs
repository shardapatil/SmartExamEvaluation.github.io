

using System.ComponentModel.DataAnnotations;

namespace StudentLogin.Model
{
    public class Login
    {
        [Required]
        public int role_ID { get; set; }

        [Required]
        public string? userName { get; set; }

        [Required]
        public string? password { get; set; }

    }
}
