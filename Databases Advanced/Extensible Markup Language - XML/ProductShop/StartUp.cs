using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
using AutoMapper;
using ProductShop.Data;
using ProductShop.Dtos.Import;
using ProductShop.Models;


namespace ProductShop
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            Mapper.Initialize(cfg => cfg.AddProfile(new ProductShopProfile()));
            using (var db = new ProductShopContext())
            {
                //db.Database.EnsureDeleted();
                //db.Database.EnsureCreated();

                //var inputXml = File.ReadAllText("./../../../Datasets/users.xml");//01
                //var result = ImportUsers(db, inputXml);//01

                //var inputXml = File.ReadAllText("./../../../Datasets/products.xml");//02
                //var result = ImportProducts(db, inputXml);//02

                //var inputXml = File.ReadAllText("./../../../Datasets/categories.xml");//03
                //var result = ImportCategories(db, inputXml);//03

                //var inputXml = File.ReadAllText("./../../../Datasets/categories-products.xml");//04
                //var result = ImportCategoryProducts(db, inputXml);//04



                Console.WriteLine(result);
            }
        }
        //Problem01
        public static string ImportUsers(ProductShopContext context, string inputXml)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(UserDto[]), new XmlRootAttribute("Users"));

            var usersDto = (UserDto[])serializer.Deserialize(new StringReader(inputXml));

            var users = new List<User>();

            foreach (var userDto in usersDto)
            {
                var user = new User
                {
                    FirstName = userDto.FirstName,
                    LastName = userDto.LastName,
                    Age = userDto.Age
                };

                users.Add(user);
            }

            context.Users.AddRange(users);
            context.SaveChanges();

            return $"Successfully imported {users.Count}";
        }

        //Problem02
        public static string ImportProducts(ProductShopContext context, string inputXml)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(ProductsDto[]), new XmlRootAttribute("Products"));
            var productsDto = (ProductsDto[])serializer.Deserialize(new StringReader(inputXml));
            var products = new List<Product>();

            foreach (var productDto in productsDto)
            {
                var product = new Product
                {
                    Name = productDto.name,
                    Price = productDto.price,
                    SellerId = productDto.sellerId,
                    BuyerId = productDto.buyerId
                };
                products.Add(product);
            }

            context.Products.AddRange(products);
            context.SaveChanges();

            return $"Successfully imported {products.Count}";
        }

        //Problem03
        public static string ImportCategories(ProductShopContext context, string inputXml)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(CategoryDto[]), new XmlRootAttribute("Categories"));

            var categoreisDto = (CategoryDto[])serializer.Deserialize(new StringReader(inputXml));

            var categories = new List<Category>();

            foreach (var categoryDto in categoreisDto)
            {
                if (categoryDto.name != null)
                {
                    var category = new Category
                    {
                        Name = categoryDto.name,
                    };

                    categories.Add(category);
                }
            }
            context.Categories.AddRange(categories);
            context.SaveChanges();

            return $"Successfully imported {categories.Count}";
        }

        //Problem04
        public static string ImportCategoryProducts(ProductShopContext context, string inputXml)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(CategoryProductsDto[]), new XmlRootAttribute("CategoryProducts"));

            var categoryProductsDto = (CategoryProductsDto[])serializer.Deserialize(new StringReader(inputXml));

            var categoryProducts = new List<CategoryProduct>();

            foreach (var categoryProductDto in categoryProductsDto)
            {
                var categoryIdExists = context.CategoryProducts.Any(x => x.CategoryId == categoryProductDto.categoryId);
                var productIdExists = context.CategoryProducts.Any(x => x.ProductId == categoryProductDto.productId);

                if (!categoryIdExists && !productIdExists)
                {
                    var categoryProduct = new CategoryProduct
                    {
                        CategoryId = categoryProductDto.categoryId,
                        ProductId = categoryProductDto.productId
                    };

                    categoryProducts.Add(categoryProduct);
                }
            }
            context.CategoryProducts.AddRange(categoryProducts);
            context.SaveChanges();

            return $"Successfully imported {categoryProducts.Count}";
        }
    }

}