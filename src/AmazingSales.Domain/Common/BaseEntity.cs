using AmazingSales.Domain.Common.Interfaces;

namespace AmazingSales.Domain.Common
{
    public abstract class BaseEntity : IEntity, IEquatable<BaseEntity>
    {
        public long Id { get; init; }

        protected BaseEntity(long id)
        {
            Id = id;
        }

        public override bool Equals(object? obj)
        {
            if (obj is null)
                return false;

            if (obj.GetType() != GetType())
                return false;

            if (obj is not BaseEntity entity)
                return false;

            return entity.Id == Id;
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode() * 41;
        }

        public bool Equals(BaseEntity? other)
        {
            if (other is null)
                return false;

            if (other.GetType() != GetType())
                return false;

            return other.Id == Id;
        }

        public static bool operator ==(BaseEntity? first, BaseEntity? second) =>
            first is not null && second is not null && first.Equals(other: second);

        public static bool operator !=(BaseEntity? first, BaseEntity? second) => !(first == second);
    }
}
