using Domain.Exceptions;
using Microsoft.AspNetCore.Http;

namespace Infrastructure.Middlewares;

public class ExceptionHandlingMiddleware : IMiddleware
{
    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        try
        {
            await next(context);
        }
        catch (Exception e)
        {
            context.Response.StatusCode = 400; // Set the appropriate status code

            string errorMessage = e switch
            {
                UsernameTakenException usernameTaken => $"[400] {usernameTaken.GetType().Name}",
                EmailTakenException emailTaken => $"[400] {emailTaken.GetType().Name}",
                BadRequestException badRequest => $"Exception occurred - {badRequest.Message}",
                NotFoundException notFound => $"[404] {notFound.GetType().Name} - {notFound.Message}",
                _ => "[Middleware] An unexpected error occurred."
            };

            await context.Response.WriteAsync(errorMessage);
        }
    }
}