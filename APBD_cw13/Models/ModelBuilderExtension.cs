using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APBD_cw13.Models
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            //customers
            var mockCustomer = new List<Customer_confectionary>();
            mockCustomer.Add(new Customer_confectionary { IdClient = 1, FirstName = "Andrzej", LastName = "Kowalski" });
            mockCustomer.Add(new Customer_confectionary { IdClient = 2, FirstName = "Jan", LastName = "Nowak" });
            mockCustomer.Add(new Customer_confectionary { IdClient = 3, FirstName = "Ola", LastName = "Gruszewska" });
            mockCustomer.Add(new Customer_confectionary { IdClient = 4, FirstName = "Jan", LastName = "Kazimierz" });
            modelBuilder.Entity<Customer_confectionary>().HasData(mockCustomer);

            //Employees
            var mockEmployee = new List<Employee_confectionary>();
            mockEmployee.Add(new Employee_confectionary { IdEmployee = 1, FirstName = "Ala", LastName = "Kotowska" });
            mockEmployee.Add(new Employee_confectionary { IdEmployee = 2, FirstName = "Dogumil", LastName = "Januszewski" });
            mockEmployee.Add(new Employee_confectionary { IdEmployee = 3, FirstName = "Julian", LastName = "Gruszka" });
            modelBuilder.Entity<Employee_confectionary>().HasData(mockEmployee);


            //Orders
            var mockOrder = new List<Order>();
            mockOrder.Add(new Order
            {
                IdOrder = 1,
                DateAccepted = new DateTime(1999, 2, 11),
                DateFinished = new DateTime(2000, 2, 11),
                Notes = "Wszystko ok",
                IdClient = 4,
                IdEmployee = 1
            });

            mockOrder.Add(new Order
            {
                IdOrder = 2,
                DateAccepted = new DateTime(1998, 2, 11),
                DateFinished = new DateTime(2000, 2, 11),
                Notes = "Wszystko ok",
                IdClient = 1,
                IdEmployee = 3
            });

            mockOrder.Add(new Order
            {
                IdOrder = 3,
                DateAccepted = new DateTime(1998, 2, 11),
                DateFinished = new DateTime(2000, 2, 11),
                Notes = "Fajny personel!",
                IdClient = 2,
                IdEmployee = 2
            });

            mockOrder.Add(new Order
            {
                IdOrder = 4,
                DateAccepted = new DateTime(1998, 2, 11),
                DateFinished = new DateTime(2000, 2, 11),
                Notes = "Nie smakowalo :(",
                IdClient = 4,
                IdEmployee = 3
            });
            modelBuilder.Entity<Order>().HasData(mockOrder);


            //Slodycze
            var mockConfectionary = new List<Confectionary>();
            mockConfectionary.Add(new Confectionary { IdConfectionary = 1, Name = "Chocolate", PricePerIte = 100, Type = "food" });
            mockConfectionary.Add(new Confectionary { IdConfectionary = 2, Name = "Makowiec", PricePerIte = 200, Type = "ciasto" });
            mockConfectionary.Add(new Confectionary { IdConfectionary = 3, Name = "baklawa", PricePerIte = 150, Type = "food" });
            modelBuilder.Entity<Confectionary>().HasData(mockConfectionary);

            //Zamowienie slodyczej
            var mockConfectOrder = new List<Confectionary_Order>();
            mockConfectOrder.Add(new Confectionary_Order { IdConfection = 1, IdOrder = 1, Quantity = 2, Notes = "Bardzo dobre slodycze" });
            mockConfectOrder.Add(new Confectionary_Order { IdConfection = 2, IdOrder = 1, Quantity = 4, Notes = "Bardzo dobre" });
            mockConfectOrder.Add(new Confectionary_Order { IdConfection = 3, IdOrder = 2, Quantity = 1, Notes = "Smakowalo" });
            mockConfectOrder.Add(new Confectionary_Order { IdConfection = 3, IdOrder = 3, Quantity = 14, Notes = "Bardzo dobre" });
            mockConfectOrder.Add(new Confectionary_Order { IdConfection = 2, IdOrder = 3, Quantity = 25, Notes = "Bardzo dobre" });
            modelBuilder.Entity<Confectionary_Order>().HasData(mockConfectOrder);
            
           
        }
    }
}
