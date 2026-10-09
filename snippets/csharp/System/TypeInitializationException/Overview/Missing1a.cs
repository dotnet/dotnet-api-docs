// <Snippet1>
using System;

public class InfoModule
{
    private DateTime firstUse;
    private int ctr = 0;

    public InfoModule(DateTime dat) => firstUse = dat;

    public int Increment() => ++ctr;

    public DateTime GetInitializationTime() => firstUse;
}
// </Snippet1>
