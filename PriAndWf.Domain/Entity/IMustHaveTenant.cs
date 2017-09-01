namespace PriAndWf.Domain.Entity
{
    /// <summary>
    /// 继承于该接口的类型必须拥有Tenant Id
    /// </summary>
    public interface IMustHaveTenant
    {
        int TenantId { get; set; }
    }
}