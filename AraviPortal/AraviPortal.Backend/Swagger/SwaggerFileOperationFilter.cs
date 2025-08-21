using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace AraviPortal.Backend.Swagger;

public class SwaggerFileOperationFilter : IOperationFilter
{
    public void Apply(OpenApiOperation operation, OperationFilterContext context)
    {
        var fileUploadMimeTypes = new[] { "multipart/form-data" };

        if (operation.RequestBody == null || operation.RequestBody.Content == null)
        {
            return;
        }

        var formFileParameter = context.ApiDescription.ActionDescriptor.Parameters
            .Where(p => p.ParameterType == typeof(IFormFile))
            .FirstOrDefault();

        if (formFileParameter == null)
        {
            return;
        }

        if (operation.RequestBody.Content.Any(c => fileUploadMimeTypes.Contains(c.Key)))
        {
            var schema = new OpenApiSchema
            {
                Type = "object",
                Properties =
                {
                    ["file"] = new OpenApiSchema
                    {
                        Type = "string",
                        Format = "binary",
                        Description = "File to upload",
                    }
                },
                Required = new HashSet<string> { "file" }
            };

            operation.RequestBody.Content[fileUploadMimeTypes.First()] = new OpenApiMediaType
            {
                Schema = schema
            };
        }
    }
}