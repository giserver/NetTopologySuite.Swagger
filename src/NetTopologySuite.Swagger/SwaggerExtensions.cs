using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.DependencyInjection;
using NJsonSchema;
using NJsonSchema.Generation.TypeMappers;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace NetTopologySuite.Swagger
{
    public static class SwaggerExtensions
    {
        public static void AddGeometry(this ICollection<ITypeMapper> mappers, GeoSerializeType type)
        {
            var geoMapper = type == GeoSerializeType.Geojson
                ? GeometryMappers.GeometryGeojsonMapper
                : GeometryMappers.GeometryWktMapper;

            var jsonObjectType = type == GeoSerializeType.Geojson ? JsonObjectType.Object : JsonObjectType.String;

            foreach (var item in 
                     geoMapper.Where(item => mappers.All(x => x.MappedType != item.Key)))
            {
                mappers.Add(new PrimitiveTypeMapper(item.Key,
                    schema4 =>
                    {
                        schema4.Type = jsonObjectType;
                        schema4.Example = item.Value;
                    }));
            }
        }

        public static void AddGeometry(this SwaggerGenOptions options, GeoSerializeType type)
        {
            switch (type)
            {
                case GeoSerializeType.Geojson:
                    options.SchemaFilter<SwashbuckleGeojsonSchemaFilter>();
                    break;
                case GeoSerializeType.Wkt:
                    options.SchemaFilter<SwashbuckleWktSchemaFilter>();
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(type), type, null);
            }
        }
    }
}