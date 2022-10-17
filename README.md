# NetTopologySuite.Swagger
NetTopologySuite JsonSerialize In Swagger

## Usage  
* install
```
    dotnet add package NetTopologySuite.Swagger    
```

* integration  
``` CSharp
    // Swashbuckle
    builder.Services.AddSwaggerGen(options =>
    {
        options.AddGeometry(GeoSerializeType.Geojson);
    });
    ...
    app.UseSwagger(setupAction: options => { });
    app.UseSwaggerUI();


    // NSwag
    builder.Services.AddSwaggerDocument(settings =>
    {
        settings.TypeMappers.AddGeometry(GeoSerializeType.Geojson);
    });
    ...
    app.UseOpenApi();
    app.UseSwaggerUi3();

```