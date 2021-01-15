using System.Buffers.Binary;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace System.Buffers
{
    /// <summary>
    /// BinaryPrimitive扩展
    /// </summary>
    static class BinaryPrimitiveEx
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double ReadDoubleBigEndian(ReadOnlySpan<byte> source)
        {
            return BitConverter.IsLittleEndian ?
                BitConverter.Int64BitsToDouble(BinaryPrimitives.ReverseEndianness(MemoryMarshal.Read<long>(source))) :
                MemoryMarshal.Read<double>(source);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double ReadDoubleLittleEndian(ReadOnlySpan<byte> source)
        {
            return !BitConverter.IsLittleEndian ?
                BitConverter.Int64BitsToDouble(BinaryPrimitives.ReverseEndianness(MemoryMarshal.Read<long>(source))) :
                MemoryMarshal.Read<double>(source);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float ReadSingleBigEndian(ReadOnlySpan<byte> source)
        {
            return BitConverter.IsLittleEndian ?
                Int32BitsToSingle(BinaryPrimitives.ReverseEndianness(MemoryMarshal.Read<int>(source))) :
                MemoryMarshal.Read<float>(source);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float ReadSingleLittleEndian(ReadOnlySpan<byte> source)
        {
            return !BitConverter.IsLittleEndian ?
                Int32BitsToSingle(BinaryPrimitives.ReverseEndianness(MemoryMarshal.Read<int>(source))) :
                MemoryMarshal.Read<float>(source);
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void WriteDoubleBigEndian(Span<byte> destination, double value)
        {
            if (BitConverter.IsLittleEndian)
            {
                long tmp = BinaryPrimitives.ReverseEndianness(BitConverter.DoubleToInt64Bits(value));
                MemoryMarshal.Write(destination, ref tmp);
            }
            else
            {
                MemoryMarshal.Write(destination, ref value);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void WriteDoubleLittleEndian(Span<byte> destination, double value)
        {
            if (!BitConverter.IsLittleEndian)
            {
                long tmp = BinaryPrimitives.ReverseEndianness(BitConverter.DoubleToInt64Bits(value));
                MemoryMarshal.Write(destination, ref tmp);
            }
            else
            {
                MemoryMarshal.Write(destination, ref value);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void WriteSingleBigEndian(Span<byte> destination, float value)
        {
            if (BitConverter.IsLittleEndian)
            {
                int tmp = BinaryPrimitives.ReverseEndianness(SingleToInt32Bits(value));
                MemoryMarshal.Write(destination, ref tmp);
            }
            else
            {
                MemoryMarshal.Write(destination, ref value);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void WriteSingleLittleEndian(Span<byte> destination, float value)
        {
            if (!BitConverter.IsLittleEndian)
            {
                int tmp = BinaryPrimitives.ReverseEndianness(SingleToInt32Bits(value));
                MemoryMarshal.Write(destination, ref tmp);
            }
            else
            {
                MemoryMarshal.Write(destination, ref value);
            }
        }

        unsafe private static float Int32BitsToSingle(int value)
        {
            return *(float*)(&value);
        }

        unsafe private static int SingleToInt32Bits(float value)
        {
            return *(int*)(&value);
        }
    }
}
