using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace MultitenantWebAPI.SwaggerFilters;

public class XTenantIdFilter : IOperationFilter
{
    public void Apply(OpenApiOperation operation, OperationFilterContext context)
    {
        operation.Parameters ??= new List<OpenApiParameter>();

        operation.Parameters.Add(new OpenApiParameter()
        {
            Name = "X-TenantId",
            In = ParameterLocation.Header,
            Required = true,
        });
    }
}