namespace System.Buffers
{
    /// <summary>
    /// 表示共享的数组池
    /// </summary>
    public static class ArrayPool
    {
        /// <summary>
        /// 租赁数组
        /// </summary>
        /// <typeparam name="T">元素类型</typeparam>
        /// <param name="length">有效数据长度</param>
        /// <returns></returns>
        public static IArrayOwner<T> Rent<T>(int length)
        {
            return ArrayPool<T>.Shared.RentArrayOwner(length);
        }
    }
}
