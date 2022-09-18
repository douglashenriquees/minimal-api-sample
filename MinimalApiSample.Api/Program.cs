using Microsoft.OpenApi.Models;
using MinimalApiSample.Api.Services;
using MinimalApiSample.Api.SwaggerFilters;
using Swashbuckle.AspNetCore.Annotations;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(x =>
{
    x.EnableAnnotations();
    x.SwaggerDoc("v1", new OpenApiInfo { Title = "Customers API", Version = "v1" });
    x.SchemaFilter<SwaggerSchemaExampleFilter>();
});
builder.Services.AddSingleton<ServiceSample>(new ServiceSample());

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI(x => { x.SwaggerEndpoint("/swagger/v1/swagger.json", "V1"); x.RoutePrefix = ""; });

app.MapGet("api/v1/customer",
    [SwaggerOperation(Description = "Get a Customer")] () =>
    new Customer("Blaise Pascal", "blase.pascal@email.com"))
    .WithTags("Customers");

app.MapGet("api/v1/customer/{id}",
    [SwaggerOperation(Description = "Get a Customer by ID")] (
        [SwaggerParameter(Description = "ID of the Customer")] int id
    ) =>
    new Customer("Blaise Pascal", "blase.pascal@email.com"))
    .WithTags("Customers");

app.MapGet("api/v1/customer/all",
    [SwaggerOperation(Description = "Get all Customers")] (
        ServiceSample serviceSample,
        [SwaggerParameter(Description = "Name of the Customer")] string nome,
        [SwaggerParameter(Description = "E-mail of the Customer")] string? email
    ) =>
    serviceSample.GetCustomer(nome, email))
    .WithTags("Customers");

app.MapPost("api/v1/customer",
    [SwaggerOperation(Description = "Add a new Customer")][SwaggerResponse(201, "Created", typeof(CreatedResult))][SwaggerResponse(500, "Some Failure")][SwaggerResponse(400, "Bad Request", typeof(BadRequestResult))] (
        ServiceSample serviceSample,
        Customer customer
    ) =>
    Results.Created("", serviceSample.CreateCustomer(customer.Nome, customer.Email)))
    .WithTags("Customers")
    .Produces<CreatedResult>(StatusCodes.Status201Created)
    .ProducesProblem(StatusCodes.Status500InternalServerError);

app.Run();