using Microsoft.AspNetCore.Http;
using System.Net;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace SoftwareOne.BaseLine.Middleware.ResponseApi
{
    internal record ValidationResponse(bool IsValid, string Message);

    internal class SwoMiddlewareResponse : IMiddleware
    {
        public SwoMiddlewareResponse() { }

        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            var response = context.Response;
            response.ContentType = "application/json";
            response.StatusCode = (int)HttpStatusCode.OK;

            try
            {
                await next(context);
            }
            catch (Core.Exceptions.SwoFormNotAvaliableException exception)
            {
                await response.WriteAsync(JsonSerializer.Serialize(new ValidationResponse(false, exception.Message), new JsonSerializerOptions
                {
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                    DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingDefault
                }));
            }
            catch (Exception exception)
            {
                var element = SwoExceptionHelper.HandleException(exception);
                response.StatusCode = element.StatusCode;
                await response.WriteAsync(JsonSerializer.Serialize(element, new JsonSerializerOptions
                {
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                    DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingDefault
                }));
            }
        }
    }
}