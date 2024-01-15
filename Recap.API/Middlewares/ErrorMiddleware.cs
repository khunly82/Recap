using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Recap.BLL.Exceptions;

namespace Recap.API.Middlewares
{
    public class ErrorMiddleware(RequestDelegate next)
    {
        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await next(context);
            }
            catch (BusinessException ex)
            {
                context.Response.StatusCode = 400;
                context.Response.ContentType = "application/json";
                await context.Response.WriteAsync(JsonConvert.SerializeObject(new { Error = ex.Message, Type = "Business" }));
            }
            catch (DbUpdateException ex)
            {
                context.Response.StatusCode = 500;
                context.Response.ContentType = "application/json";
                await context.Response.WriteAsync(JsonConvert.SerializeObject(new { 
                    ex.Message, Error = "Erreur de connexion DB" , Type = "Database" }));
            }
            catch (EntityNotFoundException)
            {
                context.Response.StatusCode = 404;
                context.Response.ContentType = "application/json";
                
            }
        }
    }
}
