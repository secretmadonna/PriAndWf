namespace PriAndWf.Infrastructure
{
    /// <summary>
    /// 表示所有集成于该接口的类型都是 Unit Of Work 的一种实现。
    /// </summary>
    /// <remarks>有关 Unit Of Work 的详细信息，请参见 UnitOfWork 模式：http://martinfowler.com/eaaCatalog/unitOfWork.html。
    /// </remarks>
    public interface IUnitOfWork
    {
        /// <summary>
        /// 获得一个 <see cref="System.Boolean"/> 值，该值表示当前的 Unit Of Work 是否支持 Microsoft 分布式事务处理机制。
        /// </summary>
        bool DistributedTransactionSupported { get; }
        /// <summary>
        /// 获得一个 <see cref="System.Boolean"/> 值，该值表述了当前的 Unit Of Work 事务是否已被提交。
        /// </summary>
        bool Committed { get; }
        /// <summary>
        /// 提交当前的 Unit Of Work 事务。
        /// </summary>
        void Commit();
        /// <summary>
        /// 回滚当前的 Unit Of Work 事务。
        /// </summary>
        void Rollback();
    }
}
