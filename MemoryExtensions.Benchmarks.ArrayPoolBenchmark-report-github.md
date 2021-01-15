``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.18363.1139 (1909/November2018Update/19H2)
Intel Core i3-4150 CPU 3.50GHz (Haswell), 1 CPU, 4 logical and 2 physical cores
.NET Core SDK=5.0.200-preview.20601.7
  [Host]     : .NET Core 5.0.1 (CoreCLR 5.0.120.57516, CoreFX 5.0.120.57516), X64 RyuJIT
  DefaultJob : .NET Core 5.0.1 (CoreCLR 5.0.120.57516, CoreFX 5.0.120.57516), X64 RyuJIT


```
|         Method |  Size |       Mean |     Error |    StdDev |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------- |------ |-----------:|----------:|----------:|-------:|------:|------:|----------:|
| **ArrayPool_Rent** |    **24** |  **94.958 ns** | **1.9169 ns** | **3.6471 ns** | **0.0305** |     **-** |     **-** |      **48 B** |
|       NewArray |    24 |   5.761 ns | 0.0995 ns | 0.0931 ns | 0.0306 |     - |     - |      48 B |
| **ArrayPool_Rent** |  **1024** | **100.033 ns** | **1.2935 ns** | **1.2100 ns** | **0.0305** |     **-** |     **-** |      **48 B** |
|       NewArray |  1024 |  80.067 ns | 1.3077 ns | 1.0920 ns | 0.6679 |     - |     - |    1048 B |
| **ArrayPool_Rent** | **10240** |  **93.603 ns** | **1.3983 ns** | **1.3080 ns** | **0.0305** |     **-** |     **-** |      **48 B** |
|       NewArray | 10240 | 747.504 ns | 8.5662 ns | 7.5938 ns | 6.5355 |     - |     - |   10264 B |
