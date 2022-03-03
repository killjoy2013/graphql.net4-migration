using GraphQL.Types;
using GraphQL.WebApi.Interfaces;
using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GraphQL.WebApi.Services
{
    public class FieldService : IFieldService
    {
        private IDictionary<FieldServiceType, IList<IFieldServiceItem>> _fieldTable;     

        public FieldService()
        {            
            _fieldTable = new Dictionary<FieldServiceType, IList<IFieldServiceItem>>();
            _fieldTable.Add(FieldServiceType.Mutation, new List<IFieldServiceItem>());
            _fieldTable.Add(FieldServiceType.Query, new List<IFieldServiceItem>());           
        }

        public void ActivateFields(
            ObjectGraphType objectGraph,
            FieldServiceType fieldType,
            IWebHostEnvironment env,
            IServiceProvider provider)
        {

            var serviceItemList = _fieldTable[fieldType];

            foreach (var serviceItem in serviceItemList)
            {
                serviceItem.Activate(objectGraph, env, provider);
            }
        }

        public void RegisterFields()
        {
            var type = typeof(IFieldServiceItem);
            var types = AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(s => s.GetTypes())
                .Where(p => type.IsAssignableFrom(p));

            foreach (var fieldType in types)
            {
                if (fieldType.IsClass)
                {
                    if (typeof(IFieldMutationServiceItem).IsAssignableFrom(fieldType))
                    {
                        _fieldTable[FieldServiceType.Mutation].Add((IFieldServiceItem)Activator.CreateInstance(fieldType));
                    }
                    else if (typeof(IFieldQueryServiceItem).IsAssignableFrom(fieldType))
                    {
                        _fieldTable[FieldServiceType.Query].Add((IFieldServiceItem)Activator.CreateInstance(fieldType));
                    }
                }
            }
        }
    }
}
