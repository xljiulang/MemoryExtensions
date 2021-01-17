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
        public static IBufferWriter<T> CreateWriter<T>(this T[] array)
        {
            return array.AsMemory().CreateWriter();
        }

        /// <summary>
        /// 创建固定大小的BufferWriter
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="arraySegment"></param>
        /// <returns></returns>
        public static IBufferWriter<T> CreateWriter<T>(this ArraySegment<T> arraySegment)
        {
            return arraySegment.AsMemory().CreateWriter();
        }

        /// <summary>
        /// 获取BufferWriter
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="memory"></param>
        /// <returns></returns>
        public static IBufferWriter<T> CreateWriter<T>(this Memory<T> memory)
        {
            return new FixedBufferWriter<T>(memory);
        }

        /// <summary>
        /// 表示固定大小的BufferWriter
        /// </summary>
        /// <typeparam name="T"></typeparam>
        private struct FixedBufferWriter<T> : IBufferWriter<T>
        {
            private Memory<T> buffer;

            public FixedBufferWriter(Memory<T> buffer)
            {
                this.buffer = buffer;
            }

            public void Advance(int count)
            {
                if (count < 0 || count > this.buffer.Length)
                {
                    throw new ArgumentOutOfRangeException(nameof(count));
                }
                this.buffer = this.buffer.Slice(count);
            }

            public Span<T> GetSpan(int sizeHint = 0)
            {
                return this.GetMemory(sizeHint).Span;
            }

            public Memory<T> GetMemory(int sizeHint = 0)
            {
                if (sizeHint > this.buffer.Length)
                {
                    throw new ArgumentOutOfRangeException(nameof(sizeHint));
                }
                return this.buffer;
            }
        }
    }
}
