using System.Text.Json;

namespace GraphQL.WebApi
{
    public class GraphQLRequest
    {
        public string OperationName { get; set; }

        public string Query { get; set; }

        public JsonElement Variables { get; set; }
    }
}
