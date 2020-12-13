using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelCrown.Models
{
    public class Room
    {
        public Room()
        {
            this.Features = new HashSet<Feature>();
        }
        public int Id { get; set; }
        public string RoomName { get; set; }
        public int Capacity { get; set; }
        public decimal Price { get; set; }
        public virtual ICollection<Feature>Features { get; set; }

        public static implicit operator Room(bool v)
        {
            throw new NotImplementedException();
        }
    }
}
