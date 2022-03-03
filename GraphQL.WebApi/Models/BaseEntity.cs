using GraphQL.WebApi.Interfaces;
using System;

namespace GraphQL.WebApi.Models
{
    public abstract class BaseEntity : IEntity
    {
        public int Id { get; set; }
        public DateTime? CreationDate { get; set; }

    }
}
