using GraphQL.Types;
using GraphQL.WebApi.Graph.Type;
using GraphQL.WebApi.Interfaces;
using GraphQL.WebApi.Models;
using Microsoft.AspNetCore.Hosting;
using System;
using System.Linq;

namespace GraphQL.WebApi.Graph.Query.Business
{
    public class TagQuery : IFieldQueryServiceItem
    {
        public void Activate(ObjectGraphType objectGraph, IWebHostEnvironment env, IServiceProvider sp)
        {
            objectGraph.Field<ListGraphType<TagGType>>("tags",
               arguments: new QueryArguments(
                 new QueryArgument<StringGraphType> { Name = "name" }
               ),
               resolve: context =>
               {
                   //var tagRepo = (IGenericRepository<Tag>)sp.GetService(typeof(IGenericRepository<Tag>));
                   //var baseQuery = tagRepo.GetAll();
                   //var name = context.GetArgument<string>("name");
                   //if (name != default(string))
                   //{
                   //    return baseQuery.Where(w => w.Name.Contains(name));
                   //}
                   //return baseQuery.ToList();

                   return new Tag[] { };
               });
        }
    }
}
