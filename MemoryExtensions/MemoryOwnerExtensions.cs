namespace System.Buffers
{
    /// <summary>
    /// IMemoryOwner扩展
    /// </summary>
    public static class MemoryOwnerExtensions
    {
        /// <summary>
        /// 切片
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="owner"></param>
        /// <param name="start">开始索引</param>
        /// <returns></returns>
        public static IMemoryOwner<T> Slice<T>(this IMemoryOwner<T> owner, int start)
        {
            var memory = owner.Memory.Slice(start);
            return new MemoryOwner<T>(owner, memory);
        }

        /// <summary>
        /// 切片
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="owner"></param>
        /// <param name="start">开始索引</param>
        /// <param name="length">长度</param>
        /// <returns></returns>
        public static IMemoryOwner<T> Slice<T>(this IMemoryOwner<T> owner, int start, int length)
        {
            var memory = owner.Memory.Slice(start, length);
            return new MemoryOwner<T>(owner, memory);
        }


        /// <summary>
        /// 表示内存持有者
        /// </summary>
        /// <typeparam name="T"></typeparam>
        private class MemoryOwner<T> : Disposable, IMemoryOwner<T>
        {
            private readonly IDisposable owner;

            /// <summary>
            /// 获取持有的内存
            /// </summary>
            public Memory<T> Memory { get; }

            /// <summary>
            /// 内存持有者
            /// </summary>
            /// <param name="owner">内存的实际持有者</param>
            /// <param name="memory">内存</param>
            public MemoryOwner(IDisposable owner, Memory<T> memory)
            {
                this.owner = owner;
                this.Memory = memory;
            }

            /// <summary>
            /// 归还内存
            /// </summary>
            /// <param name="disposing"></param>
            protected override void Dispose(bool disposing)
            {
                this.owner.Dispose();
            }
        }
    }
} 