using GraphQL.Validation;
using System.Threading.Tasks;

namespace Food
{
    public class InputValidationRule : IValidationRule
    {
        public Task<INodeVisitor> ValidateAsync(ValidationContext context)
        {
            return Task.FromResult((INodeVisitor)new NodeVisitors());
        }
    }
}
