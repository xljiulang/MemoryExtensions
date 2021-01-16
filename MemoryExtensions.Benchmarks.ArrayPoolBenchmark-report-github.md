``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.18363.1139 (1909/November2018Update/19H2)
Intel Core i3-4150 CPU 3.50GHz (Haswell), 1 CPU, 4 logical and 2 physical cores
.NET Core SDK=5.0.200-preview.20601.7
  [Host]     : .NET Core 5.0.1 (CoreCLR 5.0.120.57516, CoreFX 5.0.120.57516), X64 RyuJIT
  DefaultJob : .NET Core 5.0.1 (CoreCLR 5.0.120.57516, CoreFX 5.0.120.57516), X64 RyuJIT


```
|         Method |  Size |       Mean |      Error |     StdDev |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------- |------ |-----------:|-----------:|-----------:|-------:|------:|------:|----------:|
| **ArrayPool_Rent** |    **24** |  **95.548 ns** |  **1.6399 ns** |  **1.4537 ns** | **0.0305** |     **-** |     **-** |      **48 B** |
|       NewArray |    24 |   5.636 ns |  0.0534 ns |  0.0500 ns | 0.0306 |     - |     - |      48 B |
| **ArrayPool_Rent** |  **1024** |  **97.943 ns** |  **1.8682 ns** |  **1.8349 ns** | **0.0305** |     **-** |     **-** |      **48 B** |
|       NewArray |  1024 |  78.738 ns |  0.9079 ns |  1.1482 ns | 0.6679 |     - |     - |    1048 B |
| **ArrayPool_Rent** | **10240** |  **96.475 ns** |  **1.9195 ns** |  **2.0538 ns** | **0.0305** |     **-** |     **-** |      **48 B** |
|       NewArray | 10240 | 747.738 ns | 13.3017 ns | 23.6437 ns | 6.5355 |     - |     - |   10264 B |
