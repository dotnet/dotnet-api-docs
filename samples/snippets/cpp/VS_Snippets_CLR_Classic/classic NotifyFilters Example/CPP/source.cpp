#include "pch.h"

using namespace System;
using namespace System::IO;

class MyClassCPP
{
public:

    int static Run()
    {
        FileSystemWatcher^ watcher = gcnew FileSystemWatcher("C:\\path\\to\\folder");

        watcher->NotifyFilter = static_cast<NotifyFilters>(NotifyFilters::Attributes
                                                         | NotifyFilters::CreationTime
                                                         | NotifyFilters::DirectoryName
                                                         | NotifyFilters::FileName
                                                         | NotifyFilters::LastAccess
                                                         | NotifyFilters::LastWrite
                                                         | NotifyFilters::Security
                                                         | NotifyFilters::Size);

        watcher->Changed += gcnew FileSystemEventHandler(MyClassCPP::OnChanged);
        watcher->Created += gcnew FileSystemEventHandler(MyClassCPP::OnCreated);
        watcher->Deleted += gcnew FileSystemEventHandler(MyClassCPP::OnDeleted);
        watcher->Renamed += gcnew RenamedEventHandler(MyClassCPP::OnRenamed);
        watcher->Error   += gcnew ErrorEventHandler(MyClassCPP::OnError);

        watcher->Filter = "*.txt";
        watcher->IncludeSubdirectories = true;
        watcher->EnableRaisingEvents = true;

        Console::WriteLine("Press enter to exit.");
        Console::ReadLine();

        return 0;
    }

private:

    static void OnChanged(Object^ sender, FileSystemEventArgs^ e)
    {
        if (e->ChangeType != WatcherChangeTypes::Changed)
        {
            return;
        }
        Console::WriteLine("Changed: {0}", e->FullPath);
    }

    static void OnCreated(Object^ sender, FileSystemEventArgs^ e)
    {
        Console::WriteLine("Created: {0}", e->FullPath);
    }

    static void OnDeleted(Object^ sender, FileSystemEventArgs^ e)
    {
        Console::WriteLine("Deleted: {0}", e->FullPath);
    }

    static void OnRenamed(Object^ sender, RenamedEventArgs^ e)
    {
        Console::WriteLine("Renamed:");
        Console::WriteLine("    Old: {0}", e->OldFullPath);
        Console::WriteLine("    New: {0}", e->FullPath);
    }

    static void OnError(Object^ sender, ErrorEventArgs^ e)
    {
        PrintException(e->GetException());
    }

    static void PrintException(Exception^ ex)
    {
        if (ex != nullptr)
        {
            Console::WriteLine("Message: {0}", ex->Message);
            Console::WriteLine("Stacktrace:");
            Console::WriteLine(ex->StackTrace);
            Console::WriteLine();
            PrintException(ex->InnerException);
        }
    }
};


int main()
{
    MyClassCPP::Run();
}