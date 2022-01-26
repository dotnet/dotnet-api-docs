//<snippet1>
using System.IO;

public static class PreallocationSizeExample
{
    public static void Main()
    {
        string destinationPath = "destination.dll";

        var openForReading = new FileStreamOptions { Mode = FileMode.Open };
        using var source = new FileStream(typeof(PreallocationSizeExample).Assembly.Location, openForReading);

        var createForWriting = new FileStreamOptions
        {
            Mode = FileMode.CreateNew,
            Access = FileAccess.Write,
            PreallocationSize = source.Length // specify size up-front
        };
        using var destination = new FileStream(destinationPath, createForWriting);

        source.CopyTo(destination); // copies the contents of the assembly file into the destination file
    }
}
//</snippet1>
