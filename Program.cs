// See https://aka.ms/new-console-template for more information

using BenchmarkDotNet.Running;
using StringCoversionBenchmark;

Console.WriteLine("Memory Allocation Demo");

BenchmarkRunner.Run<GuidUtilBenchMarkers>();