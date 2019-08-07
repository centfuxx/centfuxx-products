using System.Collections.Generic;

namespace CentFuxx.Products.Domain
{
    public abstract class Entity<TId>
    {
        public TId Id { get; private set; }

        protected Entity()
        {
        }

        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }

        protected bool Equals(Entity<TId> other)
        {
            return EqualityComparer<TId>.Default.Equals(Id, other.Id);
        }

        public override int GetHashCode()
        {
            return EqualityComparer<TId>.Default.GetHashCode(Id);
        }
    }
}