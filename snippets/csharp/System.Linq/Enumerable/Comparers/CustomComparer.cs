using System;
using System.Collections.Generic;
using System.Linq;

namespace Comparers;

//<Snippet1>
public class Product(string name, int code)
{
    public string Name { get; set; } = name;
    public int Code { get; set; } = code;
}

// Custom comparer for the Product class
class ProductComparer : IEqualityComparer<Product>
{
    // Products are equal if their names and product numbers are equal.
    public bool Equals(Product? x, Product? y) =>
        //Check whether the compared objects reference the same data.
        ReferenceEquals(x, y) ||
        (   x is not null &&          //Check if any of the compared objects is null
            y is not null &&
            x.Code == y.Code &&     //Check if the products' properties are equal.
            x.Name == y.Name);

    // If Equals() returns true for a pair of objects
    // then GetHashCode() must return the same value for these objects.

    public int GetHashCode(Product product)
    {
        //Check whether the object is null
        if (product is null) return 0;

        //Get hash code for the Name field
        var hashProductName = product.Name.GetHashCode();

        //Get hash code for the Code field
        var hashProductCode = product.Code.GetHashCode();

        //Calculate the hash code for the product.
        return hashProductName ^ hashProductCode;
    }
}
//</Snippet1>

static class Program
{
    static void Main()
    {
        //<Intersect>
        Product[] store1 = [
            new("apple",9 ),
            new("orange",4 ) ];

        Product[] store2 = [
            new("apple",9 ),
            new("lemon",12 ) ];

        // Get the products from the first array
        // that have duplicates in the second array.

        IEnumerable<Product> duplicates =
            store1.Intersect(store2, new ProductComparer());

        foreach (Product product in duplicates)
        {
            Console.WriteLine(product.Name + " " + product.Code);
        }

        /*
            This code produces the following output:
            apple 9
        */
        //</Intersect>

        //<Union>
        Product[] store10 = [
            new("apple",9 ),
            new("orange",4 ) ];

        Product[] store20 = [
            new("apple",9 ),
            new("lemon",12 ) ];

        //Get the products from the both arrays
        //excluding duplicates.

        IEnumerable<Product> union =
          store10.Union(store20, new ProductComparer());

        foreach (Product product in union)
        {
            Console.WriteLine(product.Name + " " + product.Code);
        }

        /*
            This code produces the following output:

            apple 9
            orange 4
            lemon 12
        */
        //</Union>

        //<Distinct>
        Product[] products = [
            new("apple",9 ),
            new("orange",4 ),
            new("apple",9 ),
            new("lemon",12 ) ];

        // Exclude duplicates.

        IEnumerable<Product> noduplicates =
            products.Distinct(new ProductComparer());

        foreach (Product product in noduplicates)
        {
            Console.WriteLine(product.Name + " " + product.Code);
        }

        /*
            This code produces the following output:
            apple 9
            orange 4
            lemon 12
        */
        //</Distinct>

        //<Contains>
        Product[] fruits = [
            new("apple",9 ),
            new("orange",4 ),
            new("lemon",12 ) ];

        Product apple = new("apple", 9);
        Product kiwi = new("kiwi", 8);

        ProductComparer prodc = new();

        var hasApple = fruits.Contains(apple, prodc);
        var hasKiwi = fruits.Contains(kiwi, prodc);

        Console.WriteLine("Apple? " + hasApple);
        Console.WriteLine("Kiwi? " + hasKiwi);

        /*
            This code produces the following output:

            Apple? True
            Kiwi? False
        */

        //</Contains>

        //<Except>
        Product[] fruits1 = [
            new("apple",9 ),
            new("orange",4 ),
            new("lemon",12 ) ];

        Product[] fruits2 = [new("apple", 9)];

        // Get all the elements from the first array
        // except for the elements from the second array.

        IEnumerable<Product> except =
            fruits1.Except(fruits2, new ProductComparer());

        foreach (Product product in except)
        {
            Console.WriteLine(product.Name + " " + product.Code);
        }

        /*
          This code produces the following output:

          orange 4
          lemon 12
        */

        //</Except>

        //<SequenceEqual>

        Product[] storeA = [
            new("apple",9 ),
            new("orange",4 ) ];

        Product[] storeB = [
            new("apple",9 ),
            new("orange",4 ) ];

        var equalAB = storeA.SequenceEqual(storeB, new ProductComparer());

        Console.WriteLine("Equal? " + equalAB);

        /*
            This code produces the following output:

            Equal? True
        */

        //</SequenceEqual>

        _ = Console.ReadLine();
    }
}
