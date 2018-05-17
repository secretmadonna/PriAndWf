using System;
using System.Linq;
using System.Reflection;

namespace PriAndWf.Domain.ValueObject
{
    public abstract class ValueObject<T> : IEquatable<T> where T : ValueObject<T>
    {
        public bool Equals(T other)
        {
            if ((object)other == null)
            {
                return false;
            }

            var publicProperties = this.GetType().GetTypeInfo().GetProperties();
            if (!publicProperties.Any())
            {
                return true;
            }

            return publicProperties.All(property => Equals(property.GetValue(this, null), property.GetValue(other, null)));
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }

            var item = obj as ValueObject<T>;
            return (object)item != null && Equals((T)item);
        }

        public override int GetHashCode()
        {
            const int index = 1;
            const int initialHasCode = 31;

            var publicProperties = GetType().GetTypeInfo().GetProperties();

            if (!publicProperties.Any())
            {
                return initialHasCode;
            }

            var hashCode = initialHasCode;
            var changeMultiplier = false;

            foreach (var property in publicProperties)
            {
                var value = property.GetValue(this, null);

                if (value == null)
                {
                    //support {"a",null,null,"a"} != {null,"a","a",null}
                    hashCode = hashCode ^ (index * 13);
                    continue;
                }

                hashCode = hashCode * (changeMultiplier ? 59 : 114) + value.GetHashCode();
                changeMultiplier = !changeMultiplier;
            }

            return hashCode;
        }

        public static bool operator ==(ValueObject<T> x, ValueObject<T> y)
        {
            if (ReferenceEquals(x, y))
            {
                return true;
            }

            if (((object)x == null) || ((object)y == null))
            {
                return false;
            }

            return x.Equals(y);
        }

        public static bool operator !=(ValueObject<T> x, ValueObject<T> y)
        {
            return !(x == y);
        }
    }
}
