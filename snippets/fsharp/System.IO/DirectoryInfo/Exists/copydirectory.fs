// <snippet1>
open System.IO

// Copy a source directory to a target directory.
let rec copyDirectory sourceDirectory targetDirectory =
    let source = DirectoryInfo sourceDirectory
    let target = DirectoryInfo targetDirectory
    
    //Determine whether the source directory exists.
    if source.Exists then
        if target.Exists then
            target.Create()
        
        //Copy files.
        let sourceFiles = source.GetFiles()
        for file in sourceFiles do
            File.Copy(file.FullName, target.FullName + "\\" + file.Name,true)
        
        //Copy directories.
        let sourceDirectories = source.GetDirectories()
        for dir in sourceDirectories do
            copyDirectory dir.FullName (target.FullName + "\\" + dir.Name)

copyDirectory "D:\\Tools" "D:\\NewTools"
// </snippet1>