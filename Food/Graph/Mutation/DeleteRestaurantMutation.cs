using Food.Interfaces;
using Food.Models;
using GraphQL;
using GraphQL.Types;
using System;

namespace Food.Graph.Mutation
{
    public class DeleteRestaurantMutation : IFieldMutationServiceItem
    {
        public void Activate(ObjectGraphType objectGraph, IServiceProvider sp)
        {
            objectGraph.Field<StringGraphType>("deleteRestaurant",
            arguments: new QueryArguments(
               new QueryArgument<NonNullGraphType<IntGraphType>> { Name = "id" }               
            ),
            resolve: context =>
            {
                var id = context.GetArgument<int>("id");
                //var restaurantRepo = (IGenericRepository<Restaurant>)sp.GetService(typeof(IGenericRepository<Restaurant>));
                //restaurantRepo.Delete(id);
                return $"cityId:{id} deleted";
            });
        }
    }
}
