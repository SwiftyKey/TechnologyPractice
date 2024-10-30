using System.Text.Json;
using TechnologyPractice.Services;

namespace TechnologyPractice.Middleware;

public class RequestLimitMiddleware
{
	private readonly RequestDelegate _next;

	public RequestLimitMiddleware(RequestDelegate next)
	{
		_next = next;
	}

	public async Task InvokeAsync(HttpContext context, RequestLimitService requestLimitService)
	{
		if (! await requestLimitService.TryAcquireAsync())
		{
			context.Response.StatusCode = StatusCodes.Status503ServiceUnavailable;
			context.Response.ContentType = "application/json";
			await context.Response.WriteAsync
			(
				JsonSerializer.Serialize($"Превышен лимит пользователей")
			);
			return;
		}

		try
		{
			await _next(context);
		}
		finally
		{
			requestLimitService.Release();
		}
	}
}