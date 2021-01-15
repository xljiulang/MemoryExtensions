using System;
using System.Buffers;

namespace App
{
    class Program
    {
        static void Main(string[] args)
        {
            var array = new byte[16];

            var writer = array.CreateWriter();
            writer.WriteBigEndian(18);
            writer.WriteBigEndian(2.01f);

            var reader = new BufferReader(array);
            reader.ReadBigEndian(out int v1);
            reader.ReadBigEndian(out float v2);

            Console.WriteLine("Hello World!");
        }
    }
}
