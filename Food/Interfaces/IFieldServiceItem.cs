using GraphQL.Types;
using System;

namespace Food.Interfaces
{
    public interface IFieldServiceItem
    {
        void Activate(ObjectGraphType objectGraph, IServiceProvider sp);
    }

    public interface IFieldMutationServiceItem : IFieldServiceItem
    {
    }

    public interface IFieldQueryServiceItem : IFieldServiceItem
    {
    }
    public interface IFieldSubscriptionServiceItem : IFieldServiceItem
    {

    }
}
