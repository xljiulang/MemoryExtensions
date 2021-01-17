namespace System.Buffers
{
    /// <summary>
    /// 提供MemoryBufferWriter的创建扩展
    /// </summary>
    public static class MemoryBufferWriterExtensions
    {
        /// <summary>
        /// 创建固定大小的BufferWriter
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="array"></param>
        /// <returns></returns>
        public static MemoryBufferWriter<T> CreateWriter<T>(this T[] array)
        {
            return array.AsMemory().CreateWriter();
        }

        /// <summary>
        /// 创建固定大小的BufferWriter
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="arraySegment"></param>
        /// <returns></returns>
        public static MemoryBufferWriter<T> CreateWriter<T>(this ArraySegment<T> arraySegment)
        {
            return arraySegment.AsMemory().CreateWriter();
        }

        /// <summary>
        /// 获取BufferWriter
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="memory"></param>
        /// <returns></returns>
        public static MemoryBufferWriter<T> CreateWriter<T>(this Memory<T> memory)
        {
            return new MemoryBufferWriter<T>(memory);
        }
    }
}
