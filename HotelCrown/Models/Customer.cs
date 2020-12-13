using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelCrown.Models
{
    public class Customer
    {
        public Customer()
        {
            this.Reservations = new HashSet<Reservation>();
        }
        public int Id { get; set; }
        public string FullName { get; set; }
        public long IdentityNumber { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime BirthDate { get; set; }
        public Gender Gender { get; set; }
        public string Description { get; set; }
        public virtual ICollection<Reservation>Reservations { get; set; }
    }
}
