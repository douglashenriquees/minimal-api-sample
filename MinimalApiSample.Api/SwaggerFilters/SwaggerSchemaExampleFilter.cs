using System.Reflection;
using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace MinimalApiSample.Api.SwaggerFilters;

public class SwaggerSchemaExampleFilter : ISchemaFilter
{
    public void Apply(OpenApiSchema schema, SchemaFilterContext context)
    {
        if (context.MemberInfo != null)
        {
            var schemaExampleAttribute = context.MemberInfo.GetCustomAttributes<SwaggerSchemaExampleAttribute>().FirstOrDefault();

            if (schemaExampleAttribute != null)
            {
                ApplySchemaAttribute(schema, schemaExampleAttribute);
            }
        }
    }

    private void ApplySchemaAttribute(OpenApiSchema schema, SwaggerSchemaExampleAttribute schemaExampleAttribute)
    {
        if (schemaExampleAttribute.Example != null)
        {
            schema.Example = new OpenApiString(schemaExampleAttribute.Example);
        }
    }
}