The value returned by this property represents the most recently refreshed affinity of the process. To get the most up to date affinity, you need to call <xref:System.Diagnostics.Process.Refresh> method first.

In Windows 2000 and later, a thread in a process can migrate from processor to processor, with each migration reloading the processor cache. Under heavy system loads, specifying which processor should run a specific thread can improve performance by reducing the number of times the processor cache is reloaded. The association between a processor and a thread is called the processor affinity.

Each processor is represented as a bit. Bit 0 is processor one, bit 1 is processor two, and so forth. If you set a bit to the value 1, the corresponding processor is selected for thread assignment. When you set the <xref:System.Diagnostics.Process.ProcessorAffinity%2A> value to zero, the operating system's scheduling algorithms set the thread's affinity. When the <xref:System.Diagnostics.Process.ProcessorAffinity%2A> value is set to any nonzero value, the value is interpreted as a bitmask that specifies those processors eligible for selection.

The following table shows a selection of <xref:System.Diagnostics.Process.ProcessorAffinity%2A> values for an eight-processor system.

|Bitmask|Binary value|Eligible processors|
|-------------|------------------|-------------------------|
|0x0001|00000000 00000001|1|
|0x0003|00000000 00000011|1 and 2|
|0x0007|00000000 00000111|1, 2 and 3|
|0x0009|00000000 00001001|1 and 4|
|0x007F|00000000 01111111|1, 2, 3, 4, 5, 6 and 7|
