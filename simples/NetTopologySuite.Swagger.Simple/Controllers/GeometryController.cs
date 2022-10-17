namespace NetTopologySuite.Swagger.Simple.Controllers;

[ApiController]
[Microsoft.AspNetCore.Components.Route("api/geo")]
public class GeometryController : ControllerBase
{
    [HttpPost("point")]
    public Point CreatePoint(Point point) => point;

    [HttpPost("multi_point")]
    public MultiPoint CreateMultiPoint(MultiPoint points) => points;
    
    [HttpPost("line")]
    public LineString CreateLineString(LineString line) => line;

    [HttpPost("multi_line")]
    public MultiLineString CreateMultiLineString(MultiLineString lines) => lines;

    [HttpPost("polygon")]
    public Polygon CreatePolygon(Polygon polygon) => polygon;

    [HttpPost("multi_polygon")]
    public MultiPolygon CreateMultiPolygon(MultiPolygon polygons) => polygons;

    [HttpPost("feature_collection")]
    public FeatureCollection CreateFeatureCollection(FeatureCollection features) => features;
}