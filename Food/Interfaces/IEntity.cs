using System;

namespace Food.Interfaces
{
    public interface IEntity
    {
        int Id { get; set; }
        DateTime? CreationDate { get; set; }
    }
}
