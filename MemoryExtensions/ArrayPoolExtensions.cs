using System.Diagnostics;

namespace System.Buffers
{
    /// <summary>
    /// 提供ArrayPool的扩展
    /// </summary>
    public static class ArrayPoolExtensions
    {
        /// <summary>
        /// 申请可回收的IArrayOwner
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="arrayPool"></param>
        /// <param name="length">有效数据长度</param>
        /// <returns></returns>
        public static IArrayOwner<T> RentArrayOwner<T>(this ArrayPool<T> arrayPool, int length)
        {
            return new ArrayOwner<T>(arrayPool, length);
        }

        /// <summary>
        /// 表示数组持有者
        /// </summary>
        /// <typeparam name="T"></typeparam>
        [DebuggerDisplay("Length = {Length}")]
        private sealed class ArrayOwner<T> : Recyclable, IArrayOwner<T>
        {
            private readonly ArrayPool<T> arrayPool;

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
            /// <param name="arrayPool"></param>
            /// <param name="minLength"></param> 
            public ArrayOwner(ArrayPool<T> arrayPool, int minLength)
            {
                this.arrayPool = arrayPool;
                this.Length = minLength;
                this.Array = arrayPool.Rent(minLength);
            }

            /// <summary>
            /// 归还数组
            /// </summary>
            /// <param name="disposing"></param>
            protected override void Dispose(bool disposing)
            {
                this.arrayPool.Return(this.Array);
            }
        }
    }
}
