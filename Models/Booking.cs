using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CabBookingSystem.Models
{
    public class Booking
    { 
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Booking_Id { get; set; }

        [ForeignKey("U_Id")]
        public int U_Id { get; set; }
        public User user { get; set; }

        [ForeignKey("Car_Id")]
        public int Car_Id { get; set; }
        public Car car  { get; set; }

        public string Pickup { get; set; }
        public string Drop { get; set; }
        public string Distance { get; set; }
        public DateTime PickDate { get; set; }
        public DateTime PickTime { get; set; }
    }
}
