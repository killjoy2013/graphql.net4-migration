using Food.Graph.Type;
using Food.Interfaces;
using Food.Models;
using GraphQL;
using GraphQL.Types;
using System;
using System.Linq;

namespace Food.Graph.Query.Business
{
    public class TagQuery : IFieldQueryServiceItem
    {
        public void Activate(ObjectGraphType objectGraph, IServiceProvider sp)
        {
            objectGraph.Field<ListGraphType<TagGType>>("tags",
               arguments: new QueryArguments(
                 new QueryArgument<StringGraphType> { Name = "name" }
               ),
               resolve: context =>
               {
                   var tagRepo = (IGenericRepository<Tag>)sp.GetService(typeof(IGenericRepository<Tag>));
                   var baseQuery = tagRepo.GetAll();
                   var name = context.GetArgument<string>("name");
                   if (name != default(string))
                   {
                       return baseQuery.Where(w => w.Name.Contains(name));
                   }
                   return baseQuery.ToList();
               });
        }
    }
}
