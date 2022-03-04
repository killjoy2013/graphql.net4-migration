using System.Collections.Generic;
using System.Security.Claims;

namespace GraphQL.WebApi
{
    public class GraphQLUserContext : Dictionary<string, object>
    {
        public ClaimsPrincipal User { get; set; }
    }
}
