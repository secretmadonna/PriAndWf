using System;
using PriAndWf.Domain.Entity;

namespace PriAndWf.Domain.EventHandler.Event
{
    /// <summary>
    /// 用邮箱验证码注册时，所产生的领域事件
    /// </summary>
    [Serializable]
    public class RegisterEmailEvent : DomainEvent.DomainEvent
    {
        public RegisterEmailEvent() { }
        public RegisterEmailEvent(IEntity eventSource) : base(eventSource) { }

        #region 事件信息
        /// <summary>
        /// 邮箱
        /// </summary>
        public string Email { get; set; }
        #endregion
    }
}
