namespace System.Buffers
{
    /// <summary>
    /// 定义数组持有者的接口
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IArrayOwner<T> : IDisposable
    {
        /// <summary>
        /// 获取数据有效数据长度
        /// </summary>
        int Length { get; }

        /// <summary>
        /// 获取持有的数组
        /// </summary>
        T[] Array { get; }
    }
}