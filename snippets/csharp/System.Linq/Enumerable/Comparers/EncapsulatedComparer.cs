using System;
using System.Collections.Generic;
using System.Linq;

namespace Comparers;

//<Snippet1>
public class MyProduct(string name, int code) : IEquatable<MyProduct>
{
    public string Name { get; set; } = name;
    public int Code { get; set; } = code;

    public bool Equals(MyProduct? other)
    {
        //Check whether the compared object is null.
        if (other is null) return false;

        //Check whether the compared object references the same data.
        if (ReferenceEquals(this, other)) return true;

        //Check whether the products' properties are equal.
        return Code.Equals(other.Code) && Name.Equals(other.Name);
    }

    // If Equals() returns true for a pair of objects
    // then GetHashCode() must return the same value for these objects.

    public override int GetHashCode()
    {
        //Get hash code for the Name field
        var hashProductName = Name.GetHashCode();

        //Get hash code for the Code field
        var hashProductCode = Code.GetHashCode();

        //Calculate the hash code for the product.
        return hashProductName ^ hashProductCode;
    }

    public override bool Equals(object? obj) => Equals(obj as MyProduct);
}
//</Snippet1>

static class Program1
{
    static void Main()
    {
        // This snippet is different than #2 by using ProductA (not Product).
        // Some samples here need to use ProductA in conjunction with
        // ProductComparer, which implements IEqualityComparer (not IEquatable).
        //<Snippet10>
        ProductA[] store1 = [
            new ("apple", 9 ),
            new ("orange", 4 ) ];

        ProductA[] store2 = [
            new ("apple", 9 ),
            new ("lemon", 12 ) ];
        //</Snippet10>

        //<Intersect>
        // Get the products from the first array
        // that have duplicates in the second array.

        IEnumerable<ProductA> duplicates =
            store1.Intersect(store2);

        foreach (ProductA product in duplicates)
        {
            Console.WriteLine(product.Name + " " + product.Code);
        }

        /*
            This code produces the following output:
            apple 9
        */
        //</Intersect>

        //<Union>
        //Get the products from the both arrays
        //excluding duplicates.

        IEnumerable<ProductA> union =
            store1.Union(store2);

        foreach (ProductA product in union)
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
        MyProduct[] products = [
            new ("apple", 9 ),
            new ("orange", 4 ),
            new ("apple", 9 ),
            new ("lemon", 12 ) ];

        // Exclude duplicates.

        IEnumerable<MyProduct> noduplicates =
            products.Distinct();

        foreach (MyProduct product in noduplicates)
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

        //<Except>
        ProductA[] fruits1 = [
            new ("apple", 9 ),
            new ("orange", 4 ),
            new ("lemon", 12 ) ];

        ProductA[] fruits2 = [new("apple", 9)];

        // Get all the elements from the first array
        // except for the elements from the second array.

        IEnumerable<ProductA> except =
            fruits1.Except(fruits2);

        foreach (ProductA product in except)
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

        ProductA[] storeA = [
            new ("apple", 9 ),
            new ("orange", 4 ) ];

        ProductA[] storeB = [
            new ("apple", 9 ),
            new ("orange", 4 ) ];

        var equalAB = storeA.SequenceEqual(storeB);

        Console.WriteLine("Equal? " + equalAB);

        /*
            This code produces the following output:

            Equal? True
        */
        //</SequenceEqual>
        Console.ReadLine();
    }

    //<Snippet9>
    public class ProductA(string name, int code) : IEquatable<ProductA>
    {
        public string Name { get; set; } = name;
        public int Code { get; set; } = code;

        public bool Equals(ProductA? other) =>
            other is not null &&
            Name == other.Name &&
            Code == other.Code;

        public override bool Equals(object? obj) => Equals(obj as ProductA);
        public override int GetHashCode() => (Name, Code).GetHashCode();
    }
    //</Snippet9>
}
