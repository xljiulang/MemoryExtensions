using System.Buffers.Binary;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace System.Buffers
{
    /// <summary>
    ///  BufferWriter扩展
    /// </summary>
    public static class BufferWriterExtensions
    {
        /// <summary>
        /// 写入int32
        /// </summary>
        /// <param name="writer"></param>
        /// <param name="value"></param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void WriteInt32BigEndian(this IBufferWriter<byte> writer, int value)
        {
            var size = sizeof(int);
            var span = writer.GetSpan(size);
            BinaryPrimitives.WriteInt32BigEndian(span, value);
            writer.Advance(size);
        }

        /// <summary>
        /// 写入int32
        /// </summary>
        /// <param name="writer"></param>
        /// <param name="value"></param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void WriteInt32LittleEndian(this IBufferWriter<byte> writer, int value)
        {
            var size = sizeof(int);
            var span = writer.GetSpan(size);
            BinaryPrimitives.WriteInt32LittleEndian(span, value);
            writer.Advance(size);
        }

        /// <summary>
        /// 写入int16
        /// </summary>
        /// <param name="writer"></param>
        /// <param name="value"></param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void WriteInt16BigEndian(this IBufferWriter<byte> writer, short value)
        {
            var size = sizeof(short);
            var span = writer.GetSpan(size);
            BinaryPrimitives.WriteInt16BigEndian(span, value);
            writer.Advance(size);
        }

        /// <summary>
        /// 写入int16
        /// </summary>
        /// <param name="writer"></param>
        /// <param name="value"></param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void WriteInt16LittleEndian(this IBufferWriter<byte> writer, short value)
        {
            var size = sizeof(short);
            var span = writer.GetSpan(size);
            BinaryPrimitives.WriteInt16LittleEndian(span, value);
            writer.Advance(size);
        }

        /// <summary>
        /// 写入int64
        /// </summary>
        /// <param name="writer"></param>
        /// <param name="value"></param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void WriteInt64BigEndian(this IBufferWriter<byte> writer, long value)
        {
            var size = sizeof(long);
            var span = writer.GetSpan(size);
            BinaryPrimitives.WriteInt64BigEndian(span, value);
            writer.Advance(size);
        }

        /// <summary>
        /// 写入int64
        /// </summary>
        /// <param name="writer"></param>
        /// <param name="value"></param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void WriteInt64LittleEndian(this IBufferWriter<byte> writer, long value)
        {
            var size = sizeof(long);
            var span = writer.GetSpan(size);
            BinaryPrimitives.WriteInt64LittleEndian(span, value);
            writer.Advance(size);
        }



        /// <summary>
        /// 写入uint32
        /// </summary>
        /// <param name="writer"></param>
        /// <param name="value"></param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void WriteUInt32BigEndian(this IBufferWriter<byte> writer, uint value)
        {
            var size = sizeof(uint);
            var span = writer.GetSpan(size);
            BinaryPrimitives.WriteUInt32BigEndian(span, value);
            writer.Advance(size);
        }

        /// <summary>
        /// 写入uint32
        /// </summary>
        /// <param name="writer"></param>
        /// <param name="value"></param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void WriteUInt32LittleEndian(this IBufferWriter<byte> writer, uint value)
        {
            var size = sizeof(uint);
            var span = writer.GetSpan(size);
            BinaryPrimitives.WriteUInt32LittleEndian(span, value);
            writer.Advance(size);
        }

        /// <summary>
        /// 写入uint16
        /// </summary>
        /// <param name="writer"></param>
        /// <param name="value"></param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void WriteUInt16BigEndian(this IBufferWriter<byte> writer, ushort value)
        {
            var size = sizeof(ushort);
            var span = writer.GetSpan(size);
            BinaryPrimitives.WriteUInt16BigEndian(span, value);
            writer.Advance(size);
        }

        /// <summary>
        /// 写入uint16
        /// </summary>
        /// <param name="writer"></param>
        /// <param name="value"></param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void WriteUInt16LittleEndian(this IBufferWriter<byte> writer, ushort value)
        {
            var size = sizeof(ushort);
            var span = writer.GetSpan(size);
            BinaryPrimitives.WriteUInt16LittleEndian(span, value);
            writer.Advance(size);
        }

        /// <summary>
        /// 写入uint64
        /// </summary>
        /// <param name="writer"></param>
        /// <param name="value"></param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void WriteUInt64BigEndian(this IBufferWriter<byte> writer, ulong value)
        {
            var size = sizeof(ulong);
            var span = writer.GetSpan(size);
            BinaryPrimitives.WriteUInt64BigEndian(span, value);
            writer.Advance(size);
        }

        /// <summary>
        /// 写入uint64
        /// </summary>
        /// <param name="writer"></param>
        /// <param name="value"></param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void WriteUInt64LittleEndian(this IBufferWriter<byte> writer, ulong value)
        {
            var size = sizeof(ulong);
            var span = writer.GetSpan(size);
            BinaryPrimitives.WriteUInt64LittleEndian(span, value);
            writer.Advance(size);
        }

        /// <summary>
        /// 写入double
        /// </summary>
        /// <param name="writer"></param>
        /// <param name="value"></param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void WriteDoubleLittleEndian(this IBufferWriter<byte> writer, double value)
        {
            var size = sizeof(long);
            var span = writer.GetSpan(size);

            if (BitConverter.IsLittleEndian == false)
            {
                var tmp = BinaryPrimitives.ReverseEndianness(BitConverter.DoubleToInt64Bits(value));
                MemoryMarshal.Write(span, ref tmp);
            }
            else
            {
                MemoryMarshal.Write(span, ref value);
            }

            writer.Advance(size);
        }

        /// <summary>
        /// 写入double
        /// </summary>
        /// <param name="writer"></param>
        /// <param name="value"></param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void WriteDoubleBigEndian(this IBufferWriter<byte> writer, double value)
        {
            var size = sizeof(long);
            var span = writer.GetSpan(size);

            if (BitConverter.IsLittleEndian)
            {
                var tmp = BinaryPrimitives.ReverseEndianness(BitConverter.DoubleToInt64Bits(value));
                MemoryMarshal.Write(span, ref tmp);
            }
            else
            {
                MemoryMarshal.Write(span, ref value);
            }

            writer.Advance(size);
        }


        /// <summary>
        /// 写入float
        /// </summary>
        /// <param name="writer"></param>
        /// <param name="value"></param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        unsafe public static void WriteSingleLittleEndian(this IBufferWriter<byte> writer, float value)
        {
            var size = sizeof(int);
            var span = writer.GetSpan(size);

            if (BitConverter.IsLittleEndian == false)
            {
                var tmp = BinaryPrimitives.ReverseEndianness(SingleToInt32Bits(value));
                MemoryMarshal.Write(span, ref tmp);
            }
            else
            {
                MemoryMarshal.Write(span, ref value);
            }

            writer.Advance(size);
        }

        /// <summary>
        /// 写入float
        /// </summary>
        /// <param name="writer"></param>
        /// <param name="value"></param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        unsafe public static void WriteSingleBigEndian(this IBufferWriter<byte> writer, float value)
        {
            var size = sizeof(int);
            var span = writer.GetSpan(size);

            if (BitConverter.IsLittleEndian)
            {
                var tmp = BinaryPrimitives.ReverseEndianness(SingleToInt32Bits(value));
                MemoryMarshal.Write(span, ref tmp);
            }
            else
            {
                MemoryMarshal.Write(span, ref value);
            }

            writer.Advance(size);
        }

        unsafe private static int SingleToInt32Bits(float value)
        {
            return *(int*)(&value);
        }
    }
}
