using System.Buffers.Binary;

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
        public static void WriteUInt64LittleEndian(this IBufferWriter<byte> writer, ulong value)
        {
            var size = sizeof(ulong);
            var span = writer.GetSpan(size);
            BinaryPrimitives.WriteUInt64LittleEndian(span, value);
            writer.Advance(size);
        }
    }
}
