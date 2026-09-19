using System;
using System.Collections.Generic;

class Program
{
    // Task 01
    static List<Product> SearchProducts(List<Product> products, Func<Product, bool> condition)
    {
        List<Product> result = new List<Product>();

        foreach (Product product in products)
        {
            if (condition(product))
            {
                result.Add(product);
            }
        }

        return result;
    }

    // Task 03.1
    static void PrintReport(List<Product> products, Action<Product> action)
    {
        foreach (Product product in products)
        {
            action(product);
        }
    }

    // Task 03.2
    static List<string> TransformProducts(List<Product> products, Func<Product, string> transform)
    {
        List<string> result = new List<string>();

        foreach (Product product in products)
        {
            result.Add(transform(product));
        }

        return result;
    }

    // Task 03.3
    static List<Product> FilterProducts(List<Product> products, Predicate<Product> condition)
    {
        List<Product> result = new List<Product>();

        foreach (Product product in products)
        {
            if (condition(product))
            {
                result.Add(product);
            }
        }

        return result;
    }

    static void Main()
    {
        List<Product> catalog = new List<Product>()
        {
            new Product { Id = 1, Name = "Laptop", Category = "Electronics", Price = 1200, Stock = 10 },
            new Product { Id = 2, Name = "Phone", Category = "Electronics", Price = 800, Stock = 25 },
            new Product { Id = 3, Name = "T-Shirt", Category = "Clothing", Price = 30, Stock = 100 },
            new Product { Id = 4, Name = "Jeans", Category = "Clothing", Price = 60, Stock = 50 },
            new Product { Id = 5, Name = "Chocolate", Category = "Food", Price = 5, Stock = 200 },
            new Product { Id = 6, Name = "Coffee Beans", Category = "Food", Price = 15, Stock = 80 },
            new Product { Id = 7, Name = "C# Book", Category = "Books", Price = 45, Stock = 30 },
            new Product { Id = 8, Name = "Novel", Category = "Books", Price = 20, Stock = 60 },
            new Product { Id = 9, Name = "Headphones", Category = "Electronics", Price = 150, Stock = 40 },
            new Product { Id = 10, Name = "Jacket", Category = "Clothing", Price = 120, Stock = 15 }
        };

        // Task 01: Smart Product Search


        Console.WriteLine(" Task 01: Smart Product Search ");

        List<Product> electronics = SearchProducts(
            catalog,
            product => product.Category == "Electronics"
        );

        Console.WriteLine("--- Electronics ---");
        foreach (Product product in electronics)
        {
            Console.WriteLine($"{product.Name} - ${product.Price} (Stock: {product.Stock})");
        }

        List<Product> under50 = SearchProducts(
            catalog,
            product => product.Price < 50
        );

        Console.WriteLine();
        Console.WriteLine("--- Under $50 ---");
        foreach (Product product in under50)
        {
            Console.WriteLine($"{product.Name} - ${product.Price} (Stock: {product.Stock})");
        }

        List<Product> inStock = SearchProducts(
            catalog,
            product => product.Stock > 0
        );

        Console.WriteLine();
        Console.WriteLine("--- In Stock ---");
        foreach (Product product in inStock)
        {
            Console.WriteLine($"{product.Name} - ${product.Price} (Stock: {product.Stock})");
        }

        List<Product> clothingUnder100 = SearchProducts(
            catalog,
            product => product.Category == "Clothing" && product.Price < 100
        );

        Console.WriteLine();
        Console.WriteLine("--- Clothing Under $100 ---");
        foreach (Product product in clothingUnder100)
        {
            Console.WriteLine($"{product.Name} - ${product.Price} (Stock: {product.Stock})");
        }


        // Task 03.1: Print Reports

        Console.WriteLine();
        Console.WriteLine(" Task 03.1: Print Reports ");

        Console.WriteLine("--- Short Report ---");

        PrintReport(catalog, product =>
        {
            Console.WriteLine($"{product.Name} - ${product.Price}");
        });

        Console.WriteLine();
        Console.WriteLine("--- Detailed Report ---");

        PrintReport(catalog, product =>
        {
            Console.WriteLine(
                $"[{product.Category}] {product.Name} | Price: ${product.Price} | Stock: {product.Stock}"
            );
        });


        // Task 03.2: Transform Products

        Console.WriteLine();
        Console.WriteLine(" Task 03.2: Transform Products ");

        Console.WriteLine("--- Summary List ---");

        List<string> summaryList = TransformProducts(
            catalog,
            product => $"{product.Name} (${product.Price})"
        );

        foreach (string item in summaryList)
        {
            Console.WriteLine(item);
        }

        Console.WriteLine();
        Console.WriteLine("--- Price Labels ---");

        List<string> priceLabels = TransformProducts(
            catalog,
            product =>
            {
                if (product.Price > 100)
                {
                    return $"{product.Name}: Expensive!";
                }
                else
                {
                    return $"{product.Name}: Affordable";
                }
            }
        );

        foreach (string item in priceLabels)
        {
            Console.WriteLine(item);
        }


        // Task 03.3: Filter Products

        Console.WriteLine();
        Console.WriteLine(" Task 03.3: Filter Products ");

        List<Product> lowStockProducts = FilterProducts(
            catalog,
            product => product.Stock < 20
        );

        Console.WriteLine("--- Low-Stock Alert ---");

        foreach (Product product in lowStockProducts)
        {
            Console.WriteLine($"[LOW STOCK] {product.Name}: only {product.Stock} left!");
        }
    }
}
