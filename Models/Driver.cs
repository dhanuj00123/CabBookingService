using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
namespace CabBookingSystem.Models
{
    public class Driver
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int D_Id { get;set; }
        [Required(ErrorMessage ="Driver Name is Required")]
        public string DriverName { get;set; }
        [Required(ErrorMessage = "Email is Required ")]
        public string Email { get;set; }
        [Required (ErrorMessage = "Drivers Licence Number is Required")]
        public string LicenceNumber { get; set; }
        [Required(ErrorMessage ="Blood group is Required")]
        public string BloodGroup { get;set; }   
        [Required(ErrorMessage ="Driver Image is Required")]
        public string DriverImage { get;set; }
        [Required(ErrorMessage = "Password is Required")]
        public string Password { get; set;  }
    }
}
