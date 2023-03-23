|                    Method |      Mean |    Error |   StdDev | Allocated |
|-------------------------- |----------:|---------:|---------:|----------:|
|          ToStringFromGuid | 118.11 ns | 3.088 ns | 9.055 ns |     184 B |
| ToStringFromGuidOptimized |  42.40 ns | 0.886 ns | 0.870 ns |      72 B |
|          ToGuidFromString |  91.96 ns | 1.861 ns | 1.991 ns |     112 B |
| ToGuidFromStringOptimized |  54.96 ns | 1.132 ns | 1.829 ns |         - |
