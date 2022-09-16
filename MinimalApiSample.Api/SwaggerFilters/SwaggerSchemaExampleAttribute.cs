namespace MinimalApiSample.Api.SwaggerFilters;

[AttributeUsage(
    AttributeTargets.Class |
    AttributeTargets.Struct |
    AttributeTargets.Parameter |
    AttributeTargets.Property |
    AttributeTargets.Enum
)]
public class SwaggerSchemaExampleAttribute : Attribute
{
    public string Example { get; set; } = string.Empty;

    public SwaggerSchemaExampleAttribute(string example)
    {
        Example = example;
    }
}