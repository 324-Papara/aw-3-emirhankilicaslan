using System.Text;
using Azure.Core;

namespace Para.Api.Middleware;

public class RequestResponseLoggerMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<RequestResponseLoggerMiddleware> _logger;

    public RequestResponseLoggerMiddleware(RequestDelegate next, ILogger<RequestResponseLoggerMiddleware> logger)
    {
        _next = next;
        _logger = logger;
    }

    public async Task Invoke(HttpContext httpContext)
    {
        //Request
        httpContext.Request.EnableBuffering();
        var buffer = new byte[Convert.ToInt32(httpContext.Request.ContentLength)];
        await httpContext.Request.Body.ReadAsync(buffer.AsMemory(0, buffer.Length));
        var requestBody = Encoding.UTF8.GetString(buffer);
        httpContext.Request.Body.Position = 0;
        _logger.LogInformation($"Request Body: {requestBody}");

        var originalBodyStream = httpContext.Response.Body;
        using var response= new MemoryStream();
        httpContext.Response.Body = response;

        await _next(httpContext);
        
        //Response
        httpContext.Response.Body.Seek(0, SeekOrigin.Begin);
        var responseBody = await new StreamReader(httpContext.Response.Body).ReadToEndAsync();
        httpContext.Response.Body.Seek(0, SeekOrigin.Begin);
        
        _logger.LogInformation($"Status Code: {httpContext.Response.StatusCode}");
        _logger.LogInformation($"Response Body: {responseBody}");

        await response.CopyToAsync(originalBodyStream);
    }

    private async Task LogRequest(HttpContext context)
    {
        context.Request.EnableBuffering();
        var buffer = new byte[Convert.ToInt32(context.Request.ContentLength)];
        await context.Request.Body.ReadAsync(buffer.AsMemory(0, buffer.Length));
        var requestBody = Encoding.UTF8.GetString(buffer);
        context.Request.Body.Position = 0;

        _logger.LogInformation("Incoming Request:");
        _logger.LogInformation($"Scheme: {context.Request.Scheme}");
        _logger.LogInformation($"Host: {context.Request.Host}");
        _logger.LogInformation($"Path: {context.Request.Path}");
        _logger.LogInformation($"QueryString: {context.Request.QueryString}");
        _logger.LogInformation($"Request Body: {requestBody}");
    }

    private async Task LogResponse(HttpContext context)
    {
        context.Response.Body.Seek(0, SeekOrigin.Begin);
        var responseBody = await new StreamReader(context.Response.Body).ReadToEndAsync();
        context.Response.Body.Seek(0, SeekOrigin.Begin);

        _logger.LogInformation("Outgoing Response:");
        _logger.LogInformation($"Status Code: {context.Response.StatusCode}");
        _logger.LogInformation($"Response Body: {responseBody}");
    }
}