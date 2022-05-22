using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
namespace CabBookingSystem.Models
{
    public class Car
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]   
        public int Car_Id { get; set; }

        [ForeignKey("Car_type_Id")]
        public int Car_type_Id { get; set; }
        public  CarType cartype { get; set; }
        public string CarNumber { get; set; }
        public string CarModel { get; set; }
        public string NoOfSeat { get; set; }
        public string CarImage { get; set; }
        public string FuelType { get; set; }
    }
}
