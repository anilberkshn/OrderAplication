using System.Linq;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace Core.Model.Config
{
    public class SwaggerCustomize: IOperationFilter
    {
        public void Apply(OpenApiOperation operation, OperationFilterContext context)
        {
            var parametersToRemove = operation.Parameters?.Where(p => p.Name == "($uuid)").ToList();
        
            if (parametersToRemove != null && parametersToRemove.Any())
            {
                foreach (var parameter in parametersToRemove)
                {
                    operation.Parameters.Remove(parameter);
                }
            }
        }
    }
}