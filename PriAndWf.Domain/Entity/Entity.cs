using PriAndWf.Infrastructure.Extension;
using System;
using System.Collections.Generic;
using System.Reflection;

namespace PriAndWf.Domain.Entity
{
    [Serializable]
    public abstract class Entity<T> : IEntity<T>
    {
        public virtual T Id { get; }

        public virtual bool IsTransient()
        {
            if (EqualityComparer<T>.Default.Equals(Id, default(T)))
            {
                return true;
            }

            //Workaround for EF Core since it sets int/long to min value when attaching to dbcontext
            if (typeof(T) == typeof(int) || typeof(T) == typeof(long))
            {
                return Convert.ToInt32(Id) <= 0;
            }

            return false;
        }


        /// <inheritdoc/>
        public override bool Equals(object obj)
        {
            if (obj == null || !(obj is Entity<T>))
            {
                return false;
            }

            //Same instances must be considered as equal
            if (ReferenceEquals(this, obj))
            {
                return true;
            }

            //Transient objects are not considered as equal
            var other = (Entity<T>)obj;
            if (IsTransient() && other.IsTransient())
            {
                return false;
            }

            //Must have a IS-A relation of types or must be same type
            var typeOfThis = GetType();
            var typeOfOther = other.GetType();
            if (!typeOfThis.GetTypeInfo().IsAssignableFrom(typeOfOther) && !typeOfOther.GetTypeInfo().IsAssignableFrom(typeOfThis))
            {
                return false;
            }

            if (this is IMayHaveTenant && other is IMayHaveTenant &&
                this.As<IMayHaveTenant>().TenantId != other.As<IMayHaveTenant>().TenantId)
            {
                return false;
            }

            if (this is IMustHaveTenant && other is IMustHaveTenant &&
                this.As<IMustHaveTenant>().TenantId != other.As<IMustHaveTenant>().TenantId)
            {
                return false;
            }

            return Id.Equals(other.Id);
        }

        /// <inheritdoc/>
        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }

        /// <inheritdoc/>
        public static bool operator ==(Entity<T> left, Entity<T> right)
        {
            if (Equals(left, null))
            {
                return Equals(right, null);
            }

            return left.Equals(right);
        }

        /// <inheritdoc/>
        public static bool operator !=(Entity<T> left, Entity<T> right)
        {
            return !(left == right);
        }

        /// <inheritdoc/>
        public override string ToString()
        {
            return $"[{GetType().Name} {Id}]";
        }
    }

    [Serializable]
    public abstract class Entity : Entity<int>, IEntity
    {

    }
}
