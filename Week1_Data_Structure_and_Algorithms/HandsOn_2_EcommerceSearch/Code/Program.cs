using System;
using System.Linq;

class Program
{
    public static Product? LinearSearch(Product[] products, int targetId)
    {
        foreach (var product in products)
        {
            if (product.ProductId == targetId)
                return product;
        }
        return null;
    }

    public static Product? BinarySearch(Product[] products, int targetId)
    {
        int low = 0, high = products.Length - 1;

        while (low <= high)
        {
            int mid = (low + high) / 2;
            if (products[mid].ProductId == targetId)
                return products[mid];
            else if (products[mid].ProductId < targetId)
                low = mid + 1;
            else
                high = mid - 1;
        }

        return null;
    }

    static void Main()
    {
        Product[] products = {
            new Product(103, "Shoes", "Footwear"),
            new Product(101, "T-Shirt", "Apparel"),
            new Product(105, "Laptop", "Electronics"),
            new Product(102, "Watch", "Accessories"),
            new Product(104, "Mobile", "Electronics")
        };

        Console.WriteLine("Linear Search:");
        var result1 = LinearSearch(products, 102);
        Console.WriteLine(result1 != null ? result1.ToString() : "Product not found");

        var sortedProducts = products.OrderBy(p => p.ProductId).ToArray();

        Console.WriteLine("\n Binary Search:");
        var result2 = BinarySearch(sortedProducts, 102);
        Console.WriteLine(result2 != null ? result2.ToString() : "Product not found");
    }
}
