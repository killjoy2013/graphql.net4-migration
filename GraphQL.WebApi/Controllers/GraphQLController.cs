using GraphQL.NewtonsoftJson;
using GraphQL.Types;
using GraphQL.Validation.Complexity;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Threading.Tasks;

namespace GraphQL.WebApi.Controllers
{
    [Route("graphql")]
    public class GraphQLController : Controller
    {
        private IDocumentExecuter _executer;       
        private ISchema _schema;

        public GraphQLController(
             IDocumentExecuter executer,            
             ISchema schema)
        {
            _executer = executer;           
            _schema = schema;
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync(HttpRequestMessage request, [FromBody] GraphQLQuery query)
        {
            var inputs = query.Variables.ToInputs();
            var queryToExecute = query.Query;

            var result = await _executer.ExecuteAsync(_ =>
            {
                _.Schema = _schema;
                _.Query = queryToExecute;
                _.OperationName = query.OperationName;
                _.Inputs = inputs;

                _.ComplexityConfiguration = new ComplexityConfiguration { MaxDepth = 15 };

            }).ConfigureAwait(false);

            if (result.Errors?.Count > 0)
            {                
                return BadRequest(new { result, result.Errors });
            }
            return Ok(result);
        }
    }

    public class GraphQLQuery
    {
        public string OperationName { get; set; }
        public string Query { get; set; }
        public Newtonsoft.Json.Linq.JObject Variables { get; set; }
    }
}
