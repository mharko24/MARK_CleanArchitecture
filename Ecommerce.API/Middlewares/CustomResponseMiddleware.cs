using Ecommerce.Application.DTOs.Common;
using System.Text;
using System.Text.Json;

namespace Ecommerce.API.Middlewares
{
    public class CustomResponseMiddleware
    {
        private readonly RequestDelegate _next;
        public CustomResponseMiddleware(
            RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            var originalBodyStream = context.Response.Body;

            using var responseBody = new MemoryStream();
            context.Response.Body = responseBody;

            try
            {
                await _next(context);

                context.Response.Body.Seek(0, SeekOrigin.Begin);
                var responseText = await new StreamReader(context.Response.Body).ReadToEndAsync();
                context.Response.Body.Seek(0, SeekOrigin.Begin);

                var responseWrapper = new ResponseDto
                {
                    IsSuccess = context.Response.StatusCode is >= 200 and < 300,
                    StatusCode = context.Response.StatusCode,
                    Message = GetMessage(context.Response.StatusCode),
                    Data = TryParseJson(responseText)
                };

                var json = JsonSerializer.Serialize(responseWrapper);

                context.Response.ContentType = "appllication/json";
                context.Response.ContentLength = Encoding.UTF8.GetByteCount(json);
                context.Response.Body = originalBodyStream;

                await context.Response.WriteAsync(json);

            }
            catch(Exception ex)
            {
                context.Response.Body = originalBodyStream;
                context.Response.StatusCode = 500;

                var errorResponse = new ResponseDto
                {
                    IsSuccess = false,
                    StatusCode = 500,
                    Message = ex.Message,
                    Data = ex.Data
                };

                var json = JsonSerializer.Serialize(errorResponse);
                context.Response.ContentType = "application/json";
                await context.Response.WriteAsync(json);
            }
        }

        private static string GetMessage(int statusCode) =>
            statusCode switch
            {
                >= 200 and < 300 => "Request Successful",
                400 => "Bad Request",
                4001 => "Unauthorized",
                403 => "Forbidden",
                404 => "Not Found",
                >= 500 => "Internal Server Error",
                _ => "Request Completed"
            };

        private object TryParseJson(string responseText)
        {
            try
            {
                return JsonSerializer.Deserialize<object>(responseText);
            }
            catch
            {
                return responseText;
            }
        }
    }
}
