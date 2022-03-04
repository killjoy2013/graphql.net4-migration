using Food.Models;
using GraphQL.Types;
using System;

namespace Food.Graph.Type
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
