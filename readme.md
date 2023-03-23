``` ini

BenchmarkDotNet=v0.13.5, OS=Windows 10 (10.0.19045.2728/22H2/2022Update)
Intel Core i7-7700 CPU 3.60GHz (Kaby Lake), 1 CPU, 8 logical and 4 physical cores
.NET SDK=7.0.201
  [Host]     : .NET 6.0.14 (6.0.1423.7309), X64 RyuJIT AVX2 [AttachedDebugger]
  DefaultJob : .NET 6.0.14 (6.0.1423.7309), X64 RyuJIT AVX2


```
|                    Method |      Mean |    Error |   StdDev | Allocated |
|-------------------------- |----------:|---------:|---------:|----------:|
|          ToStringFromGuid | 118.11 ns | 3.088 ns | 9.055 ns |     184 B |
| ToStringFromGuidOptimized |  42.40 ns | 0.886 ns | 0.870 ns |      72 B |
|          ToGuidFromString |  91.96 ns | 1.861 ns | 1.991 ns |     112 B |
| ToGuidFromStringOptimized |  54.96 ns | 1.132 ns | 1.829 ns |         - |
