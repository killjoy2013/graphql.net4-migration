using Food.Graph.Mutation;
using Food.Graph.Query;
using Food.Interfaces;
using GraphQL.Instrumentation;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Food.Graph.Schema
{
    public class FoodSchema : GraphQL.Types.Schema
    {
        public FoodSchema(IServiceProvider provider) : base(provider)
        {
            var fieldService = provider.GetRequiredService<IFieldService>();
            fieldService.RegisterFields();
            Mutation = provider.GetRequiredService<MainMutation>();
            Query = provider.GetRequiredService<MainQuery>();

            FieldMiddleware.Use(new InstrumentFieldsMiddleware());
        }
    }
}
