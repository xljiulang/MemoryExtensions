namespace System.Buffers
{
    /// <summary>
    /// 提供ArrayOwner的扩展
    /// </summary>
    public static class ArrayOwnerExtensions
    {
        /// <summary>
        /// 视为ArraySegment
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="arrayOwner"></param>
        /// <returns></returns>
        public static ArraySegment<T> AsArraySegment<T>(this IArrayOwner<T> arrayOwner)
        {
            return new ArraySegment<T>(arrayOwner.Array, 0, arrayOwner.Length);
        }

        /// <summary>
        /// 视为Span
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="arrayOwner"></param>
        /// <returns></returns>
        public static Span<T> AsSpan<T>(this IArrayOwner<T> arrayOwner)
        {
            return arrayOwner.Array.AsSpan(0, arrayOwner.Length);
        }

        /// <summary>
        /// 视为Memory
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="arrayOwner"></param>
        /// <returns></returns>
        public static Memory<T> AsMemory<T>(this IArrayOwner<T> arrayOwner)
        {
            return arrayOwner.Array.AsMemory(0, arrayOwner.Length);
        }
    }
}
