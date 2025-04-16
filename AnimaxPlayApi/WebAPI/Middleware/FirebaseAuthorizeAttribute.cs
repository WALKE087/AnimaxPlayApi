using AnimaxPlayApi.Infrastructure.ExternalServices.Firebase;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Threading.Tasks;

namespace AnimaxPlayApi.WebAPI.Middleware
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class FirebaseAuthorizeAttribute : Attribute, IAsyncActionFilter
    {
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            var firebaseService = context.HttpContext.RequestServices.GetService(typeof(FirebaseAuthService)) as FirebaseAuthService;

            var token = context.HttpContext.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();

            if (string.IsNullOrEmpty(token))
            {
                context.Result = new UnauthorizedResult();
                return;
            }

            try
            {
                var decodedToken = await firebaseService.VerifyTokenAsync(token);
                context.HttpContext.Items["UserId"] = decodedToken.Uid;
                await next();
            }
            catch
            {
                context.Result = new UnauthorizedResult();
            }
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class FirebaseAuthorizeAttributeExtensions
    {
        public static IApplicationBuilder UseFirebaseAuthorizeAttribute(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<FirebaseAuthorizeAttribute>();
        }
    }
}
