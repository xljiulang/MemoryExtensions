using System.Buffers.Binary;

namespace System.Buffers
{
    /// <summary>
    /// 表示Buffter读取器
    /// </summary>
    public ref struct BufferReader
    {
        /// <summary>
        /// 获取未读取的数据
        /// </summary>
        public ReadOnlySpan<byte> Span { get; private set; }

        /// <summary>
        /// Buffter读取器
        /// </summary>
        /// <param name="span"></param>
        public BufferReader(ReadOnlySpan<byte> span)
        {
            this.Span = span;
        }

        /// <summary>
        /// 读取指定长度
        /// </summary>
        /// <param name="count"></param>
        /// <returns></returns>
        public ReadOnlySpan<byte> Read(int count)
        {
            var value = this.Span.Slice(0, count);
            this.Span = this.Span.Slice(count);
            return value;
        }

        /// <summary>
        /// 读取int32
        /// </summary>
        /// <returns></returns>
        public int ReadInt32BigEndian()
        {
            var value = BinaryPrimitives.ReadInt32BigEndian(this.Span);
            this.Span = this.Span.Slice(sizeof(int));
            return value;
        }

        /// <summary>
        /// 读取int32
        /// </summary>
        /// <returns></returns>
        public int ReadInt32LittleEndian()
        {
            var value = BinaryPrimitives.ReadInt32LittleEndian(this.Span);
            this.Span = this.Span.Slice(sizeof(int));
            return value;
        }


        /// <summary>
        /// 读取int16
        /// </summary>
        /// <returns></returns>
        public short ReadInt16BigEndian()
        {
            var value = BinaryPrimitives.ReadInt16BigEndian(this.Span);
            this.Span = this.Span.Slice(sizeof(short));
            return value;
        }

        /// <summary>
        /// 读取int16
        /// </summary>
        /// <returns></returns>
        public short ReadInt16LittleEndian()
        {
            var value = BinaryPrimitives.ReadInt16LittleEndian(this.Span);
            this.Span = this.Span.Slice(sizeof(short));
            return value;
        }

        /// <summary>
        /// 读取int64
        /// </summary>
        /// <returns></returns>
        public long ReadInt64BigEndian()
        {
            var value = BinaryPrimitives.ReadInt64BigEndian(this.Span);
            this.Span = this.Span.Slice(sizeof(long));
            return value;
        }

        /// <summary>
        /// 读取int64
        /// </summary>
        /// <returns></returns>
        public long ReadInt64LittleEndian()
        {
            var value = BinaryPrimitives.ReadInt64LittleEndian(this.Span);
            this.Span = this.Span.Slice(sizeof(long));
            return value;
        }



        /// <summary>
        /// 读取uint32
        /// </summary>
        /// <returns></returns>
        public uint ReadUInt32BigEndian()
        {
            var value = BinaryPrimitives.ReadUInt32BigEndian(this.Span);
            this.Span = this.Span.Slice(sizeof(uint));
            return value;
        }

        /// <summary>
        /// 读取uint32
        /// </summary>
        /// <returns></returns>
        public uint ReadUInt32LittleEndian()
        {
            var value = BinaryPrimitives.ReadUInt32LittleEndian(this.Span);
            this.Span = this.Span.Slice(sizeof(uint));
            return value;
        }


        /// <summary>
        /// 读取uint16
        /// </summary>
        /// <returns></returns>
        public ushort ReadUInt16BigEndian()
        {
            var value = BinaryPrimitives.ReadUInt16BigEndian(this.Span);
            this.Span = this.Span.Slice(sizeof(ushort));
            return value;
        }

        /// <summary>
        /// 读取uint16
        /// </summary>
        /// <returns></returns>
        public ushort ReadUInt16LittleEndian()
        {
            var value = BinaryPrimitives.ReadUInt16LittleEndian(this.Span);
            this.Span = this.Span.Slice(sizeof(ushort));
            return value;
        }

        /// <summary>
        /// 读取uint64
        /// </summary>
        /// <returns></returns>
        public ulong ReadUInt64BigEndian()
        {
            var value = BinaryPrimitives.ReadUInt64BigEndian(this.Span);
            this.Span = this.Span.Slice(sizeof(ulong));
            return value;
        }

        /// <summary>
        /// 读取uint64
        /// </summary>
        /// <returns></returns>
        public ulong ReadUInt64LittleEndian()
        {
            var value = BinaryPrimitives.ReadUInt64LittleEndian(this.Span);
            this.Span = this.Span.Slice(sizeof(ulong));
            return value;
        }

        /// <summary>
        /// 读取double
        /// </summary> 
        public double ReadDoubleLittleEndian()
        {
            var value = BinaryPrimitiveEx.ReadDoubleLittleEndian(this.Span);
            this.Span = this.Span.Slice(sizeof(long));
            return value;
        }

        /// <summary>
        /// 读取double
        /// </summary> 
        public double ReadDoubleBigEndian()
        {
            var value = BinaryPrimitiveEx.ReadDoubleBigEndian(this.Span);
            this.Span = this.Span.Slice(sizeof(long));
            return value;
        }

        /// <summary>
        /// 读取float
        /// </summary>
        /// <returns></returns>
        public float ReadSingleLittleEndian()
        {
            var value = BinaryPrimitiveEx.ReadSingleLittleEndian(this.Span);
            this.Span = this.Span.Slice(sizeof(int));
            return value;
        }

        /// <summary>
        /// 读取float
        /// </summary> 
        public float ReadSingleBigEndian()
        {
            var value = BinaryPrimitiveEx.ReadSingleBigEndian(this.Span);
            this.Span = this.Span.Slice(sizeof(int));
            return value;
        }
    }
}
