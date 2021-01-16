``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.18363.1139 (1909/November2018Update/19H2)
Intel Core i3-4150 CPU 3.50GHz (Haswell), 1 CPU, 4 logical and 2 physical cores
.NET Core SDK=5.0.200-preview.20601.7
  [Host]     : .NET Core 5.0.1 (CoreCLR 5.0.120.57516, CoreFX 5.0.120.57516), X64 RyuJIT
  Job-PDTZEK : .NET Core 5.0.1 (CoreCLR 5.0.120.57516, CoreFX 5.0.120.57516), X64 RyuJIT

InvocationCount=1  UnrollFactor=1  

```
|                 Method | WriteCount | WritePerSize |     Mean |     Error |    StdDev |   Median | Gen 0 | Gen 1 | Gen 2 | Allocated |
|----------------------- |----------- |------------- |---------:|----------:|----------:|---------:|------:|------:|------:|----------:|
| **RecyclableBufferWriter** |          **4** |            **4** | **4.983 μs** | **0.5458 μs** | **1.5033 μs** | **5.200 μs** |     **-** |     **-** |     **-** |     **376 B** |
|  ResizableBufferWriter |          4 |            4 | 2.716 μs | 0.2720 μs | 0.7399 μs | 2.600 μs |     - |     - |     - |     136 B |
|      FixedBufferWriter |          4 |            4 | 1.851 μs | 0.1423 μs | 0.3871 μs | 1.700 μs |     - |     - |     - |      72 B |
| **RecyclableBufferWriter** |          **4** |           **64** | **6.710 μs** | **0.5839 μs** | **1.6372 μs** | **7.100 μs** |     **-** |     **-** |     **-** |     **472 B** |
|  ResizableBufferWriter |          4 |           64 | 2.644 μs | 0.2844 μs | 0.7880 μs | 2.400 μs |     - |     - |     - |     552 B |
|      FixedBufferWriter |          4 |           64 | 1.787 μs | 0.1502 μs | 0.4111 μs | 1.700 μs |     - |     - |     - |     312 B |
| **RecyclableBufferWriter** |          **4** |          **128** | **6.109 μs** | **0.5311 μs** | **1.4805 μs** | **6.400 μs** |     **-** |     **-** |     **-** |     **472 B** |
|  ResizableBufferWriter |          4 |          128 | 2.564 μs | 0.1937 μs | 0.5237 μs | 2.400 μs |     - |     - |     - |    1000 B |
|      FixedBufferWriter |          4 |          128 | 1.907 μs | 0.1822 μs | 0.4956 μs | 1.800 μs |     - |     - |     - |     568 B |
| **RecyclableBufferWriter** |          **4** |          **512** | **6.527 μs** | **0.6897 μs** | **1.9566 μs** | **7.000 μs** |     **-** |     **-** |     **-** |     **472 B** |
|  ResizableBufferWriter |          4 |          512 | 2.841 μs | 0.3729 μs | 1.0271 μs | 2.450 μs |     - |     - |     - |    3688 B |
|      FixedBufferWriter |          4 |          512 | 1.927 μs | 0.2479 μs | 0.6910 μs | 1.700 μs |     - |     - |     - |    2104 B |
| **RecyclableBufferWriter** |          **8** |            **4** | **6.177 μs** | **0.5901 μs** | **1.5852 μs** | **6.150 μs** |     **-** |     **-** |     **-** |     **424 B** |
|  ResizableBufferWriter |          8 |            4 | 3.213 μs | 0.3874 μs | 1.0799 μs | 3.100 μs |     - |     - |     - |     192 B |
|      FixedBufferWriter |          8 |            4 | 1.913 μs | 0.1759 μs | 0.4904 μs | 1.800 μs |     - |     - |     - |      88 B |
| **RecyclableBufferWriter** |          **8** |           **64** | **7.011 μs** | **0.6485 μs** | **1.7862 μs** | **7.200 μs** |     **-** |     **-** |     **-** |     **520 B** |
|  ResizableBufferWriter |          8 |           64 | 3.893 μs | 0.4217 μs | 1.1614 μs | 3.850 μs |     - |     - |     - |    1088 B |
|      FixedBufferWriter |          8 |           64 | 2.177 μs | 0.2735 μs | 0.7715 μs | 1.900 μs |     - |     - |     - |     568 B |
| **RecyclableBufferWriter** |          **8** |          **128** | **6.989 μs** | **0.5996 μs** | **1.6813 μs** | **7.100 μs** |     **-** |     **-** |     **-** |     **520 B** |
|  ResizableBufferWriter |          8 |          128 | 3.874 μs | 0.4751 μs | 1.3165 μs | 3.700 μs |     - |     - |     - |    2048 B |
|      FixedBufferWriter |          8 |          128 | 2.129 μs | 0.2976 μs | 0.8441 μs | 1.900 μs |     - |     - |     - |    1080 B |
| **RecyclableBufferWriter** |          **8** |          **512** | **7.498 μs** | **0.6396 μs** | **1.7722 μs** | **7.700 μs** |     **-** |     **-** |     **-** |     **808 B** |
|  ResizableBufferWriter |          8 |          512 | 3.719 μs | 0.5581 μs | 1.5922 μs | 3.200 μs |     - |     - |     - |    7808 B |
|      FixedBufferWriter |          8 |          512 | 2.462 μs | 0.3174 μs | 0.9005 μs | 2.100 μs |     - |     - |     - |    4152 B |
| **RecyclableBufferWriter** |         **16** |            **4** | **7.161 μs** | **0.6138 μs** | **1.7007 μs** | **7.200 μs** |     **-** |     **-** |     **-** |     **472 B** |
|  ResizableBufferWriter |         16 |            4 | 3.322 μs | 0.3696 μs | 1.0302 μs | 3.000 μs |     - |     - |     - |     280 B |
|      FixedBufferWriter |         16 |            4 | 2.536 μs | 0.3006 μs | 0.8480 μs | 2.200 μs |     - |     - |     - |     120 B |
| **RecyclableBufferWriter** |         **16** |           **64** | **7.523 μs** | **0.7133 μs** | **2.0001 μs** | **8.100 μs** |     **-** |     **-** |     **-** |     **568 B** |
|  ResizableBufferWriter |         16 |           64 | 3.530 μs | 0.4483 μs | 1.2498 μs | 3.200 μs |     - |     - |     - |    2136 B |
|      FixedBufferWriter |         16 |           64 | 2.586 μs | 0.3446 μs | 0.9942 μs | 2.150 μs |     - |     - |     - |    1080 B |
| **RecyclableBufferWriter** |         **16** |          **128** | **7.913 μs** | **0.7155 μs** | **1.9827 μs** | **8.000 μs** |     **-** |     **-** |     **-** |     **568 B** |
|  ResizableBufferWriter |         16 |          128 | 2.450 μs | 0.1756 μs | 0.4808 μs | 2.250 μs |     - |     - |     - |    4120 B |
|      FixedBufferWriter |         16 |          128 | 1.770 μs | 0.0861 μs | 0.2312 μs | 1.700 μs |     - |     - |     - |    2104 B |
| **RecyclableBufferWriter** |         **16** |          **512** | **6.510 μs** | **0.9889 μs** | **2.8532 μs** | **4.850 μs** |     **-** |     **-** |     **-** |     **568 B** |
|  ResizableBufferWriter |         16 |          512 | 3.587 μs | 0.2617 μs | 0.7164 μs | 3.250 μs |     - |     - |     - |   16024 B |
|      FixedBufferWriter |         16 |          512 | 2.677 μs | 0.3211 μs | 0.8951 μs | 2.300 μs |     - |     - |     - |    8248 B |
