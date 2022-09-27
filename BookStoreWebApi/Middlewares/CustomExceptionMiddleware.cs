using Microsoft.AspNetCore.Http;

namespace BookStoreWebApi.Middlewares
{
    public class CustomExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        public CustomExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            string message = "[Request] HTTP" + context.Request.Method + " - " + context.Request.Path;
            Console.WriteLine(message);

            //bi sonraki middleware i çağırmak 
            await _next(context);


        }

    }

    //program.js içerisinde bu middleware i app.use diye kullanabilmek için extension yazmamız gerekir.

    public static class CustomExceptionMiddlewareExtension
    {
        public static IApplicationBuilder UseCustomExceptionMiddle(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<CustomExceptionMiddleware>();
        }
    }
}