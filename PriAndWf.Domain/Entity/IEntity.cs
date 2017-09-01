namespace PriAndWf.Domain.Entity
{
    /// <summary>
    /// 继承于该接口的类型是（领域）实体类型
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IEntity<out T>
    {
        T Id { get; }

        bool IsTransient();
    }
    /// <summary>
    /// 继承于该接口的类型是（领域）实体类型（默认：int）
    /// </summary>
    public interface IEntity : IEntity<int>
    {

    }
}
