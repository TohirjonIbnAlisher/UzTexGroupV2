namespace UzTexGroupV2.MIddlewares;

public class CorsPolicy : IMiddleware
{
    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        context.Response.Headers.Add("Access-Control-Allow-Origin", "*");
        await next(context);
    }
}