> [!NOTE]
> **.NET Framework only:** When you use the asterisk wildcard character in `searchPattern` and you specify a three-character file extension, for example, "\*.txt", this method also returns files with extensions that *begin* with the specified extension. For example, the search pattern "\*.xls" returns both "book.xls" and "book.xlsx". This behavior only occurs if an asterisk is used in the search pattern and the file extension provided is exactly three characters. If you use the question mark wildcard character instead of the asterisk, this method returns only files that match the specified file extension exactly. The following table depicts this anomaly in .NET Framework.
>
> | Files in directory  | Search pattern | .NET 5+ returns   | .NET Framework returns  |
> |---------------------|----------------|-------------------|-------------------------|
> | file.ai, file.aif   | *.ai           | file.ai           | file.ai                 |
> | book.xls, book.xlsx | *.xls          | book.xls          | **book.xls, book.xlsx** |
> | file.ai, file.aif   | ?.ai           | file.ai           | file.ai                 |
> | book.xls, book.xlsx | ?.xls          | book.xls          | book.xls                |
