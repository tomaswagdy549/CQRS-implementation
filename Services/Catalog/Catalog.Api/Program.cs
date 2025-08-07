using Catalog.Application;
using Catalog.Infrastructure;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();
// Infrastructure Layer register 
builder.Services.AddCatalogInfrastructure();

// Application Layer register 
builder.Services.AddCatalogServices();


// Api versioning 
builder.Services.AddApiVersioning(options =>
{
    options.ReportApiVersions = true;
    options.AssumeDefaultVersionWhenUnspecified = true;
    options.DefaultApiVersion = new Asp.Versioning.ApiVersion(1, 0);
});

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

var app = builder.Build();


// seeding data
//using (var scope = app.Services.CreateScope())
//{
//    var context = scope.ServiceProvider.GetRequiredService<ICatalogContext>();
//    await CatalogContextSeed.SeedAsync(context);
//}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Catalog API v1"));
}

app.UseAuthorization();

app.MapControllers();

app.Run();
