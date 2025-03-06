using Asp.Versioning;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace API.Configurations
{
    public static class ApiConfigurations
    {
        public static WebApplicationBuilder ConfigureAPI(this WebApplicationBuilder builder)
        {
            // Token validation

            builder.Services.AddCors();
            builder.Services.AddControllers()
                .AddJsonOptions(opt =>
                {
                    opt.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
                    opt.JsonSerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.SnakeCaseLower;
                    opt.JsonSerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.Never;
                    opt.JsonSerializerOptions.WriteIndented = true;
                    opt.JsonSerializerOptions.Encoder = JavaScriptEncoder.Default;
                    opt.JsonSerializerOptions.AllowTrailingCommas = false;
                    opt.JsonSerializerOptions.NumberHandling = JsonNumberHandling.AllowReadingFromString;
                });

            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddApiVersioning(options =>
                {
                    options.ReportApiVersions = true;
                    options.DefaultApiVersion = new ApiVersion(1, 0);
                    options.AssumeDefaultVersionWhenUnspecified = true;
                })
                .AddApiExplorer(options =>
                {
                    options.GroupNameFormat = "'v'VVV";
                    options.SubstituteApiVersionInUrl = true;
                });

            builder.Services.AddHttpContextAccessor();

            return builder;
        }
    }
}