using System;
using System.Collections.Generic;
using System.Linq;
using TestLinq_2.Entities;

namespace TestLinq_2
{
    class Program
    {
        static void Main(string[] args)
        {
            Category c1 = new Category() {ID = 1, Name = "Tools", Tier = 2};
            Category c2 = new Category() {ID = 1, Name = "Computers", Tier = 1};
            Category c3 = new Category() {ID = 1, Name = "Eletronics", Tier = 1};
            
            List<Product> products = new List<Product>()
            {
                new Product() {ID = 1, Name = "Computer", Price = 1100.0, Category = c2},
                new Product() {ID = 2, Name = "Hammer", Price = 90.0, Category = c1},
                new Product() {ID = 3, Name = "TV", Price = 1700.0, Category = c3},
                new Product() {ID = 4, Name = "Notebook", Price = 1300.0, Category = c2},
                new Product() {ID = 5, Name = "Saw", Price = 80.0, Category = c1},
                new Product() {ID = 7, Name = "Camera", Price = 700.0, Category = c3},
                new Product() {ID = 8, Name = "Printer", Price = 350.0, Category = c3},
                new Product() {ID = 9, Name = "MacBook", Price = 1800.0, Category = c2},
                new Product() {ID = 10, Name = "Sound Bar", Price = 700.0, Category = c3},
                new Product() {ID = 11, Name = "Level", Price = 70.0, Category = c1}
            };

            Console.WriteLine("TIER 1 AND PRICE < 900:");
            IEnumerable<Product> productsConsultOne = products
                .Where(p => p.Category.Tier == 1 && p.Price < 900.0);

            foreach (var product in productsConsultOne)
            {
                Console.WriteLine(product);
            }
            
            Console.WriteLine("NAMES OF PRODUCTS FROM TOOLS");
            var namesCategoryOne = products
                .Where(p => p.Category.Name == "Tools")
                .Select(p => p.Name);

            foreach (var product in namesCategoryOne)
            {
                Console.WriteLine(product);
            }

            var productStartWithC = products
                .Where(p => p.Name[0] == 'C')
                .Select(p => new
            {
                p.Name, p.Price, CategoryName = p.Category.Name
            });

            Console.WriteLine("NAMES STARTED WITH 'C' AND ANONYMOUS  OBJECT");
            foreach (var product in productStartWithC)
            {
                Console.WriteLine(product);
            }

            var productsTierOne = products
                .Where(p => p.Category.Tier == 1)
                .OrderBy(p => p.Price)
                .ThenBy(p => p.Name);

            Console.WriteLine("PRODUCTS TIER ONE ORDERED PRICE THEN NAME");
            foreach (var product in productsTierOne)
            {
                Console.WriteLine(product);
            }

            Console.WriteLine("SKIP AND TAKE");
            var skip = productsTierOne.Skip(2).Take(4);
            foreach (var product in skip)
            {
                Console.WriteLine(product);
            }

            var first = products.First();
            
            Console.WriteLine($"First product: {first}");
            
            
        }
    }
}