using GraphQL.Types;
using GraphQL.WebApi.Interfaces;
using GraphQL.WebApi.Models;
using System;
using System.Linq;

namespace GraphQL.WebApi.Graph.Type
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
