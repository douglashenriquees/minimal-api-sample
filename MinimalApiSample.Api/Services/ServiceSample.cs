using System.ComponentModel.DataAnnotations;
using MinimalApiSample.Api.SwaggerFilters;
using Swashbuckle.AspNetCore.Annotations;

namespace MinimalApiSample.Api.Services;

public record Customer(
    [property:
        SwaggerSchema(Description = "Name of the Customer"),
        SwaggerSchemaExample("Blaise Pascal"),
        Required,
        MinLength(10),
        MaxLength(100)
    ] string Nome,

    [property:
        SwaggerSchema(Description = "E-mail of the Customer"),
        SwaggerSchemaExample("blaise.pascal@email.com")
    ] string? Email
);

public class ServiceSample
{
    public CreatedResult CreateCustomer(string nome, string? email)
    {
        return new CreatedResult() { Message = $"{nome} - {email ?? nome.ToLower().Replace(" ", string.Empty)}.email" };
    }

    public Customer GetCustomer(string nome, string? email)
    {
        return new Customer(nome, email);
    }
}

public class BadRequestResult
{
    public string Message { get; set; } = string.Empty;
}

public class CreatedResult
{
    public string Message { get; set; } = string.Empty;
}