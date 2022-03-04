using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Food.Models
{
    [Table("tag", Schema = "food")]
    public partial class Tag : BaseEntity
    {
        public string Name { get; set; }
        
    }
}
