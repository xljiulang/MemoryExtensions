using BenchmarkDotNet.Attributes;
using System.Buffers;

namespace MemoryExtensions.Benchmarks
{
    [MemoryDiagnoser]
    public class BufferWriterBenchmark : IBenchmark
    {
        private byte[] filedValue;

        [Params(4, 8, 16)]
        public int WriteCount { get; set; }

        [Params(4, 64, 128, 512)]
        public int WritePerSize { get; set; }

        [IterationSetup]
        public void Setup()
        {
            this.filedValue = new byte[this.WritePerSize];
        }

        [Benchmark]
        public void RecyclableBufferWriter()
        {
            using var writer = new RecyclableBufferWriter<byte>(WritePerSize);
            for (var i = 0; i < WriteCount; i++)
            {
                writer.Write(this.filedValue);
            }
        }

        [Benchmark]
        public void ResizableBufferWriter()
        {
            var writer = new ResizableBufferWriter<byte>(WritePerSize);
            for (var i = 0; i < WriteCount; i++)
            {
                writer.Write(this.filedValue);
            }
        }

        [Benchmark]
        public void FixedBufferWriter()
        {
            var writer = new byte[WriteCount * WritePerSize].CreateWriter();
            for (var i = 0; i < WriteCount; i++)
            {
                writer.Write(this.filedValue);
            }
        }
    }
}
