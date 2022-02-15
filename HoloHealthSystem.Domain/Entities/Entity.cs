using Flunt.Notifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HoloHealthSystem.Domain.Entities
{
    public class Entity : IEquatable<Entity>
    {
        public Entity()
        {
            Id = Guid.NewGuid();
        }
        public bool Equals(Entity? other)
        {
            if(ReferenceEquals(null, other)) return false;
            return other.Id == Id;
        }
        public Guid Id { get; private set; }
    }
}
