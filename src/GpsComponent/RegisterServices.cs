using Microsoft.Extensions.DependencyInjection;

namespace GpsComponent;

public static class RegisterServices
{
    public static IServiceCollection AddBlazorLeafletServices(this IServiceCollection services)
    {
        services.AddScoped<JsInterop>();
        return services;
    }
}
