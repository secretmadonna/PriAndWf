using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;

namespace PriAndWf.Infrastructure.Extension
{
    /// <summary>
    /// Object扩展方法
    /// </summary>
    public static class ObjectExtension
    {
        /// <summary>
        /// object转T（强转）
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static T As<T>(this object obj)
            where T : class
        {
            return (T)obj;
        }

        /// <summary>
        /// object转T
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static T To<T>(this object obj)
            where T : struct
        {
            if (typeof(T) == typeof(Guid))
            {
                return (T)TypeDescriptor.GetConverter(typeof(T)).ConvertFromInvariantString(obj.ToString());
            }

            return (T)Convert.ChangeType(obj, typeof(T), CultureInfo.InvariantCulture);
        }

        /// <summary>
        /// item是否在list中
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="item"></param>
        /// <param name="list"></param>
        /// <returns></returns>
        public static bool IsIn<T>(this T item, params T[] list)
        {
            return list.Contains(item);
        }

        #region Enum 扩展
        private static Dictionary<string, string> enumKeyValues = new Dictionary<string, string>();
        public static string Description(this Enum e)
        {
            var enumType = e.GetType();
            var name = Enum.GetName(enumType, e);
            var key = string.Format("{0}.{1}", enumType.FullName, name);
            if (enumKeyValues.ContainsKey(key))
            {
                return enumKeyValues[key];
            }
            var fieldInfo = enumType.GetField(name);
            var attr = Attribute.GetCustomAttribute(fieldInfo, typeof(DescriptionAttribute), false) as DescriptionAttribute;
            enumKeyValues.Add(key, attr.Description);
            return attr.Description;
        }
        #endregion
    }
}
