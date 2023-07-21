using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace SoftwareOne.BaseLine.Middleware
{
    public static class ServiceProviderExtensions
    {
        public static IServiceCollection AddMiddlewareResponseApi(this IServiceCollection services) => services
                    .AddExceptionMiddleware();

        public static IApplicationBuilder UseMiddlewareResponseApi(this IApplicationBuilder builder) => builder
                .UseExceptionMiddleware();

        internal static IServiceCollection AddExceptionMiddleware(this IServiceCollection services) => services
            .AddScoped<ResponseApi.SwoMiddlewareResponse>();

        internal static IApplicationBuilder UseExceptionMiddleware(this IApplicationBuilder app) => app
            .UseMiddleware<ResponseApi.SwoMiddlewareResponse>();
    }
}