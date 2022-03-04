using Food.Graph.Type;
using Food.Interfaces;
using Food.Models;
using GraphQL.Types;
using System;


namespace Food.Graph.Query.Business
{
    public class RestaurantQuery : IFieldQueryServiceItem
    {
        public void Activate(ObjectGraphType objectGraph, IServiceProvider sp)
        {
            objectGraph.Field<ListGraphType<RestaurantGType>>("restaurants",
               arguments: new QueryArguments(
                 new QueryArgument<StringGraphType> { Name = "name" }
               ),
               resolve: context =>
               {
                   //var restaurantRepo = (IGenericRepository<Restaurant>)sp.GetService(typeof(IGenericRepository<Restaurant>));
                   //var baseQuery = restaurantRepo.GetAll();
                   //var name = context.GetArgument<string>("name");
                   //if (name != default(string))
                   //{
                   //    return baseQuery.Where(w => w.Name.Contains(name));
                   //}
                   //return baseQuery.ToList();

                   return new Restaurant[] { };

               });
        }
    }
}
