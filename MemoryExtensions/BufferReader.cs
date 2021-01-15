using System.Buffers.Binary;
using System.Diagnostics;

namespace System.Buffers
{
    /// <summary>
    /// 表示Buffter读取器
    /// </summary>
    [DebuggerDisplay("Length = {Length}")]
    public ref struct BufferReader
    {
        /// <summary>
        /// 未读取的数据
        /// </summary>
        private ReadOnlySpan<byte> span;

        /// <summary>
        /// 获取可读数据长度
        /// </summary>
        public int Length => this.span.Length;

        /// <summary>
        /// Buffter读取器
        /// </summary>
        /// <param name="span"></param>
        public BufferReader(ReadOnlySpan<byte> span)
        {
            this.span = span;
        }

        /// <summary>
        /// 读取指定长度
        /// </summary>
        /// <param name="count"></param>
        /// <returns></returns>
        public ReadOnlySpan<byte> Read(int count)
        {
            var value = this.span.Slice(0, count);
            this.span = this.span.Slice(count);
            return value;
        }

        /// <summary>
        /// 读取int32
        /// </summary>
        /// <param name="value"></param>
        public void ReadBigEndian(out int value)
        {
            value = BinaryPrimitives.ReadInt32BigEndian(this.span);
            this.span = this.span.Slice(sizeof(int));
        }

        /// <summary>
        /// 读取int32
        /// </summary>
        /// <param name="value"></param>
        public void ReadLittleEndian(out int value)
        {
            value = BinaryPrimitives.ReadInt32LittleEndian(this.span);
            this.span = this.span.Slice(sizeof(int));
        }

        /// <summary>
        /// 读取int16
        /// </summary>
        /// <param name="value"></param>
        public void ReadBigEndian(out short value)
        {
            value = BinaryPrimitives.ReadInt16BigEndian(this.span);
            this.span = this.span.Slice(sizeof(short));
        }

        /// <summary>
        /// 读取int16
        /// </summary>
        /// <param name="value"></param>
        public void ReadLittleEndian(out short value)
        {
            value = BinaryPrimitives.ReadInt16LittleEndian(this.span);
            this.span = this.span.Slice(sizeof(short));
        }

        /// <summary>
        /// 读取int64
        /// </summary>
        /// <param name="value"></param>
        public void ReadBigEndian(out long value)
        {
            value = BinaryPrimitives.ReadInt64BigEndian(this.span);
            this.span = this.span.Slice(sizeof(long));
        }

        /// <summary>
        /// 读取int64
        /// </summary>
        /// <param name="value"></param>
        public void ReadLittleEndian(out long value)
        {
            value = BinaryPrimitives.ReadInt64LittleEndian(this.span);
            this.span = this.span.Slice(sizeof(long));
        }


        /// <summary>
        /// 读取uint32
        /// </summary>
        /// <param name="value"></param>
        public void ReadBigEndian(out uint value)
        {
            value = BinaryPrimitives.ReadUInt32BigEndian(this.span);
            this.span = this.span.Slice(sizeof(uint));
        }

        /// <summary>
        /// 读取uint32
        /// </summary>
        /// <param name="value"></param>
        public void ReadLittleEndian(out uint value)
        {
            value = BinaryPrimitives.ReadUInt32LittleEndian(this.span);
            this.span = this.span.Slice(sizeof(uint));
        }


        /// <summary>
        /// 读取uint16
        /// </summary>
        /// <param name="value"></param>
        public void ReadBigEndian(out ushort value)
        {
            value = BinaryPrimitives.ReadUInt16BigEndian(this.span);
            this.span = this.span.Slice(sizeof(ushort));
        }


        /// <summary>
        /// 读取uint16
        /// </summary>
        /// <param name="value"></param>
        public void ReadLittleEndian(out ushort value)
        {
            value = BinaryPrimitives.ReadUInt16LittleEndian(this.span);
            this.span = this.span.Slice(sizeof(ushort));
        }

        /// <summary>
        /// 读取uint64
        /// </summary>
        /// <param name="value"></param>
        public void ReadBigEndian(out ulong value)
        {
            value = BinaryPrimitives.ReadUInt64BigEndian(this.span);
            this.span = this.span.Slice(sizeof(ulong));
        }

        /// <summary>
        /// 读取uint64
        /// </summary>
        /// <param name="value"></param>
        public void ReadLittleEndian(out ulong value)
        {
            value = BinaryPrimitives.ReadUInt64LittleEndian(this.span);
            this.span = this.span.Slice(sizeof(ulong));
        }

        /// <summary>
        /// 读取double
        /// </summary>
        /// <param name="value"></param>
        public void ReadLittleEndian(out double value)
        {
            value = BinaryPrimitiveEx.ReadDoubleLittleEndian(this.span);
            this.span = this.span.Slice(sizeof(long));
        }

        /// <summary>
        /// 读取double
        /// </summary>
        /// <param name="value"></param>
        public void ReadBigEndian(out double value)
        {
            value = BinaryPrimitiveEx.ReadDoubleBigEndian(this.span);
            this.span = this.span.Slice(sizeof(long));
        }

        /// <summary>
        /// 读取float
        /// </summary>
        /// <param name="value"></param>
        public void ReadLittleEndian(out float value)
        {
            value = BinaryPrimitiveEx.ReadSingleLittleEndian(this.span);
            this.span = this.span.Slice(sizeof(int));
        }


        /// <summary>
        /// 读取float
        /// </summary>
        /// <param name="value"></param>
        public void ReadBigEndian(out float value)
        {
            value = BinaryPrimitiveEx.ReadSingleBigEndian(this.span);
            this.span = this.span.Slice(sizeof(int));
        }
    }
}
