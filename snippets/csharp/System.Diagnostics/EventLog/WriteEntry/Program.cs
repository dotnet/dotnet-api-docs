using System.Diagnostics;

bool sourceExists = EventLog.SourceExists("MySource");
MySample.Run();
if (!sourceExists)
{
    return;
}

MyEventLog.Run();
EventLog_WriteEntry_4.Run();
EventLog_WriteEntry_5.Run();
MySample1.Run();
MySample2.Run();
