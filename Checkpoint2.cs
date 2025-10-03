using System;
using System.Collections.Generic;

public class Product
{
    public string Category { get; set; } = "";
    public string Name { get; set; } = "";
    public double Price { get; set; }
}

public class Store
{
    private List<Product> products = new List<Product>();

    public void AddProduct(Product p)
    {
        products.Add(p);
    }

    public void ShowProducts()
    {
        // Sortering med enkel for-loop istället för lambda
        for (int i = 0; i < products.Count - 1; i++)
        {
            for (int j = i + 1; j < products.Count; j++)
            {
                if (products[i].Price > products[j].Price)
                {
                    Product temp = products[i];
                    products[i] = products[j];
                    products[j] = temp;
                }
            }
        }

        double total = 0;

        Console.WriteLine("\nProdukter (sorterade efter pris):");

        foreach (Product p in products)
        {
            Console.WriteLine("Kategori: " + p.Category +
                              ", Namn: " + p.Name +
                              ", Pris: " + p.Price + " kr");
            total += p.Price;
        }

        Console.WriteLine("\nTotalsumma: " + total + " kr");
    }
}

public class Program
{
    public static void Main()
    {
        Store store = new Store();

        while (true)
        {
            while (true)
            {
                Console.Write("Ange kategori (eller 'q' för att visa listan): ");
                string category = (Console.ReadLine() ?? "").Trim();

                if (category.ToLower() == "q")
                {
                    break;
                }

                Console.Write("Ange produktnamn: ");
                string name = (Console.ReadLine() ?? "").Trim();

                Console.Write("Ange pris: ");
                string priceText = (Console.ReadLine() ?? "").Trim();
                priceText = priceText.Replace(',', '.');

                double price;
                if (!double.TryParse(priceText, out price))
                {
                    Console.WriteLine("Fel: ogiltigt pris, försök igen!\n");
                    continue;
                }

                Product product = new Product();
                product.Category = category;
                product.Name = name;
                product.Price = price;

                store.AddProduct(product);

                Console.WriteLine("Produkten har lagts till!\n");
            }

            store.ShowProducts();

            Console.Write("\nVill du lägga till fler produkter? (y/n): ");
            string again = (Console.ReadLine() ?? "").Trim();

            if (!again.Equals("y", StringComparison.OrdinalIgnoreCase))
            {
                break;
            }
        }
    }
}