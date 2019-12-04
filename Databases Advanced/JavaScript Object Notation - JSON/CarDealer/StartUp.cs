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



    }
}