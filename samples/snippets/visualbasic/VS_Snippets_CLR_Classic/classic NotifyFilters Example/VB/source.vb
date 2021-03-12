' <Snippet1>
Imports System.IO

Namespace MyNamespace

    Class MyClassVB

        Shared Sub Main()
            Using watcher = New FileSystemWatcher("C:\path\to\folder")
                watcher.NotifyFilter = NotifyFilters.Attributes Or
                                       NotifyFilters.CreationTime Or
                                       NotifyFilters.DirectoryName Or
                                       NotifyFilters.FileName Or
                                       NotifyFilters.LastAccess Or
                                       NotifyFilters.LastWrite Or
                                       NotifyFilters.Security Or
                                       NotifyFilters.Size

                AddHandler watcher.Changed, AddressOf OnChanged
                AddHandler watcher.Created, AddressOf OnCreated
                AddHandler watcher.Deleted, AddressOf OnDeleted
                AddHandler watcher.Renamed, AddressOf OnRenamed
                AddHandler watcher.Error, AddressOf OnError

                watcher.Filter = "*.txt"
                watcher.IncludeSubdirectories = True
                watcher.EnableRaisingEvents = True

                Console.WriteLine("Press enter to exit.")
                Console.ReadLine()
            End Using
        End Sub

        Private Shared Sub OnChanged(sender As Object, e As FileSystemEventArgs)
            If e.ChangeType <> WatcherChangeTypes.Changed Then
                Return
            End If
            Console.WriteLine($"Changed: {e.FullPath}")
        End Sub

        Private Shared Sub OnCreated(sender As Object, e As FileSystemEventArgs)
            Dim value As String = $"Created: {e.FullPath}"
            Console.WriteLine(value)
        End Sub

        Private Shared Sub OnDeleted(sender As Object, e As FileSystemEventArgs)
            Console.WriteLine($"Deleted: {e.FullPath}")
        End Sub

        Private Shared Sub OnRenamed(sender As Object, e As RenamedEventArgs)
            Console.WriteLine($"Renamed:")
            Console.WriteLine($"    Old: {e.OldFullPath}")
            Console.WriteLine($"    New: {e.FullPath}")
        End Sub

        Private Shared Sub OnError(sender As Object, e As ErrorEventArgs)
            PrintException(e.GetException())
        End Sub

        Private Shared Sub PrintException(ex As Exception)
            If ex IsNot Nothing Then
                Console.WriteLine($"Message: {ex.Message}")
                Console.WriteLine("Stacktrace:")
                Console.WriteLine(ex.StackTrace)
                Console.WriteLine()
                PrintException(ex.InnerException)
            End If
        End Sub

    End Class

End Namespace
' </Snippet1>