using GraphQL.WebApi.Graph.Mutation;
using GraphQL.WebApi.Graph.Query;
using GraphQL.WebApi.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace GraphQL.WebApi.Graph.Schema
{
    public class FoodSchema : GraphQL.Types.Schema
    {
        public FoodSchema(IServiceProvider provider) : base(provider)
        {
            var fieldService = provider.GetRequiredService<IFieldService>();
            fieldService.RegisterFields();            
            Mutation = provider.GetRequiredService<MainMutation>();           
            Query = provider.GetRequiredService<MainQuery>();
        }
    }
}
