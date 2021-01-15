namespace System
{
    /// <summary>
    /// 表示可回收对象的抽象基础类
    /// </summary>
    public abstract class Recyclable : IDisposable
    {
        /// <summary>
        /// 获取对象是否已回收
        /// </summary>
        protected bool IsDisposed { get; private set; }

        /// <summary>
        /// 将对象进行回收
        /// </summary>
        public void Dispose()
        {
            if (this.IsDisposed == false)
            {
                this.Dispose(true);
                GC.SuppressFinalize(this);
            }
            this.IsDisposed = true;
        }

        /// <summary>
        /// 析构函数
        /// </summary>
        ~Recyclable()
        {
            this.Dispose(false);
        }

        /// <summary>
        /// 将对象进行回收
        /// </summary>
        /// <param name="disposing">是否也释放托管资源</param>
        protected abstract void Dispose(bool disposing);
    }
}
