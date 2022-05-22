using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CabBookingSystem.Models
{
    public class Driver_Assigned
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]   
        public int DA_Id { get; set; }

        [ForeignKey("Booking_Id")]
        public int Booking_Id { get; set; }
        public Booking booking { get; set; }


        [ForeignKey("D_Id")]
        public int D_Id { get; set; }
        public Driver driver { get; set; }


        [ForeignKey("Car_Id")]
        public int Car_Id {get; set; }  
        public Car car { get; set; }

    }
}
