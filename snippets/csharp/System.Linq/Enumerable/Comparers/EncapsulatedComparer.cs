using System;
using System.Collections.Generic;
using System.Linq;

//<Snippet1>
public class MyProduct : IEquatable<MyProduct>
{
    public string Name { get; set; }
    public int Code { get; set; }

    public bool Equals(MyProduct other)
    {
        //Check whether the compared object is null.
        if (Object.ReferenceEquals(other, null)) return false;

        //Check whether the compared object references the same data.
        if (Object.ReferenceEquals(this, other)) return true;

        //Check whether the products' properties are equal.
        return Code.Equals(other.Code) && Name.Equals(other.Name);
    }

    // If Equals() returns true for a pair of objects
    // then GetHashCode() must return the same value for these objects.

    public override int GetHashCode()
    {

        //Get hash code for the Name field if it is not null.
        int hashProductName = Name == null ? 0 : Name.GetHashCode();

        //Get hash code for the Code field.
        int hashProductCode = Code.GetHashCode();

        //Calculate the hash code for the product.
        return hashProductName ^ hashProductCode;
    }
}
//</Snippet1>

class Program1
{
    static void Main(string[] args)
    {
        // This snippet is different than #2 by using ProductA (not Product).
        // Some samples here need to use ProductA in conjunction with
        // ProductComparer, which implements IEqualityComparer (not IEquatable).
        //<Snippet10>
        ProductA[] store1 = { new ProductA { Name = "apple", Code = 9 },
                               new ProductA { Name = "orange", Code = 4 } };

        ProductA[] store2 = { new ProductA { Name = "apple", Code = 9 },
                               new ProductA { Name = "lemon", Code = 12 } };
        //</Snippet10>

        //<Intersect>
        // Get the products from the first array
        // that have duplicates in the second array.

        IEnumerable<ProductA> duplicates =
            store1.Intersect(store2);

        foreach (var product in duplicates)
            Console.WriteLine(product.Name + " " + product.Code);

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

        foreach (var product in union)
            Console.WriteLine(product.Name + " " + product.Code);

        /*
            This code produces the following output:

            apple 9
            orange 4
            lemon 12
        */
        //</Union>

        //<Distinct>
        MyProduct[] products = { new MyProduct { Name = "apple", Code = 9 },
                               new MyProduct { Name = "orange", Code = 4 },
                               new MyProduct { Name = "apple", Code = 9 },
                               new MyProduct { Name = "lemon", Code = 12 } };

        // Exclude duplicates.

        IEnumerable<MyProduct> noduplicates =
            products.Distinct();

        foreach (var product in noduplicates)
            Console.WriteLine(product.Name + " " + product.Code);

        /*
            This code produces the following output:
            apple 9
            orange 4
            lemon 12
        */
        //</Distinct>

        //<Except>
        ProductA[] fruits1 = { new ProductA { Name = "apple", Code = 9 },
                               new ProductA { Name = "orange", Code = 4 },
                                new ProductA { Name = "lemon", Code = 12 } };

        ProductA[] fruits2 = { new ProductA { Name = "apple", Code = 9 } };

        // Get all the elements from the first array
        // except for the elements from the second array.

        IEnumerable<ProductA> except =
            fruits1.Except(fruits2);

        foreach (var product in except)
            Console.WriteLine(product.Name + " " + product.Code);

        /*
          This code produces the following output:

          orange 4
          lemon 12
        */
        //</Except>

        //<SequenceEqual>

        ProductA[] storeA = { new ProductA { Name = "apple", Code = 9 },
                               new ProductA { Name = "orange", Code = 4 } };

        ProductA[] storeB = { new ProductA { Name = "apple", Code = 9 },
                               new ProductA { Name = "orange", Code = 4 } };

        bool equalAB = storeA.SequenceEqual(storeB);

        Console.WriteLine("Equal? " + equalAB);

        /*
            This code produces the following output:

            Equal? True
        */
        //</SequenceEqual>
        Console.ReadLine();
    }

    //<Snippet9>
    public class ProductA : IEquatable<ProductA>
    {
        public string Name { get; set; }
        public int Code { get; set; }

        public bool Equals(ProductA other)
        {
            if (other is null)
                return false;

            return this.Name == other.Name && this.Code == other.Code;
        }

        public override bool Equals(object obj) => Equals(obj as ProductA);
        public override int GetHashCode() => (Name, Code).GetHashCode();
    }
    //</Snippet9>
}
