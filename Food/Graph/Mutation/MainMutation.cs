using Food.Interfaces;
using GraphQL.Types;
using System;

namespace Food.Graph.Mutation
{
    public class MainMutation : ObjectGraphType
    {
        public MainMutation(IServiceProvider provider, IFieldService fieldService)
        {
            Name = "MainMutation";
            fieldService.ActivateFields(this, FieldServiceType.Mutation, provider);
        }
    }
}
