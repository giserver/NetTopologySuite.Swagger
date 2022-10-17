#define Swashbuckle
#define NSwag

global using Microsoft.AspNetCore.Mvc;
global using NetTopologySuite.IO.Converters;
global using NetTopologySuite.Features;
global using NetTopologySuite.Geometries;
using NetTopologySuite.Swagger;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.Converters.Add(new GeoJsonConverterFactory());
});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

#if Swashbuckle
builder.Services.AddSwaggerGen(options =>
{
    options.AddGeometry(GeoSerializeType.Geojson);
});
#elif NSwag
builder.Services.AddSwaggerDocument(settings =>
{
    settings.TypeMappers.AddGeometry(GeoSerializeType.Geojson);
});
#endif

var app = builder.Build();

// Configure the HTTP request pipeline.

#if Swashbuckle
app.UseSwagger(setupAction: options => { });
app.UseSwaggerUI();
#elif NSwag
app.UseOpenApi();
app.UseSwaggerUi3();
#endif

app.UseAuthorization();

app.MapControllers();

app.Run();
