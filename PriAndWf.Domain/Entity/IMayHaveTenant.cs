namespace PriAndWf.Domain.Entity
{
    /// <summary>
    /// 继承于该接口的类型可以拥有Tenant Id
    /// </summary>
    public interface IMayHaveTenant
    {
        int? TenantId { get; set; }
    }
}
