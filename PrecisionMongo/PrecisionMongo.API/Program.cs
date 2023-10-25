using Microsoft.OpenApi.Models;
using PrecisionMongo.API.Helpers;
using PrecisionMongo.Core.Entities;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDependencies(builder.Configuration);

builder.Services.AddOutputCache(options =>
{
    options.AddPolicy("todoCachePolicy", builder =>
    {
        builder
            .Tag("tag-todo")
            .Expire(TimeSpan.FromMinutes(2));
    });
});

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options=>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "Todo Backend",
        Description = "Backend for Todo project",
        
    });
    var xmlDocumentationFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlDocumentationFile));
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseOutputCache();

app.UseAuthorization();

app.MapControllers();

app.Run();
