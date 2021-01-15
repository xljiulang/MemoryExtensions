using BenchmarkDotNet.Attributes;
using System.Buffers;
using System.IO;

namespace MemoryExtensions.Benchmarks
{
    [MemoryDiagnoser]
    public class BufferWriterBenchmark : IBenchmark
    {
        [Params(4, 8)]
        public int Fields { get; set; }

        [Params(4, 64, 128)]
        public int FieldSize { get; set; }

        [Benchmark]
        public void RecyclableBufferWriter()
        {
            using var writer = new BufferWriter<byte>(16);
            var filed = new byte[FieldSize];
            for (var i = 0; i < Fields; i++)
            {
                writer.Write(filed);
            }
        }

        [Benchmark]
        public void FixedArrayBufferWriter()
        {
            var writer = new byte[Fields * FieldSize].CreateWriter();
            var filed = new byte[FieldSize];
            for (var i = 0; i < Fields; i++)
            {
                writer.Write(filed);
            }
        }

        [Benchmark]
        public void ArrayBufferWriter()
        {
            var writer = new ArrayBufferWriter<byte>(16);
            var filed = new byte[FieldSize];
            for (var i = 0; i < Fields; i++)
            {
                writer.Write(filed);
            }
        }

        [Benchmark]
        public void MemoryStream()
        {
            using var writer = new MemoryStream();
            var filed = new byte[FieldSize];
            for (var i = 0; i < Fields; i++)
            {
                writer.Write(filed);
            }
        }
    }
}
