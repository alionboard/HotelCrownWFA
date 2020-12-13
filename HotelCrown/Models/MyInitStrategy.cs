using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelCrown.Models
{
    public class MyInitStrategy : CreateDatabaseIfNotExists<HotelContext>
    {
        protected override void Seed(HotelContext context)
        {
            Service service1 = new Service { ServiceName = "SPA", UnitPrice = 100 };
            Service service2 = new Service { ServiceName = "AlaCarte Food", UnitPrice = 20 };
            Service service3 = new Service { ServiceName = "Premium TV", UnitPrice = 15 };

            context.Services.AddRange(new Service[] { service1, service2, service3 });
            context.SaveChanges();

            Feature feature1 = new Feature { FeatureName = "Jakuzzi" };
            Feature feature2 = new Feature { FeatureName = "Sea View" };
            Feature feature3 = new Feature { FeatureName = "Safe Box" };

            context.Features.AddRange(new Feature[] { feature1, feature2, feature3 });
            context.SaveChanges();


            Room room1 = new Room { RoomName = "Small 1", Capacity = 2, Price = 9.99m, Features = { feature3 } }; 
            Room room2 = new Room { RoomName = "Small 2", Capacity = 2, Price = 9.99m, Features = { feature3 } }; 
            Room room3 = new Room { RoomName = "Small 3", Capacity = 2, Price = 9.99m, Features = { feature3 } };
            Room room4 = new Room { RoomName = "Medium", Capacity = 3, Price = 19.99m, Features = { feature3 } };
            Room room5 = new Room { RoomName = "Large", Capacity = 4, Price = 29.99m, Features = { feature3 } };
            Room room6 = new Room { RoomName = "Suit", Capacity = 5, Price = 49.99m, Features = { feature1, feature2, feature3 } };
            context.Rooms.AddRange(new Room[] { room1, room2, room3, room4,room5,room6 });
            context.SaveChanges();

            Customer customer1 = new Customer { FullName = "Ali Oezbek", IdentityNumber = 16425975429, PhoneNumber = "5554568316", BirthDate = new DateTime(1997, 1, 1), Gender = Gender.Male, Description = "He looks sus." };
            Customer customer2 = new Customer { FullName = "Gender Marie", IdentityNumber = 645321564456, PhoneNumber = "58643213632", BirthDate = new DateTime(1992, 5, 12), Gender = Gender.Female };
            Customer customer3 = new Customer
            {
                FullName = "Irene Crank",
                IdentityNumber = 6425975429,
                PhoneNumber = "4561268316",
                BirthDate = new DateTime(1999, 11, 23),
                Gender = Gender.Female,
                Description = "Blonde, tall. Lorem ipsum dolor sit amet."
            };
            context.Customers.AddRange(new Customer[] { customer1, customer2, customer3 });

        }
    }
}
