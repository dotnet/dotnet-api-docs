
//<snippet1>
// This example demonstrates the Console.WindowLeft and
//                               Console.WindowTop properties.
using namespace System;
using namespace System::Text;
using namespace System::IO;

//
int saveBufferWidth;
int saveBufferHeight;
int saveWindowHeight;
int saveWindowWidth;
bool saveCursorVisible;

//
int main()
{
   String^ m1 = "1) Press the cursor keys to move the console window.\n"
   "2) Press any key to begin. When you're finished...\n"
   "3) Press the Escape key to quit.";
   String^ g1 = "+----";
   String^ g2 = "|    ";
   String^ grid1;
   String^ grid2;
   StringBuilder^ sbG1 = gcnew StringBuilder;
   StringBuilder^ sbG2 = gcnew StringBuilder;
   ConsoleKeyInfo cki;
   int y;
   
   //
   try
   {
      saveBufferWidth = Console::BufferWidth;
      saveBufferHeight = Console::BufferHeight;
      saveWindowHeight = Console::WindowHeight;
      saveWindowWidth = Console::WindowWidth;
      saveCursorVisible = Console::CursorVisible;
      
      //
      Console::Clear();
      Console::WriteLine( m1 );
      Console::ReadKey( true );
      
      // Set the smallest possible window size before setting the buffer size.
      Console::SetWindowSize( 1, 1 );
      Console::SetBufferSize( 80, 80 );
      Console::SetWindowSize( 40, 20 );
      
      // Create grid lines to fit the buffer. (The buffer width is 80, but
      // this same technique could be used with an arbitrary buffer width.)
      for ( y = 0; y < Console::BufferWidth / g1->Length; y++ )
      {
         sbG1->Append( g1 );
         sbG2->Append( g2 );

      }
      sbG1->Append( g1, 0, Console::BufferWidth % g1->Length );
      sbG2->Append( g2, 0, Console::BufferWidth % g2->Length );
      grid1 = sbG1->ToString();
      grid2 = sbG2->ToString();
      Console::CursorVisible = false;
      Console::Clear();
      for ( y = 0; y < Console::BufferHeight - 1; y++ )
      {
         if ( y % 3 == 0 )
                  Console::Write( grid1 );
         else
                  Console::Write( grid2 );

      }
      Console::SetWindowPosition( 0, 0 );
      do
      {
         cki = Console::ReadKey( true );
         switch ( cki.Key )
         {
            case ConsoleKey::LeftArrow:
               if ( Console::WindowLeft > 0 )
                              Console::SetWindowPosition( Console::WindowLeft - 1, Console::WindowTop );
               break;

            case ConsoleKey::UpArrow:
               if ( Console::WindowTop > 0 )
                              Console::SetWindowPosition( Console::WindowLeft, Console::WindowTop - 1 );
               break;

            case ConsoleKey::RightArrow:
               if ( Console::WindowLeft < (Console::BufferWidth - Console::WindowWidth) )
                              Console::SetWindowPosition( Console::WindowLeft + 1, Console::WindowTop );
               break;

            case ConsoleKey::DownArrow:
               if ( Console::WindowTop < (Console::BufferHeight - Console::WindowHeight) )
                              Console::SetWindowPosition( Console::WindowLeft, Console::WindowTop + 1 );
               break;
         }
      }
      while ( cki.Key != ConsoleKey::Escape );
   }
   catch ( IOException^ e ) 
   {
      Console::WriteLine( e->Message );
   }
   finally
   {
      Console::Clear();
      Console::SetWindowSize( 1, 1 );
      Console::SetBufferSize( saveBufferWidth, saveBufferHeight );
      Console::SetWindowSize( saveWindowWidth, saveWindowHeight );
      Console::CursorVisible = saveCursorVisible;
   }

} // end Main


/*
This example produces results similar to the following:

1) Press the cursor keys to move the console window.
2) Press any key to begin. When you're finished...
3) Press the Escape key to quit.

...

+----+----+----+-
|    |    |    |
|    |    |    |
+----+----+----+-
|    |    |    |
|    |    |    |
+----+----+----+-

*/
//</snippet1>
