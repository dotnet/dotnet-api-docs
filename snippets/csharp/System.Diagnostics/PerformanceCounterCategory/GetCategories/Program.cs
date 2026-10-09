PerfCounterCatGetCountMod.Run(args);
PerfCounterCatGetInstMod.Run(args);
string[] machineArgs = args.Length > 1 ? [args[1]] : [];
PerfCounterCatGetCatMod.Run(machineArgs);
