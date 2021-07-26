using System;
using System.Collections;

public class ShortStringDictionary : DictionaryBase  {

   public string this[ string key ]  {
      get  {
         return( (string) Dictionary[key] );
      }
      set  {
         Dictionary[key] = value;
      }
   }

   public ICollection Keys  {
      get  {
         return( Dictionary.Keys );
      }
   }

   public ICollection Values  {
      get  {
         return( Dictionary.Values );
      }
   }

   public void Add( string key, string value )  {
      Dictionary.Add( key, value );
   }

   public bool Contains( string key )  {
      return( Dictionary.Contains( key ) );
   }

   public void Remove( string key )  {
      Dictionary.Remove( key );
   }

   protected override void OnInsert( Object key, Object value )  {
      if ( key.GetType() != typeof(System.String) )
        {
            throw new ArgumentException( "key must be of type string.", "key" );
        }
        else  {
         string strKey = (string) key;
         if ( strKey.Length > 5 )
            throw new ArgumentException( "key must be no more than 5 characters in length.", "key" );
      }

      if ( value.GetType() != typeof(System.String) )
        {
            throw new ArgumentException( "value must be of type string.", "value" );
        }
        else  {
         string strValue = (string) value;
         if ( strValue.Length > 5 )
            throw new ArgumentException( "value must be no more than 5 characters in length.", "value" );
      }
   }

   protected override void OnRemove( Object key, Object value )  {
      if ( key.GetType() != typeof(System.String) )
        {
            throw new ArgumentException( "key must be of type string.", "key" );
        }
        else  {
         string strKey = (string) key;
         if ( strKey.Length > 5 )
            throw new ArgumentException( "key must be no more than 5 characters in length.", "key" );
      }
   }

   protected override void OnSet( Object key, Object oldValue, Object newValue )  {
      if ( key.GetType() != typeof(System.String) )
        {
            throw new ArgumentException( "key must be of type string.", "key" );
        }
        else  {
         string strKey = (string) key;
         if ( strKey.Length > 5 )
            throw new ArgumentException( "key must be no more than 5 characters in length.", "key" );
      }

      if ( newValue.GetType() != typeof(System.String) )
        {
            throw new ArgumentException( "newValue must be of type string.", "newValue" );
        }
        else  {
         string strValue = (string) newValue;
         if ( strValue.Length > 5 )
            throw new ArgumentException( "newValue must be no more than 5 characters in length.", "newValue" );
      }
   }

   protected override void OnValidate( Object key, Object value )  {
      if ( key.GetType() != typeof(System.String) )
        {
            throw new ArgumentException( "key must be of type string.", "key" );
        }
        else  {
         string strKey = (string) key;
         if ( strKey.Length > 5 )
            throw new ArgumentException( "key must be no more than 5 characters in length.", "key" );
      }

      if ( value.GetType() != typeof(System.String) )
        {
            throw new ArgumentException( "value must be of type string.", "value" );
        }
        else  {
         string strValue = (string) value;
         if ( strValue.Length > 5 )
            throw new ArgumentException( "value must be no more than 5 characters in length.", "value" );
      }
   }
}

public class SamplesDictionaryBase
{
    public static void Main()
    {
        DictionaryBase myDictionary = new ShortStringDictionary();

        // <Snippet2>
        foreach (DictionaryEntry de in myDictionary)
        {
            //...
        }
        // </Snippet2>

        // <Snippet3>
        ICollection myCollection = new ShortStringDictionary();
        lock(myCollection.SyncRoot)
        {
            foreach (Object item in myCollection)
            {
                // Insert your code here.
            }
        }
        // </Snippet3>
    }
}
