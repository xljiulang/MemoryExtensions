using BenchmarkDotNet.Attributes;
using System;
using System.Buffers;
using System.IO;

namespace MemoryExtensions.Benchmarks
{
    [MemoryDiagnoser]
    public class BufferWriterBenchmark : IBenchmark
    {
        [Params(1, 10, 100)]
        public int Iterations { get; set; }

        [Benchmark]
        public void RecyclableBufferWriter()
        {
            using var writer = new BufferWriter<byte>(24);
            for (var i = 0; i < Iterations; i++)
            {
                writer.WriteLittleEndian(1);
                writer.WriteLittleEndian(2L);
                writer.WriteLittleEndian(3f);
                writer.WriteLittleEndian(4d);
            }
        }

        [Benchmark]
        public void ArrayBufferWriter()
        {
            var writer = new ArrayBufferWriter<byte>(24);
            for (var i = 0; i < Iterations; i++)
            {
                writer.WriteLittleEndian(1);
                writer.WriteLittleEndian(2L);
                writer.WriteLittleEndian(3f);
                writer.WriteLittleEndian(4d);
            }
        }

        [Benchmark]
        public void MemoryStream()
        {
            var writer = new MemoryStream();
            for (var i = 0; i < Iterations; i++)
            {
                writer.Write(BitConverter.GetBytes(1));
                writer.Write(BitConverter.GetBytes(2L));
                writer.Write(BitConverter.GetBytes(3f));
                writer.Write(BitConverter.GetBytes(4d));
            }
        }
    }
}
