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
        public int? ReservationId { get; set; }
        
        public int? ServiceId { get; set; }

        public string ServiceName { get; set; }
        public decimal UnitPrice { get; set; }
        public int Quantity { get; set; }
        [ForeignKey("ReservationId")]

        public virtual Reservation Reservation { get; set; }
        [ForeignKey("ServiceId")]
        public virtual Service Service { get; set; }
    }
}
