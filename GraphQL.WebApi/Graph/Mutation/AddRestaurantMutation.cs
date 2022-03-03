using GraphQL.Types;
using GraphQL.WebApi.Graph.Type;
using GraphQL.WebApi.Interfaces;
using GraphQL.WebApi.Models;
using Microsoft.AspNetCore.Hosting;
using System;
using System.Linq;

namespace GraphQL.WebApi.Graph.Mutation
{
    public class AddRestaurantMutation : IFieldMutationServiceItem
    {
        public void Activate(ObjectGraphType objectGraph, IWebHostEnvironment env, IServiceProvider sp)
        {
            objectGraph.Field<RestaurantGType>("addRestaurant",
            arguments: new QueryArguments(               
               new QueryArgument<NonNullGraphType<StringGraphType>> { Name = "name" }               
            ),
            resolve: context =>
            {                                
                var name = context.GetArgument<string>("name");
                
                var restaurantRepo = (IGenericRepository<Restaurant>)sp.GetService(typeof(IGenericRepository<Restaurant>));
                
                var newRestaurant = new Restaurant
                {
                    Name = name,                    
                };

                restaurantRepo.Insert(newRestaurant);
                return newRestaurant;
            });
        }
    }
}
