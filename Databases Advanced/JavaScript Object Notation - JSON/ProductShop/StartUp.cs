﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;
using ProductShop.Data;
using ProductShop.Models;

namespace ProductShop
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            using (var db = new ProductShopContext())
            {
                //db.Database.EnsureDeleted();
                //db.Database.EnsureCreated();

                //var inputJson = File.ReadAllText("./../../../Datasets/users.json");//01
                //var result = ImportUsers(db, inputJson);//01

                //var inputJson = File.ReadAllText("./../../../Datasets/products.json");//02
                //var result = ImportProducts(db, inputJson);//02

                //var inputJson = File.ReadAllText("./../../../Datasets/categories.json");//03
                //var result = ImportCategories(db, inputJson);//03

                //var inputJson = File.ReadAllText("./../../../Datasets/categories-products.json");//04
                //var result = ImportCategoryProducts(db, inputJson);//04

                //var result = GetProductsInRange(db);//05

                var result = GetSoldProducts(db);//06

                Console.WriteLine(result);
            }
        }

        public static string ImportUsers(ProductShopContext context, string inputJson)
        {
            var users = JsonConvert.DeserializeObject<User[]>(inputJson);

            context.Users.AddRange(users);
            context.SaveChanges();

            return $"Successfully imported {users.Length}";
        }//01
        public static string ImportProducts(ProductShopContext context, string inputJson)
        {
            var products = JsonConvert.DeserializeObject<Product[]>(inputJson);

            context.AddRange(products);
            context.SaveChanges();

            return $"Successfully imported {products.Length}";
        }//02
        public static string ImportCategories(ProductShopContext context, string inputJson)
        {
            var categories = JsonConvert.DeserializeObject<Category[]>(inputJson);

            context.AddRange(categories
                .Where(c=>c.Name!=null)
                );
            context.SaveChanges();

            return $"Successfully imported {context.Categories.Count()}";
        }//03
        public static string ImportCategoryProducts(ProductShopContext context, string inputJson)
        {
            var categoryProducts = JsonConvert.DeserializeObject<CategoryProduct[]>(inputJson);

            context.AddRange(categoryProducts);
            context.SaveChanges();

            return $"Successfully imported {categoryProducts.Length}";
        }//04
        public static string GetProductsInRange(ProductShopContext context)
        {
            var products = context.Products
                .Where(x => x.Price >= 500 && x.Price <= 1000)
                .OrderBy(x => x.Price)
                .Select(x => new
                {
                    name = x.Name,
                    price = x.Price,
                    seller = $"{x.Seller.FirstName} {x.Seller.LastName}"
                })
                .ToArray();

            var jsonProducts = JsonConvert.SerializeObject(products, Formatting.Indented);
            return jsonProducts;
        }//05
        public static string GetSoldProducts(ProductShopContext context)
        {
            var users = context.Users
                 .Where(x => x.ProductsSold.Count > 0 && x.ProductsSold.Any(p => p.Buyer != null))
                 .OrderBy(x => x.LastName)
                 .ThenBy(x => x.FirstName)
                 .Select(x => new
                 {
                   firstName = x.FirstName,
                   lastName = x.LastName,
                   soldProducts = x.ProductsSold
                      .Where(b => b.Buyer != null)
                      .Select(s => new
                          {
                            name = s.Name,
                            price = s.Price,
                            buyerFirstName = s.Buyer.FirstName,
                            buyerLastName = s.Buyer.LastName
                           }).ToArray()
                 }).ToArray();

            var jsonUsers = JsonConvert.SerializeObject(users, new JsonSerializerSettings
            {
                Formatting = Formatting.Indented,
            });
            return jsonUsers;
        }//06 Select in select
    }
}