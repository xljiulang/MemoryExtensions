``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.18363.1139 (1909/November2018Update/19H2)
Intel Core i3-4150 CPU 3.50GHz (Haswell), 1 CPU, 4 logical and 2 physical cores
.NET Core SDK=5.0.200-preview.20601.7
  [Host]     : .NET Core 5.0.1 (CoreCLR 5.0.120.57516, CoreFX 5.0.120.57516), X64 RyuJIT
  Job-AXDZFP : .NET Core 5.0.1 (CoreCLR 5.0.120.57516, CoreFX 5.0.120.57516), X64 RyuJIT

InvocationCount=1  UnrollFactor=1  

```
|                 Method | WriteCount | WritePerSize |     Mean |     Error |    StdDev |   Median | Gen 0 | Gen 1 | Gen 2 | Allocated |
|----------------------- |----------- |------------- |---------:|----------:|----------:|---------:|------:|------:|------:|----------:|
| **RecyclableBufferWriter** |          **4** |            **4** | **4.033 μs** | **0.5064 μs** | **1.4201 μs** | **3.800 μs** |     **-** |     **-** |     **-** |     **328 B** |
|  ResizableBufferWriter |          4 |            4 | 2.723 μs | 0.2535 μs | 0.7066 μs | 2.500 μs |     - |     - |     - |     136 B |
|     MemoryBufferWriter |          4 |            4 | 2.531 μs | 0.2275 μs | 0.6229 μs | 2.300 μs |     - |     - |     - |      80 B |
| **RecyclableBufferWriter** |          **4** |           **64** | **5.313 μs** | **0.4792 μs** | **1.3037 μs** | **5.100 μs** |     **-** |     **-** |     **-** |     **328 B** |
|  ResizableBufferWriter |          4 |           64 | 2.727 μs | 0.3867 μs | 1.0650 μs | 2.400 μs |     - |     - |     - |     552 B |
|     MemoryBufferWriter |          4 |           64 | 2.457 μs | 0.3075 μs | 0.8723 μs | 2.200 μs |     - |     - |     - |     320 B |
| **RecyclableBufferWriter** |          **4** |          **128** | **5.476 μs** | **0.4493 μs** | **1.2524 μs** | **5.500 μs** |     **-** |     **-** |     **-** |     **328 B** |
|  ResizableBufferWriter |          4 |          128 | 2.745 μs | 0.2691 μs | 0.7456 μs | 2.600 μs |     - |     - |     - |    1000 B |
|     MemoryBufferWriter |          4 |          128 | 2.548 μs | 0.2919 μs | 0.8234 μs | 2.350 μs |     - |     - |     - |     576 B |
| **RecyclableBufferWriter** |          **4** |          **512** | **5.594 μs** | **0.5938 μs** | **1.6354 μs** | **5.750 μs** |     **-** |     **-** |     **-** |     **328 B** |
|  ResizableBufferWriter |          4 |          512 | 3.121 μs | 0.3549 μs | 0.9833 μs | 2.800 μs |     - |     - |     - |    3688 B |
|     MemoryBufferWriter |          4 |          512 | 2.494 μs | 0.2638 μs | 0.7309 μs | 2.200 μs |     - |     - |     - |    2112 B |
| **RecyclableBufferWriter** |          **8** |            **4** | **5.272 μs** | **0.4537 μs** | **1.2421 μs** | **5.500 μs** |     **-** |     **-** |     **-** |     **328 B** |
|  ResizableBufferWriter |          8 |            4 | 2.864 μs | 0.2665 μs | 0.7339 μs | 2.750 μs |     - |     - |     - |     192 B |
|     MemoryBufferWriter |          8 |            4 | 2.911 μs | 0.3855 μs | 1.0873 μs | 2.600 μs |     - |     - |     - |      96 B |
| **RecyclableBufferWriter** |          **8** |           **64** | **5.826 μs** | **0.4714 μs** | **1.2904 μs** | **6.250 μs** |     **-** |     **-** |     **-** |     **328 B** |
|  ResizableBufferWriter |          8 |           64 | 3.099 μs | 0.3733 μs | 1.0343 μs | 2.750 μs |     - |     - |     - |    1088 B |
|     MemoryBufferWriter |          8 |           64 | 2.856 μs | 0.3482 μs | 0.9763 μs | 2.600 μs |     - |     - |     - |     576 B |
| **RecyclableBufferWriter** |          **8** |          **128** | **5.452 μs** | **0.4959 μs** | **1.3408 μs** | **5.800 μs** |     **-** |     **-** |     **-** |     **328 B** |
|  ResizableBufferWriter |          8 |          128 | 2.702 μs | 0.2526 μs | 0.6830 μs | 2.400 μs |     - |     - |     - |    2048 B |
|     MemoryBufferWriter |          8 |          128 | 2.768 μs | 0.3238 μs | 0.9185 μs | 2.300 μs |     - |     - |     - |    1088 B |
| **RecyclableBufferWriter** |          **8** |          **512** | **6.040 μs** | **0.6469 μs** | **1.8032 μs** | **6.050 μs** |     **-** |     **-** |     **-** |     **328 B** |
|  ResizableBufferWriter |          8 |          512 | 4.109 μs | 0.4710 μs | 1.2893 μs | 3.900 μs |     - |     - |     - |    7808 B |
|     MemoryBufferWriter |          8 |          512 | 2.618 μs | 0.2925 μs | 0.8154 μs | 2.300 μs |     - |     - |     - |    4160 B |
| **RecyclableBufferWriter** |         **16** |            **4** | **6.203 μs** | **0.5283 μs** | **1.4461 μs** | **6.500 μs** |     **-** |     **-** |     **-** |     **328 B** |
|  ResizableBufferWriter |         16 |            4 | 3.403 μs | 0.4541 μs | 1.2733 μs | 3.100 μs |     - |     - |     - |     280 B |
|     MemoryBufferWriter |         16 |            4 | 2.837 μs | 0.2969 μs | 0.8178 μs | 2.500 μs |     - |     - |     - |     128 B |
| **RecyclableBufferWriter** |         **16** |           **64** | **6.014 μs** | **0.5736 μs** | **1.5311 μs** | **5.900 μs** |     **-** |     **-** |     **-** |     **328 B** |
|  ResizableBufferWriter |         16 |           64 | 3.692 μs | 0.4849 μs | 1.3757 μs | 3.100 μs |     - |     - |     - |    2136 B |
|     MemoryBufferWriter |         16 |           64 | 3.149 μs | 0.3655 μs | 1.0310 μs | 2.800 μs |     - |     - |     - |    1088 B |
| **RecyclableBufferWriter** |         **16** |          **128** | **6.251 μs** | **0.5624 μs** | **1.5395 μs** | **6.600 μs** |     **-** |     **-** |     **-** |     **328 B** |
|  ResizableBufferWriter |         16 |          128 | 3.226 μs | 0.3098 μs | 0.8532 μs | 3.000 μs |     - |     - |     - |    4120 B |
|     MemoryBufferWriter |         16 |          128 | 3.444 μs | 0.4646 μs | 1.3479 μs | 3.100 μs |     - |     - |     - |    2112 B |
| **RecyclableBufferWriter** |         **16** |          **512** | **7.724 μs** | **0.5955 μs** | **1.6302 μs** | **7.900 μs** |     **-** |     **-** |     **-** |     **328 B** |
|  ResizableBufferWriter |         16 |          512 | 4.117 μs | 0.4940 μs | 1.3934 μs | 3.400 μs |     - |     - |     - |   16024 B |
|     MemoryBufferWriter |         16 |          512 | 2.849 μs | 0.2506 μs | 0.6776 μs | 2.600 μs |     - |     - |     - |    8256 B |
