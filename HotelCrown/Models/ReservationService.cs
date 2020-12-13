using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelCrown.Models
{
    public class ReservationService
    {

        [Key]
        public int Id { get; set; }
        [ForeignKey("Reservation")]
        public int ReservationId { get; set; }
        [ForeignKey("Service")]
        public int ServiceId { get; set; }
        public string ServiceName { get; set; }
        public decimal UnitPrice { get; set; }
        public int Quantity { get; set; }

        public virtual Reservation Reservation { get; set; }
        public virtual Service Service { get; set; }
    }
}
