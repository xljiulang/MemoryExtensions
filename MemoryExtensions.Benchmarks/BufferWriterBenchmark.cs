using BenchmarkDotNet.Attributes;
using System;
using System.Buffers;
using System.IO;

namespace MemoryExtensions.Benchmarks
{
    [MemoryDiagnoser]
    public class BufferWriterBenchmark : IBenchmark
    {
        [Params(4, 8, 16)]
        public int Fields { get; set; }

        [Benchmark]
        public void RecyclableBufferWriter()
        {
            using var writer = new BufferWriter<byte>(24);
            for (var i = 0; i < Fields; i++)
            {
                writer.WriteLittleEndian(1);
            }
        }

        [Benchmark]
        public void ArrayBufferWriter()
        {
            var writer = new ArrayBufferWriter<byte>(24);
            for (var i = 0; i < Fields; i++)
            {
                writer.WriteLittleEndian(1);
            }
        }

        [Benchmark]
        public void MemoryStream()
        {
            using var writer = new MemoryStream();
            for (var i = 0; i < Fields; i++)
            {
                writer.Write(BitConverter.GetBytes(1));
            }
        }
    }
}
