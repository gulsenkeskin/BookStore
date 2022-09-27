using System.Diagnostics;
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

            //requeste girip çıktığı süreyi hesaplamak için
            var watch = Stopwatch.StartNew();

            //request log
            string message = "[Request] HTTP" + context.Request.Method + " - " + context.Request.Path;
            Console.WriteLine(message);

            //bi sonraki middleware i çağırmak 
            await _next(context);
            watch.Stop();

            //response log
            message = "[Response] HTTP " + context.Request.Method + " - " + context.Request.Path + " responded" + context.Response.StatusCode + " in" + watch.Elapsed.TotalMilliseconds + "ms";
            Console.WriteLine(message);


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