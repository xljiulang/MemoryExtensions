using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Diagnosers;
using System.Buffers;

namespace MemoryExtensions.Benchmarks
{
    [MemoryDiagnoser]
    public class ArrayPoolBenchmark : IBenchmark
    {
        [Params(24, 1024, 1024 * 10)]
        public int Size { get; set; }

        [Benchmark]
        public void ArrayPool_Rent()
        {
            using var owner = ArrayPool.Rent<byte>(Size);
        }

        [Benchmark]
        public void NewArray()
        {
            _ = new byte[Size];
        }

    }
}
