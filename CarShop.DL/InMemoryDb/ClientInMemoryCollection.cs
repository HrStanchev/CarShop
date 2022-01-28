using CarShop.Models.DTO;
using System.Collections.Generic;


namespace CarShop.DL.InMemoryDb
{
    public static class ClientInMemoryCollection
    {
        public static List<Client> ClientDb = new List<Client>()
        {
            new Client()
            {
                Id = 1,
                Name ="Ivan",
                Car = new List<Car>()
                {
                    new Car()
                    {
                        Id=1,
                        Make = "Lada",
                        Model = "Niva"
                    }
                },
                Discount = 5,
                PaymentType = Models.Enums.PaymentType.Cash
            },
            new Client()
            {
                Id=2,
                Name = "Hristo",
                Car=new List<Car>()
                {
                    new Car()
                    {
                        Id=2,
                        Make = "Mercedes-Benz",
                        Model = "E-Class"
                    }
                },
                Discount=10,
                PaymentType = Models.Enums.PaymentType.CreditCard
            },
            new Client()
            {
                Id=3,
                Name = "Petar",
                Car = new List<Car>()
                {
                    new Car()
                    {
                        Id=3,
                        Make = "Honda",
                        Model = "Civic"
                    }
                },
                Discount=0,
                PaymentType = Models.Enums.PaymentType.Cash
            },
            
        };
    }
}
