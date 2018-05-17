using System;
using PriAndWf.Domain.Entity;

namespace PriAndWf.Domain.EventHandler.Event
{
    /// <summary>
    /// 用短信注册时，所产生的领域事件
    /// </summary>
    [Serializable]
    public class RegisterShortMessageEvent : DomainEvent.DomainEvent
    {
        public RegisterShortMessageEvent() { }
        public RegisterShortMessageEvent(IEntity eventSource) : base(eventSource) { }

        #region 事件信息
        /// <summary>
        /// 手机号
        /// </summary>
        public string HandPhone { get; set; }
        #endregion
    }
}
