using System;

namespace GraphQL.WebApi.Interfaces
{
    public interface IEntity
    {
        int Id { get; set; }
        DateTime? CreationDate { get; set; }
    }
}
