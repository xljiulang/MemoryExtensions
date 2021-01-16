using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace System.Buffers
{
    /// <summary>
    /// 提供固定大小的BufferWriter的创建扩展
    /// </summary>
    public static class FixedBufferWriterExtensions
    {
        /// <summary>
        /// 创建固定大小的BufferWriter
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="array"></param>
        /// <returns></returns>
        public static IWrittenBufferWriter<T> CreateWriter<T>(this T[] array)
        {
            return new FixedBufferWriter<T>(array);
        }

        /// <summary>
        /// 创建固定大小的BufferWriter
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="arraySegment"></param>
        /// <returns></returns>
        public static IWrittenBufferWriter<T> CreateWriter<T>(this ArraySegment<T> arraySegment)
        {
            return new FixedBufferWriter<T>(arraySegment);
        }

        /// <summary>
        /// 获取BufferWriter
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="memory"></param>
        /// <exception cref="NotSupportedException"></exception>
        /// <returns></returns>
        public static IWrittenBufferWriter<T> CreateWriter<T>(this Memory<T> memory)
        {
            return MemoryMarshal.TryGetArray<T>(memory, out var arraySegment)
                ? new FixedBufferWriter<T>(arraySegment)
                : throw new NotSupportedException();
        }

        /// <summary>
        /// 表示固定大小的BufferWriter
        /// </summary>
        /// <typeparam name="T"></typeparam>
        [DebuggerDisplay("WrittenCount = {index}")]
        private struct FixedBufferWriter<T> : IWrittenBufferWriter<T>
        {
            private int index;
            private readonly T[] buffer;
            private readonly int length;

            /// <summary>
            /// 获取已数入的数据长度
            /// </summary>
            public int WrittenCount => this.index;

            /// <summary>
            /// 获取已数入的数据
            /// </summary>
            public ReadOnlySpan<T> WrittenSpan => this.buffer.AsSpan(0, index);

            /// <summary>
            /// 获取已数入的数据
            /// </summary>
            public ReadOnlyMemory<T> WrittenMemory => this.buffer.AsMemory(0, index);

            /// <summary>
            /// 获取已数入的数据
            /// </summary>
            /// <returns></returns>
            public ArraySegment<T> WrittenSegment => new ArraySegment<T>(this.buffer, 0, this.index);

            public FixedBufferWriter(T[] buffer)
            {
                this.index = 0;
                this.buffer = buffer;
                this.length = buffer.Length;
            }

            public FixedBufferWriter(ArraySegment<T> arraySegment)
            {
                this.index = arraySegment.Offset;
                this.buffer = arraySegment.Array;
                this.length = arraySegment.Count;
            }

            public void Advance(int count)
            {
                this.index += count;
            }

            public Memory<T> GetMemory(int sizeHint = 0)
            {
                var size = this.GetSize(sizeHint);
                return new Memory<T>(this.buffer, this.index, size);
            }

            public Span<T> GetSpan(int sizeHint = 0)
            {
                var size = this.GetSize(sizeHint);
                return new Span<T>(this.buffer, this.index, size);
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            private int GetSize(int sizeHint)
            {
                var free = this.length - this.index;
                if (sizeHint <= 0)
                {
                    return free;
                }

                if (sizeHint > free)
                {
                    throw new ArgumentOutOfRangeException(nameof(sizeHint));
                }
                return sizeHint;
            }
        }
    }
}
