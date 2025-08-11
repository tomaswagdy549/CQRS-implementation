using Catalog.Api.ActionFilters;
using Catalog.Application;
using Catalog.Infrastructure;
using Catalog.Presentation;
using Catalog.Presentation.MiddleWares;
var builder = WebApplication.CreateBuilder(args);


// Infrastructure Layer register 
builder.Services.AddCatalogInfrastructure();

// Application Layer register 
builder.Services.AddCatalogServices();

// Presentation Layer register 
builder.Services.AddCatalogPresentation();


builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
    {
        Title = "Catalog API",
        Version = "v1",
        Description = "Microservices API for managing product catalog",
        Contact = new Microsoft.OpenApi.Models.OpenApiContact
        {
            Name = "Reyad Elkomy",
            Email = "reyaadelkomy@gmail.com"
        }
    });
});
builder.Services.AddOpenApi();
builder.Services.AddControllers(options =>
{
    options.Filters.Add<TimePerformanceMeterActionFilter>();
});
var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwaggerUI();
    app.UseSwagger();
}
app.UseAuthorization();

app.MapControllers();
app.UseMiddleware<GlobalExceptionHandlerMiddleWare>();
app.Run();
