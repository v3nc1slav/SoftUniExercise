using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using AutoMapper;
using CarDealer.Data;
using System.Linq;
using Newtonsoft.Json;
using CarDealer.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using CarDealer.DTO;

namespace CarDealer
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            using (var db = new CarDealerContext())
            {
                //db.Database.EnsureDeleted();
                //db.Database.EnsureCreated();

                //var inputJson = File.ReadAllText("./../../../Datasets/suppliers.json");//09
                //var result = ImportSuppliers(db, inputJson);//09

                //var inputJson = File.ReadAllText("./../../../Datasets/parts.json");//10
                //var result = ImportParts(db, inputJson);//10

                //var inputJson = File.ReadAllText("./../../../Datasets/cars.json");//11
                //var result = ImportCars(db, inputJson);//11

                //var inputJson = File.ReadAllText("./../../../Datasets/customers.json");//12
                //var result = ImportCars(db, inputJson);//12

                //var inputJson = File.ReadAllText("./../../../Datasets/sales.json");//13
                //var result = ImportCars(db, inputJson);//13

                //var result = GetOrderedCustomers(db);//14

                //var result = GetCarsFromMakeToyota(db);//15

                //var result = GetLocalSuppliers(db);/16

                //var result = GetCarsWithTheirListOfParts(db);//17

                //var result = GetTotalSalesByCustomer(db);//18

                //var result = GetSalesWithAppliedDiscount(db);//19

                Console.WriteLine(result);
            }
        }
        public static string ImportSuppliers(CarDealerContext context, string inputJson)
        {
            var output = JsonConvert.DeserializeObject<Supplier[]>(inputJson);

            context.Suppliers.AddRange(output);
            context.SaveChanges();

            return $"Successfully imported {output.Length}.";
        }//09
        public static string ImportParts(CarDealerContext context, string inputJson)
        {
            var output = JsonConvert.DeserializeObject<Part[]>(inputJson)
                .Where(s => s.SupplierId <= context.Suppliers.Count()).ToArray();

            context.Parts.AddRange(output);
            context.SaveChanges();

            return $"Successfully imported {output.Length}.";
        }//10
        public static string ImportCars(CarDealerContext context, string inputJson)
        {
            var carsDto = JsonConvert.DeserializeObject<CarInsertDto[]>(inputJson);

            var cars = new List<Car>();
            var partCars = new List<PartCar>();

            foreach (var carDto in carsDto)
            {
                var car = new Car
                {
                    Make = carDto.Make,
                    Model = carDto.Model,
                    TravelledDistance = carDto.TravelledDistance
                };

                foreach (var part in carDto.PartsId.Distinct())
                {
                    var partCar = new PartCar()
                    {
                        PartId = part,
                        Car = car
                    };
                    partCars.Add(partCar);
                }

                cars.Add(car);
            }

            context.Cars.AddRange(cars);
            context.PartCars.AddRange(partCars);
            context.SaveChanges();

            return $"Successfully imported {cars.Count}.";
        }//11
        public static string ImportCustomers(CarDealerContext context, string inputJson)
        {
            var output = JsonConvert.DeserializeObject<Customer[]>(inputJson);

            context.Customers.AddRange(output);
            context.SaveChanges();

            return $"Successfully imported {output.Length}.";
        }//12
        public static string ImportSales(CarDealerContext context, string inputJson)
        {
            var output = JsonConvert.DeserializeObject<Sale[]>(inputJson);

            context.Sales.AddRange(output);
            context.SaveChanges();

            return $"Successfully imported {output.Length}.";
        }//13
        public static string GetOrderedCustomers(CarDealerContext context)
        {
            var output = context
                .Customers
                .OrderBy(c => c.BirthDate)
                .ThenBy(c => c.IsYoungDriver)
                .Select(c => new
                {
                    Name = c.Name,
                    BirthDate = c.BirthDate.ToString("dd/MM/yyyy"),
                    IsYoungDriver = c.IsYoungDriver
                })
                .ToArray();

            var jsonProducts = JsonConvert.SerializeObject(output, Formatting.Indented);
            return jsonProducts;
        }//14
        public static string GetCarsFromMakeToyota(CarDealerContext context)
        {
            var output = context
                .Cars
                .Where(c => c.Make == "Toyota")
                .OrderBy(c => c.Model)
                .ThenByDescending(c => c.TravelledDistance)
                .Select(c => new
                {
                    Id = c.Id,
                    Make = c.Make,
                    Model = c.Model,
                    TravelledDistance = c.TravelledDistance
                })
                .ToArray();


            var jsonProducts = JsonConvert.SerializeObject(output, Formatting.Indented);
            return jsonProducts;
        }//15
        public static string GetLocalSuppliers(CarDealerContext context)
        {
            var output = context
                  .Suppliers
                  .Where(s => s.IsImporter == false)
                  .Select(c => new
                  {
                      c.Id,
                      c.Name,
                      PartsCount = c.Parts.Count
                  })
                  .ToArray();

            var jsonProducts = JsonConvert.SerializeObject(output, Formatting.Indented);
            return jsonProducts;
        }//16
        public static string GetCarsWithTheirListOfParts(CarDealerContext context)
        {
            var output = context
                .Cars
                .Select(c => new
                {
                    car = new
                          {
                          Make = c.Make,
                          Model = c.Model,
                          TravelledDistance = c.TravelledDistance,
                          },
                    parts = c.PartCars
                     .Select(p => new
                     {
                         Name = p.Part.Name,
                         Price = $"{p.Part.Price:f2}"
                     })

                })
                 .ToArray();


            var jsonProducts = JsonConvert.SerializeObject(output, Formatting.Indented);
            return jsonProducts;
        }//17 select in select
        public static string GetTotalSalesByCustomer(CarDealerContext context)
        {
            var output = context
             .Customers
             .Where(c => c.Sales.Any())
             .Select(c => new
             {
                 FullName = c.Name,
                 BoughtCars = c.Sales.Count,
                 SpentMoney = c.Sales.Sum(x => x.Car.PartCars.Sum(y => y.Part.Price))
             })
             .OrderByDescending(x => x.SpentMoney)
             .ThenByDescending(x => x.BoughtCars)
             .ToArray();

            DefaultContractResolver contractResolver = new DefaultContractResolver()
            {
                NamingStrategy = new CamelCaseNamingStrategy()
            };

            var jsonProducts = JsonConvert.SerializeObject(output, new JsonSerializerSettings
            {
                Formatting = Formatting.Indented,
                ContractResolver = contractResolver
            });
            return jsonProducts;
        }//18
        public static string GetSalesWithAppliedDiscount(CarDealerContext context)
        {
            var output = context
                .Sales
                .Select(s => new
                {
                    car = new
                    {
                        Make = s.Car.Make,
                        Model = s.Car.Model,
                        TravelledDistance = s.Car.TravelledDistance
                    },
                    customerName = s.Customer.Name,
                    Discount = $"{s.Discount:f2}",
                    price = $"{s.Car.PartCars.Sum(x => x.Part.Price):f2}",
                    priceWithDiscount = $"{s.Car.PartCars.Sum(x => x.Part.Price) * ((100m - s.Discount) / 100m):f2}"
                })
                .Take(10)
                .ToList();

            var jsonProducts = JsonConvert.SerializeObject(output, new JsonSerializerSettings
            {
                Formatting = Formatting.Indented,
            });
            return jsonProducts;
        }//19


    }
}