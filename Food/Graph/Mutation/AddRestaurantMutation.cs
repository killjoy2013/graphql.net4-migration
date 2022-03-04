using Food.Graph.Type;
using Food.Interfaces;
using Food.Models;
using GraphQL;
using GraphQL.Types;
using System;

namespace Food.Graph.Mutation
{
    public class AddRestaurantMutation : IFieldMutationServiceItem
    {
        public void Activate(ObjectGraphType objectGraph, IServiceProvider sp)
        {
            objectGraph.Field<RestaurantGType>("addRestaurant",
            arguments: new QueryArguments(               
               new QueryArgument<NonNullGraphType<StringGraphType>> { Name = "name" }               
            ),
            resolve: context =>
            {                                
                var name = context.GetArgument<string>("name");

                //var restaurantRepo = (IGenericRepository<Restaurant>)sp.GetService(typeof(IGenericRepository<Restaurant>));

                var newRestaurant = new Restaurant
                {
                    Name = name,
                };

                //restaurantRepo.Insert(newRestaurant);
                return newRestaurant;
            });
        }
    }
}
