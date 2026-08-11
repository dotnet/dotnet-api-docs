

namespace ToFileTime
{
    class Class1
    {
        //<Snippet1>
        static void Main(string[] args)
        {
            System.Console.WriteLine("Enter the file path:");
            string filePath = System.Console.ReadLine();

            if (System.IO.File.Exists(filePath))
            {
                System.DateTime fileCreationDateTime =
                    System.IO.File.GetCreationTime(filePath);

                long fileCreationFileTime = fileCreationDateTime.ToFileTime();

                System.Console.WriteLine($"{fileCreationDateTime} in file time is {fileCreationFileTime}.");
            }
            else
            {
                System.Console.WriteLine($"{filePath} is an invalid file");
            }
        }
        //</Snippet1>
    }
}
