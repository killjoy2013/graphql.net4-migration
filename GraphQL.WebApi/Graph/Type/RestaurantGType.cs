using GraphQL.Types;
using GraphQL.WebApi.Interfaces;
using GraphQL.WebApi.Models;
using System;

namespace GraphQL.WebApi.Graph.Type
{
    public class RestaurantGType : ObjectGraphType<Restaurant>
    {
        public IServiceProvider Provider { get; set; }
        public RestaurantGType(IServiceProvider provider)
        {
            Field(x => x.Id, type: typeof(IntGraphType));
            Field(x => x.Name, type: typeof(StringGraphType));
            
        }
    }
}
