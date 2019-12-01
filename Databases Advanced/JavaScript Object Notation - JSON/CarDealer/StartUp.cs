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



    }
}