using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
using AutoMapper;
using ProductShop.Data;
using ProductShop.Dtos.Export;
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

                //var result = GetProductsInRange(db);//05

                //var result = GetSoldProducts(db);//06

                var result = GetCategoriesByProductsCount(db);//07

                //var result = GetUsersWithProducts(db);//08
                               
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

        //Problem05
        public static string GetProductsInRange(ProductShopContext context)
        {
            var products = context.Products
                .Where(x => x.Price >= 500 && x.Price <= 1000)
                .Select(x => new ProductsInRangeDto
                {
                    Name = x.Name,
                    Price = x.Price,
                    Buyer = x.Buyer.FirstName + " " + x.Buyer.LastName
                })
                .OrderBy(x => x.Price)
                .Take(10)
                .ToArray();

            StringBuilder sb = new StringBuilder();
            XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces(new[] { XmlQualifiedName.Empty });
            XmlSerializer serializer = new XmlSerializer(typeof(ProductsInRangeDto[]), new XmlRootAttribute("Products"));
            serializer.Serialize(new StringWriter(sb), products, namespaces);

            return sb.ToString().TrimEnd();
        }

        //Problem06
        public static string GetSoldProducts(ProductShopContext context)
        {
            var users = context.Users
                .Where(x => x.ProductsSold.Any())
                .Select(x => new UsersSoldProductsDto
                {
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    SoldProducts = x.ProductsSold.Select(p => new SoldProductsDto
                    {
                        Name = p.Name,
                        Price = p.Price
                    })
                    .ToArray()
                })
                .OrderBy(x => x.LastName)
                .ThenBy(x => x.FirstName)
                .Take(5)
                .ToArray();

            StringBuilder sb = new StringBuilder();
            XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces(new[] { XmlQualifiedName.Empty });
            XmlSerializer serializer = new XmlSerializer(typeof(UsersSoldProductsDto[]), new XmlRootAttribute("Users"));
            serializer.Serialize(new StringWriter(sb), users, namespaces);

            return sb.ToString().TrimEnd();
        }

        //Problem07
        public static string GetCategoriesByProductsCount(ProductShopContext context)
        {
            var categories = context.Categories
                .Select(x => new CategoriesByProductsCountDto
                {
                    Name = x.Name,
                    Count = x.CategoryProducts.Count,
                    AveragePrice = x.CategoryProducts.Average(c => c.Product.Price),
                    TotalRevenue = x.CategoryProducts.Sum(c => c.Product.Price)
                })
                .OrderByDescending(x => x.Count)
                .ThenBy(x => x.TotalRevenue)
                .ToArray();

            StringBuilder sb = new StringBuilder();
            XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces(new[] { XmlQualifiedName.Empty });
            XmlSerializer serializer = new XmlSerializer(typeof(CategoriesByProductsCountDto[]), new XmlRootAttribute("Categories"));
            serializer.Serialize(new StringWriter(sb), categories, namespaces);

            return sb.ToString().TrimEnd();
        }

        //Problem08
        public static string GetUsersWithProducts(ProductShopContext context)
        {

            var users = new UsersDtoQuery
            {
                Count = context.Users.Count(x => x.ProductsSold.Any()),
                Users = context.Users.Where(x => x.ProductsSold.Any()).Select(x => new UserDtoQuery
                {
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    Age = x.Age,
                    SoldProducts = new SoldProductDtoQuery
                    {
                        Count = x.ProductsSold.Count(),
                        ProductDto = x.ProductsSold.Select(p => new ProductDtoQuery
                        {
                            Name = p.Name,
                            Price = p.Price
                        })
                                .OrderByDescending(p => p.Price)
                                .ToArray()
                    }
                })
                    .OrderByDescending(x => x.SoldProducts.Count)
                    .Take(10)
                    .ToArray()
            };

        StringBuilder sb = new StringBuilder();
        var xmlNamespaces = new XmlSerializerNamespaces(new[] { XmlQualifiedName.Empty });
        var serializer = new XmlSerializer(typeof(UsersDtoQuery), new XmlRootAttribute("Users"));
        serializer.Serialize(new StringWriter(sb), users, xmlNamespaces);

            return sb.ToString().TrimEnd();
    }
    }

}