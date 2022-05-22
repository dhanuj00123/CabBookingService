using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CabBookingSystem.Models
{
    public class Bill
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]   
        public int Bill_Id{ get; set; }
        [ForeignKey("Booking_Id")]
        public int Booking_Id { get; set; }
        public Booking booking  { get; set; }
        
        [ForeignKey ("Car_type_Id")]
        public int Car_type_Id  { get; set; }
        public CarType carType { get; set; }    
        public float TotalPrice { get; set; }

    }
}
