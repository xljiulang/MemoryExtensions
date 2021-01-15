``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.18363.1139 (1909/November2018Update/19H2)
Intel Core i3-4150 CPU 3.50GHz (Haswell), 1 CPU, 4 logical and 2 physical cores
.NET Core SDK=5.0.200-preview.20601.7
  [Host]     : .NET Core 5.0.1 (CoreCLR 5.0.120.57516, CoreFX 5.0.120.57516), X64 RyuJIT
  DefaultJob : .NET Core 5.0.1 (CoreCLR 5.0.120.57516, CoreFX 5.0.120.57516), X64 RyuJIT


```
|                 Method | Fields | FieldSize |        Mean |     Error |     StdDev |    Median |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|----------------------- |------- |---------- |------------:|----------:|-----------:|----------:|-------:|------:|------:|----------:|
| **RecyclableBufferWriter** |      **4** |         **4** |   **245.31 ns** |  **4.874 ns** |   **4.560 ns** | **244.62 ns** | **0.0763** |     **-** |     **-** |     **120 B** |
|      FixedBufferWriter |      4 |         4 |    61.00 ns |  1.249 ns |   1.487 ns |  60.67 ns | 0.0663 |     - |     - |     104 B |
|  ResizableBufferWriter |      4 |         4 |    58.01 ns |  1.444 ns |   4.167 ns |  56.70 ns | 0.0663 |     - |     - |     104 B |
|           MemoryStream |      4 |         4 |    99.00 ns |  1.885 ns |   1.935 ns |  98.67 ns | 0.2396 |     - |     - |     376 B |
| **RecyclableBufferWriter** |      **4** |        **64** |   **466.88 ns** |  **9.075 ns** |   **9.711 ns** | **469.31 ns** | **0.1731** |     **-** |     **-** |     **272 B** |
|      FixedBufferWriter |      4 |        64 |    86.09 ns |  1.718 ns |   2.463 ns |  85.07 ns | 0.2550 |     - |     - |     400 B |
|  ResizableBufferWriter |      4 |        64 |   154.05 ns |  2.268 ns |   3.395 ns | 154.15 ns | 0.5047 |     - |     - |     792 B |
|           MemoryStream |      4 |        64 |    98.67 ns |  1.724 ns |   1.771 ns |  98.15 ns | 0.2754 |     - |     - |     432 B |
| **RecyclableBufferWriter** |      **4** |       **128** |   **505.38 ns** | **10.649 ns** |  **28.790 ns** | **495.86 ns** | **0.2141** |     **-** |     **-** |     **336 B** |
|      FixedBufferWriter |      4 |       128 |   123.73 ns |  2.510 ns |   4.955 ns | 123.69 ns | 0.4590 |     - |     - |     720 B |
|  ResizableBufferWriter |      4 |       128 |   219.92 ns |  5.378 ns |  14.992 ns | 216.37 ns | 0.8311 |     - |     - |    1304 B |
|           MemoryStream |      4 |       128 |   189.06 ns |  3.804 ns |   8.024 ns | 187.32 ns | 0.6578 |     - |     - |    1032 B |
| **RecyclableBufferWriter** |      **8** |         **4** |   **396.39 ns** |  **5.220 ns** |   **4.883 ns** | **394.86 ns** | **0.1068** |     **-** |     **-** |     **168 B** |
|      FixedBufferWriter |      8 |         4 |   108.32 ns |  1.245 ns |   1.164 ns | 108.21 ns | 0.0764 |     - |     - |     120 B |
|  ResizableBufferWriter |      8 |         4 |   100.46 ns |  0.956 ns |   0.894 ns | 100.09 ns | 0.1019 |     - |     - |     160 B |
|           MemoryStream |      8 |         4 |   144.99 ns |  2.935 ns |   3.605 ns | 143.38 ns | 0.2396 |     - |     - |     376 B |
| **RecyclableBufferWriter** |      **8** |        **64** |   **947.73 ns** | **95.217 ns** | **280.750 ns** | **874.34 ns** | **0.2031** |     **-** |     **-** |     **320 B** |
|      FixedBufferWriter |      8 |        64 |   174.22 ns |  5.386 ns |  15.711 ns | 169.83 ns | 0.4182 |     - |     - |     656 B |
|  ResizableBufferWriter |      8 |        64 |   377.12 ns | 14.077 ns |  41.285 ns | 361.71 ns | 0.9279 |     - |     - |    1456 B |
|           MemoryStream |      8 |        64 |   336.04 ns | 19.640 ns |  57.909 ns | 320.42 ns | 0.6170 |     - |     - |     968 B |
| **RecyclableBufferWriter** |      **8** |       **128** | **1,001.16 ns** | **74.756 ns** | **218.066 ns** | **894.71 ns** | **0.2441** |     **-** |     **-** |     **384 B** |
|      FixedBufferWriter |      8 |       128 |   283.67 ns |  6.457 ns |  18.319 ns | 278.58 ns | 0.7854 |     - |     - |    1232 B |
|  ResizableBufferWriter |      8 |       128 |   492.11 ns |  9.846 ns |  23.208 ns | 484.31 ns | 1.5802 |     - |     - |    2480 B |
|           MemoryStream |      8 |       128 |   447.83 ns |  6.086 ns |   5.082 ns | 449.03 ns | 1.3261 |     - |     - |    2080 B |
