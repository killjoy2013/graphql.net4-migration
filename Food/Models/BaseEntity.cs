using Food.Interfaces;
using System;

namespace Food.Models
{
    public abstract class BaseEntity : IEntity
    {
        public int Id { get; set; }
        public DateTime? CreationDate { get; set; }

    }
}
