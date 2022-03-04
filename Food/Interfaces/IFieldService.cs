using GraphQL.Types;
using System;

namespace Food.Interfaces
{
    public interface IFieldService
    {
        void ActivateFields(
            ObjectGraphType objectGraph,
            FieldServiceType fieldType,          
            IServiceProvider provider);



        void RegisterFields();
    }

    public enum FieldServiceType
    {
        Query,
        Mutation,
        Subscription
    }
}
