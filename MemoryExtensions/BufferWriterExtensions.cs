using System.Buffers.Binary;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;

namespace System.Buffers
{
    /// <summary>
    ///  BufferWriter扩展
    /// </summary>
    public static class BufferWriterExtensions
    {
        /// <summary>
        /// 写入字符串
        /// </summary>
        /// <param name="writer"></param>
        /// <param name="text">字体串</param>
        /// <param name="encoding">编码</param>
        /// <returns>写入的字节数</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public unsafe static int Write(this IBufferWriter<byte> writer, ReadOnlySpan<char> text, Encoding encoding)
        {
            if (text.IsEmpty)
            {
                return 0;
            }

            var chars = (char*)Unsafe.AsPointer(ref MemoryMarshal.GetReference(text));
            var byteCount = encoding.GetByteCount(chars, text.Length);

            var span = writer.GetSpan(byteCount);
            var bytes = (byte*)Unsafe.AsPointer(ref span[0]);
            var len = encoding.GetEncoder().GetBytes(chars, text.Length, bytes, byteCount, flush: true);
            writer.Advance(len);
            return len;
        }

        /// <summary>
        /// 写入int32
        /// </summary>
        /// <param name="writer"></param>
        /// <param name="value"></param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void WriteBigEndian(this IBufferWriter<byte> writer, int value)
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
        public static void WriteLittleEndian(this IBufferWriter<byte> writer, int value)
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
        public static void WriteBigEndian(this IBufferWriter<byte> writer, short value)
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
        public static void WriteLittleEndian(this IBufferWriter<byte> writer, short value)
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
        public static void WriteBigEndian(this IBufferWriter<byte> writer, long value)
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
        public static void WriteLittleEndian(this IBufferWriter<byte> writer, long value)
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
        public static void WriteBigEndian(this IBufferWriter<byte> writer, uint value)
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
        public static void WriteLittleEndian(this IBufferWriter<byte> writer, uint value)
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
        public static void WriteBigEndian(this IBufferWriter<byte> writer, ushort value)
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
        public static void WriteLittleEndian(this IBufferWriter<byte> writer, ushort value)
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
        public static void WriteBigEndian(this IBufferWriter<byte> writer, ulong value)
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
        public static void WriteLittleEndian(this IBufferWriter<byte> writer, ulong value)
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
        public static void WriteLittleEndian(this IBufferWriter<byte> writer, double value)
        {
            var size = sizeof(long);
            var span = writer.GetSpan(size);
            BinaryPrimitiveEx.WriteDoubleLittleEndian(span, value);
            writer.Advance(size);
        }

        /// <summary>
        /// 写入double
        /// </summary>
        /// <param name="writer"></param>
        /// <param name="value"></param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void WriteBigEndian(this IBufferWriter<byte> writer, double value)
        {
            var size = sizeof(long);
            var span = writer.GetSpan(size);
            BinaryPrimitiveEx.WriteDoubleBigEndian(span, value);
            writer.Advance(size);
        }


        /// <summary>
        /// 写入float
        /// </summary>
        /// <param name="writer"></param>
        /// <param name="value"></param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void WriteLittleEndian(this IBufferWriter<byte> writer, float value)
        {
            var size = sizeof(int);
            var span = writer.GetSpan(size);
            BinaryPrimitiveEx.WriteSingleLittleEndian(span, value);
            writer.Advance(size);
        }

        /// <summary>
        /// 写入float
        /// </summary>
        /// <param name="writer"></param>
        /// <param name="value"></param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void WriteBigEndian(this IBufferWriter<byte> writer, float value)
        {
            var size = sizeof(int);
            var span = writer.GetSpan(size);
            BinaryPrimitiveEx.WriteSingleBigEndian(span, value);
            writer.Advance(size);
        }
    }
}
