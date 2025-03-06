namespace API.Configurations
{
    public static class ApplicationConfigurations
    {
        public static WebApplicationBuilder AddApplication(this WebApplicationBuilder builder)
        {
            // all configurations for application library should be there



            builder.Services.AddHttpContextAccessor();
            builder.Services.AddHttpClient();

            return builder;
        }
    }
}
