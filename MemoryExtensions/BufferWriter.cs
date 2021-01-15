using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace System.Buffers
{
    /// <summary>
    /// 表示字节缓冲区写入对象
    /// </summary>
    [DebuggerDisplay("WrittenCount = {index}")]
    public sealed class BufferWriter<T> : Recyclable, IBufferWriter<T>
    {
        private int index = 0;
        private IArrayOwner<T> buffer;
        private const int defaultSizeHint = 256;

        /// <summary>
        /// 获取已写入的字节数
        /// </summary>
        public int WrittenCount => this.index;

        /// <summary>
        /// 获取容量
        /// </summary>
        public int Capacity => this.buffer.Array.Length;

        /// <summary>
        /// 获取剩余容量
        /// </summary>
        public int FreeCapacity => this.buffer.Array.Length - this.index;


        /// <summary>
        /// 字节缓冲区写入对象
        /// </summary>
        /// <param name="initialCapacity">初始容量</param>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public BufferWriter(int initialCapacity)
        {
            if (initialCapacity <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(initialCapacity));
            }
            this.buffer = ArrayPool.Rent<T>(initialCapacity);
        }

        /// <summary>
        /// 清除数据
        /// </summary>
        public void Clear()
        {
            this.buffer.Array.AsSpan(0, this.index).Clear();
            this.index = 0;
        }

        /// <summary>
        /// 设置向前推进
        /// </summary>
        /// <param name="count"></param>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public void Advance(int count)
        {
            if (count < 0 || this.index > this.buffer.Array.Length - count)
            {
                throw new ArgumentOutOfRangeException(nameof(count));
            }

            this.index += count;
        }

        /// <summary>
        /// 返回用于写入数据的Memory
        /// </summary>
        /// <param name="sizeHint">意图大小</param>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        /// <returns></returns>
        public Memory<T> GetMemory(int sizeHint = 0)
        {
            this.CheckAndResizeBuffer(sizeHint);
            return this.buffer.Array.AsMemory(this.index);
        }

        /// <summary>
        /// 返回用于写入数据的Span
        /// </summary>
        /// <param name="sizeHint">意图大小</param>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        /// <returns></returns>
        public Span<T> GetSpan(int sizeHint = 0)
        {
            this.CheckAndResizeBuffer(sizeHint);
            return buffer.Array.AsSpan(this.index);
        }

        /// <summary>
        /// 写入数据
        /// </summary>
        /// <param name="value"></param>
        public void Write(T value)
        {
            this.GetSpan(1)[0] = value;
            this.index += 1;
        }

        /// <summary>
        /// 写入数据
        /// </summary>
        /// <param name="value">值</param> 
        public void Write(ReadOnlySpan<T> value)
        {
            if (value.IsEmpty == false)
            {
                value.CopyTo(this.GetSpan(value.Length));
                this.index += value.Length;
            }
        }

        /// <summary>
        /// 获取已数入的数据
        /// </summary>
        /// <returns></returns>
        public ArraySegment<T> GetWrittenSegment()
        {
            return new ArraySegment<T>(this.buffer.Array, 0, this.index);
        }

        /// <summary>
        /// 获取已数入的数据
        /// </summary>
        public ReadOnlySpan<T> GetWrittenSpan()
        {
            return this.buffer.Array.AsSpan(0, this.index);
        }

        /// <summary>
        /// 获取已数入的数据
        /// </summary>
        public ReadOnlyMemory<T> GetWrittenMemory()
        {
            return this.buffer.Array.AsMemory(0, this.index);
        }

        /// <summary>
        /// 释放资源
        /// </summary>
        /// <param name="disposing"></param>
        protected sealed override void Dispose(bool disposing)
        {
            this.buffer?.Dispose();
        }

        /// <summary>
        /// 检测和扩容
        /// </summary>
        /// <param name="sizeHint"></param>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private void CheckAndResizeBuffer(int sizeHint)
        {
            if (sizeHint < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(sizeHint));
            }

            if (sizeHint == 0)
            {
                sizeHint = defaultSizeHint;
            }

            if (sizeHint > this.FreeCapacity)
            {
                int currentLength = this.buffer.Array.Length;
                var growBy = Math.Max(sizeHint, currentLength);
                var newSize = checked(currentLength + growBy);

                var newBuffer = ArrayPool.Rent<T>(newSize);
                Array.Copy(this.buffer.Array, newBuffer.Array, this.index);

                this.buffer.Dispose();
                this.buffer = newBuffer;
            }
        }
    }
}