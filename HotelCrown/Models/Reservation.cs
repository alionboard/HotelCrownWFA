using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelCrown.Models
{
    public class Reservation
    {
        public Reservation()
        {
            this.Customers = new HashSet<Customer>();
            this.ReservationServices = new HashSet<ReservationService>();
        }
        public string CustWithComma
        {
            get {return $"{Customers.Select(x => x.FullName).AddComma()}"; }
        }

        [Key]
        public int Id { get; set; }
        [ForeignKey("Room")]
        public int RoomId { get; set; }
        public decimal TotalPrice { get; set; }
        public DateTime CheckInDate { get; set; }
        public DateTime CheckOutDate { get; set; }
        public DateTime? CheckedInTime { get; set; }
        public DateTime? CheckedOutTime { get; set; }
        public virtual Room Room { get; set; }
        public virtual ICollection<Customer> Customers { get; set; }
        public virtual ICollection<ReservationService> ReservationServices { get; set; }
    }
}
