using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace System.Buffers
{
    /// <summary>
    ///  BufferWriter的创建扩展
    /// </summary>
    public static class BufferWriterCreationExtensions
    {
        /// <summary>
        /// 创建BufferWriter
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="array"></param>
        /// <returns></returns>
        public static IBufferWriter<T> CreateWriter<T>(this T[] array)
        {
            return new ArrayBufferWriter<T>(array);
        }

        /// <summary>
        /// 获取BufferWriter
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="arraySegment"></param>
        /// <returns></returns>
        public static IBufferWriter<T> CreateWriter<T>(this ArraySegment<T> arraySegment)
        {
            return new ArrayBufferWriter<T>(arraySegment);
        }

        /// <summary>
        /// 获取BufferWriter
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="memory"></param>
        /// <exception cref="NotSupportedException"></exception>
        /// <returns></returns>
        public static IBufferWriter<T> CreateWriter<T>(this Memory<T> memory)
        {
            return MemoryMarshal.TryGetArray<T>(memory, out var arraySegment)
                ? new ArrayBufferWriter<T>(arraySegment)
                : throw new NotSupportedException();
        }

        /// <summary>
        /// 数组缓冲区的BufferWriter
        /// </summary>
        /// <typeparam name="T"></typeparam>
        private struct ArrayBufferWriter<T> : IBufferWriter<T>
        {
            private int position;
            private readonly T[] array;
            private readonly int length;

            public ArrayBufferWriter(T[] array)
            {
                this.position = 0;
                this.array = array;
                this.length = array.Length;
            }

            public ArrayBufferWriter(ArraySegment<T> arraySegment)
            {
                this.position = arraySegment.Offset;
                this.array = arraySegment.Array;
                this.length = arraySegment.Count;
            }

            public void Advance(int count)
            {
                this.position += count;
            }

            public Memory<T> GetMemory(int sizeHint = 0)
            {
                var size = this.GetSize(sizeHint);
                return new Memory<T>(this.array, this.position, size);
            }

            public Span<T> GetSpan(int sizeHint = 0)
            {
                var size = this.GetSize(sizeHint);
                return new Span<T>(this.array, this.position, size);
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            private int GetSize(int sizeHint)
            {
                var free = this.length - this.position;
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
