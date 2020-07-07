﻿// <Snippet1>
 using System;
 using System.Collections;
 public class SamplesArrayList  {

    public static void Main()  {

       // Creates and initializes the source ArrayList.
       ArrayList mySourceList = new ArrayList();
       mySourceList.Add( "three" );
       mySourceList.Add( "napping" );
       mySourceList.Add( "cats" );
       mySourceList.Add( "in" );
       mySourceList.Add( "the" );
       mySourceList.Add( "barn" );

       // Creates and initializes the one-dimensional target Array.
       String[] myTargetArray = new String[15];
       myTargetArray[0] = "The";
       myTargetArray[1] = "quick";
       myTargetArray[2] = "brown";
       myTargetArray[3] = "fox";
       myTargetArray[4] = "jumps";
       myTargetArray[5] = "over";
       myTargetArray[6] = "the";
       myTargetArray[7] = "lazy";
       myTargetArray[8] = "dog";

       // Displays the values of the target Array.
       Console.WriteLine( "The target Array contains the following (before and after copying):" );
       PrintValues( myTargetArray, ' ' );

       // Copies the second element from the source ArrayList to the target Array, starting at index 7.
       mySourceList.CopyTo( 1, myTargetArray, 7, 1 );

       // Displays the values of the target Array.
       PrintValues( myTargetArray, ' ' );

       // Copies the entire source ArrayList to the target Array, starting at index 6.
       mySourceList.CopyTo( myTargetArray, 6 );

       // Displays the values of the target Array.
       PrintValues( myTargetArray, ' ' );

       // Copies the entire source ArrayList to the target Array, starting at index 0.
       mySourceList.CopyTo( myTargetArray );

       // Displays the values of the target Array.
       PrintValues( myTargetArray, ' ' );
    }

    public static void PrintValues( String[] myArr, char mySeparator )  {
       for ( int i = 0; i < myArr.Length; i++ )
          Console.Write( "{0}{1}", mySeparator, myArr[i] );
       Console.WriteLine();
    }
 }


 /*
 This code produces the following output.

 The target Array contains the following (before and after copying):
  The quick brown fox jumps over the lazy dog
  The quick brown fox jumps over the napping dog
  The quick brown fox jumps over three napping cats in the barn
  three napping cats in the barn three napping cats in the barn

 */
// </Snippet1>
