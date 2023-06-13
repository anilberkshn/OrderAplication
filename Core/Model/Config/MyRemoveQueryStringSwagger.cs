using System.Linq;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace Core.Model.Config
{
    public class MyRemoveQueryStringSwagger: IDocumentFilter
    {
        public void Apply(OpenApiDocument swaggerDoc, DocumentFilterContext context)
        {
            foreach (var path in swaggerDoc.Paths.Values)
            {
                var parameters = path.Parameters?.ToList();

                if (parameters != null)
                {
                    foreach (var parameter in parameters)
                    {
                        if (parameter.Name == "($uuid)")
                        {
                            path.Parameters.Remove(parameter);
                        }
                    }
                }
            }
        }
    }
}