using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace OptionsPattern
{
    public static class Register
    {
        public static IConfiguration Configuration;

        public static void ConfigureServices(IServiceCollection serviceCollection)
        {
            Configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetParent(AppContext.BaseDirectory).FullName)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .Build();

            serviceCollection.AddOptions();
            serviceCollection.Configure<ApiGatewayOption>(Configuration.GetSection("ApiGateway:Url"));
        }
    }
}
