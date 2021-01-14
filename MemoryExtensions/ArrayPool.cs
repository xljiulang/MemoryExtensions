using System.Diagnostics;

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
        /// <param name="minLength">最小长度</param>
        /// <returns></returns>
        public static IArrayOwner<T> Rent<T>(int minLength)
        {
            return new ArrayOwner<T>(minLength);
        }

        /// <summary>
        /// 表示数组持有者
        /// </summary>
        /// <typeparam name="T"></typeparam>
        [DebuggerDisplay("Length = {Length}")]
        private sealed class ArrayOwner<T> : Disposable, IArrayOwner<T>
        {
            /// <summary>
            /// 获取数据有效数据长度
            /// </summary>
            public int Length { get; }

            /// <summary>
            /// 获取持有的数组
            /// </summary>
            public T[] Array { get; }

            /// <summary>
            /// 数组持有者
            /// </summary>
            /// <param name="minLength"></param> 
            public ArrayOwner(int minLength)
            {
                this.Length = minLength;
                this.Array = ArrayPool<T>.Shared.Rent(minLength);
            }

            /// <summary>
            /// 归还数组
            /// </summary>
            /// <param name="disposing"></param>
            protected sealed override void Dispose(bool disposing)
            {
                ArrayPool<T>.Shared.Return(this.Array);
            }
        }
    }
}
