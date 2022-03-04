using Food.Interfaces;
using GraphQL.Types;

using System;

namespace Food.Graph.Query
{
    public class MainQuery : ObjectGraphType
    {
        public MainQuery(IServiceProvider provider,  IFieldService fieldService)
        {
            Name = "MainQuery";
            fieldService.ActivateFields(this, FieldServiceType.Query, provider);
        }
    }
}
