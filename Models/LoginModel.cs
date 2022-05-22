using System.ComponentModel.DataAnnotations;

namespace API.Models
{
    public class LoginModel
    {
        [Required]
        public string username{ get; set; }
        [Required]
        public string Password{ get; set; } 
    }
}
