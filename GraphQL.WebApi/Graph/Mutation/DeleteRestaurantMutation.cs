using GraphQL.Types;
using GraphQL.WebApi.Interfaces;
using GraphQL.WebApi.Models;
using Microsoft.AspNetCore.Hosting;
using System;

namespace GraphQL.WebApi.Graph.Mutation
{
    public class DeleteRestaurantMutation : IFieldMutationServiceItem
    {
        public void Activate(ObjectGraphType objectGraph, IWebHostEnvironment env, IServiceProvider sp)
        {
            objectGraph.Field<StringGraphType>("deleteRestaurant",
            arguments: new QueryArguments(
               new QueryArgument<NonNullGraphType<IntGraphType>> { Name = "id" }               
            ),
            resolve: context =>
            {
                var id = context.GetArgument<int>("id");
                var restaurantRepo = (IGenericRepository<Restaurant>)sp.GetService(typeof(IGenericRepository<Restaurant>));
                restaurantRepo.Delete(id);
                return $"cityId:{id} deleted";
            });
        }
    }
}
