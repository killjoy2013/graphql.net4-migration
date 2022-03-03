using GraphQL.WebApi.Graph.Mutation;
using GraphQL.WebApi.Graph.Query;
using GraphQL.WebApi.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace GraphQL.WebApi.Graph.Schema
{
    public class GraphQLSchema : GraphQL.Types.Schema
    {
        public GraphQLSchema(IServiceProvider provider) : base(provider)
        {
            var fieldService = provider.GetRequiredService<IFieldService>();
            fieldService.RegisterFields();
            
            Mutation = provider.GetRequiredService<MainMutation>();
            //Query = resolver.Resolve<MainQuery>();
            Query = provider.GetRequiredService<MainQuery>();

        }
    }
}
