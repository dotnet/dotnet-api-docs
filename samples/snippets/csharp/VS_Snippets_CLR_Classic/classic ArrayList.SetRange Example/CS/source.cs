﻿// <Snippet1>
 using System;
 using System.Collections;
 public class SamplesArrayList  {

    public static void Main()  {

       // Creates and initializes a new ArrayList.
       ArrayList myAL = new ArrayList();
       myAL.Add( "The" );
       myAL.Add( "quick" );
       myAL.Add( "brown" );
       myAL.Add( "fox" );
       myAL.Add( "jumps" );
       myAL.Add( "over" );
       myAL.Add( "the" );
       myAL.Add( "lazy" );
       myAL.Add( "dog" );

       // Creates and initializes the source ICollection.
       Queue mySourceList = new Queue();
       mySourceList.Enqueue( "big" );
       mySourceList.Enqueue( "gray" );
       mySourceList.Enqueue( "wolf" );

       // Displays the values of five elements starting at index 0.
       ArrayList mySubAL = myAL.GetRange( 0, 5 );
       Console.WriteLine( "Index 0 through 4 contains:" );
       PrintValues( mySubAL, '\t' );

       // Replaces the values of five elements starting at index 1 with the values in the ICollection.
       myAL.SetRange( 1, mySourceList );

       // Displays the values of five elements starting at index 0.
       mySubAL = myAL.GetRange( 0, 5 );
       Console.WriteLine( "Index 0 through 4 now contains:" );
       PrintValues( mySubAL, '\t' );
    }

    public static void PrintValues( IEnumerable myList, char mySeparator )  {
       foreach ( Object obj in myList )
          Console.Write( "{0}{1}", mySeparator, obj );
       Console.WriteLine();
    }
 }


 /*
 This code produces the following output.

 Index 0 through 4 contains:
         The     quick   brown   fox     jumps
 Index 0 through 4 now contains:
         The     big     gray    wolf    jumps
 */
// </Snippet1>
