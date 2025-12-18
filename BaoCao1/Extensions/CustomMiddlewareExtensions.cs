using BaoCao1.Services.Base;

namespace BaoCao1.Extensions
{

    public class CustomAuthentication
    {
        private readonly RequestDelegate _next;
        public CustomAuthentication(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
           var userId = UserContext.getUserId(context);
            if (userId <= 0)
            {
                if(!context.Request.Path.StartsWithSegments("/Accounts/Login") && !context.Request.Path.StartsWithSegments("/Accounts/Logout"))  
                {
                    context.Response.Redirect("/Accounts/Login");
                    return;
                }
            }

            await _next(context);
        }
    }

    public static class CustomMiddlewareExtensions
    {
        public static IApplicationBuilder UseCustomAuthentication(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<CustomAuthentication>();
        }
    }
}
