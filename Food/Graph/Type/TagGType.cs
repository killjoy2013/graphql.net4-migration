using Food.Models;
using GraphQL.Types;
using System;
using System.Linq;

namespace Food.Graph.Type
{
    public class TagGType : ObjectGraphType<Tag>
    {
        public IServiceProvider Provider { get; set; }
        public TagGType(IServiceProvider provider)
        {
            Field(x => x.Id, type: typeof(IntGraphType));
            Field(x => x.Name, type: typeof(StringGraphType));
            
        }
    }
}
