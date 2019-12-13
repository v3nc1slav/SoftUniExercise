using AutoMapper;
using CarDealer.Data;
using CarDealer.Dtos.Export;
using CarDealer.Dtos.Import;
using CarDealer.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace CarDealer
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            Mapper.Initialize(cfg => cfg.AddProfile(new CarDealerProfile()));
            using (var db = new CarDealerContext())
            {
                //db.Database.EnsureDeleted();
                //db.Database.EnsureCreated();

                //var inputXml = File.ReadAllText("./../../../Datasets/suppliers.xml");//09
                //var result = ImportSuppliers(db, inputXml);//09

                //var inputXml = File.ReadAllText("./../../../Datasets/parts.xml");//10
                //var result = ImportParts(db, inputXml);//10

                //var inputXml = File.ReadAllText("./../../../Datasets/cars.xml");//11
                //var result = ImportCars(db, inputXml);//11

                //var inputXml = File.ReadAllText("./../../../Datasets/customers.xml");//12
                //var result = ImportCustomers(db, inputXml);//12


                Console.WriteLine(result);
            }
        }
        public static string ImportSuppliers(CarDealerContext context, string inputXml)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(InportSuppilerDto[]), new XmlRootAttribute("Suppliers"));

            var suppliersDto = (InportSuppilerDto[])serializer.Deserialize(new StringReader(inputXml));

            var suppliers = new List<Supplier>();

            foreach (var supplierDto in suppliersDto)
            {
                var supplier = new Supplier
                {
                    Name = supplierDto.Name,
                    IsImporter = supplierDto.IsImporter
                };

                suppliers.Add(supplier);
            }

            context.Suppliers.AddRange(suppliers);
            context.SaveChanges();

            return $"Successfully imported {suppliers.Count}";
        }
        public static string ImportParts(CarDealerContext context, string inputXml)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(PartsDto[]), new XmlRootAttribute("Parts"));
            var partsDto = (PartsDto[])serializer.Deserialize(new StringReader(inputXml));
            var parts = new List<Part>();

            var supplierIds = context.Suppliers
                .Select(x => x.Id)
                .ToList();

            foreach (var partDto in partsDto)
            {
                if (supplierIds.Contains(partDto.SupplierId))
                {
                    var part = new Part
                    {
                        Name = partDto.Name,
                        Price = partDto.Price,
                        Quantity = partDto.Quantity,
                        SupplierId = partDto.SupplierId
                    };
                    parts.Add(part);
                }
            }

            context.Parts.AddRange(parts);
            context.SaveChanges();

            return $"Successfully imported {parts.Count}";
        }
        public static string ImportCars(CarDealerContext context, string inputXml)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(CarsDto[]), new XmlRootAttribute("Cars"));
            var carDtos = (CarsDto[])xmlSerializer.Deserialize(new StringReader(inputXml));
            var cars = new List<Car>();

            var validPartIds = context.Parts.Select(x => x.Id).ToList();

            foreach (var carDto in carDtos)
            {
                var car = new Car()
                {
                    Make = carDto.Make,
                    Model = carDto.Model,
                    TravelledDistance = carDto.TravelledDistance
                };

                var uniquePartIds = carDto.PartCars.Select(x => x.Id).Distinct();
                var partCars = new List<PartCar>();

                foreach (var partId in uniquePartIds)
                {
                    if (!validPartIds.Contains(partId))
                    {
                        continue;
                    }

                    partCars.Add(new PartCar
                    {
                        PartId = partId,
                        Car = car
                    });
                }

                car.PartCars = partCars;
                cars.Add(car);
            }

            context.Cars.AddRange(cars);
            context.SaveChanges();

            return $"Successfully imported {cars.Count}";
        }
        public static string ImportCustomers(CarDealerContext context, string inputXml)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(CustomersDto[]), new XmlRootAttribute("Customers"));
            var customersDto = (CustomersDto[])serializer.Deserialize(new StringReader(inputXml));
            var customers = new List<Customer>();

            foreach (var customerDto in customersDto)
            {
                var customer = new Customer
                {
                    Name = customerDto.Name,
                    BirthDate = customerDto.BirthDate,
                    IsYoungDriver = customerDto.IsYoungDriver
                };
                customers.Add(customer);
            }

            context.Customers.AddRange(customers);
            context.SaveChanges();

            return $"Successfully imported {customers.Count}";
        }

}
    }

