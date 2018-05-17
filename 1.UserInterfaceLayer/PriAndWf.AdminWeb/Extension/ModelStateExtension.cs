using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace MyTestMvc.Extension
{
    public static class ModelStateExtension
    {
        public static string GetFirstValidNotPassMsg(this ModelStateDictionary modelState)
        {
            var kvp = modelState.FirstOrDefault(m => m.Value != null && m.Value.Errors != null && m.Value.Errors.Count > 0);
            var ms = kvp.Value.Errors.FirstOrDefault();
            return ms.Exception == null ? ms.Exception.Message : ms.ErrorMessage;
        }
        public static List<string> GetAllValidNotPassMsgs(this ModelStateDictionary modelState)
        {
            var list = new List<string>();

            if (modelState != null && modelState.Values != null && modelState.Values.Count > 0)
            {
                foreach (var ms in modelState.Values)
                {
                    if (ms != null && ms.Errors != null && ms.Errors.Count > 0)
                    {
                        foreach (var me in ms.Errors)
                        {
                            if (me.Exception != null)
                            {
                                list.Add(me.Exception.Message);
                            }
                            if (!string.IsNullOrWhiteSpace(me.ErrorMessage))
                            {
                                list.Add(me.ErrorMessage);
                            }
                        }
                    }
                }
            }

            return list;
        }
    }
}