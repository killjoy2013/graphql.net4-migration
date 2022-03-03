using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace GraphQL.WebApi.Models
{
    [Table("restaurant", Schema = "food")]
    public partial class Restaurant : BaseEntity
    {      
        public string Name { get; set; }

        [ForeignKey("tag_id")]
        public ICollection<Tag> Tags { get; set; }

    }
}
