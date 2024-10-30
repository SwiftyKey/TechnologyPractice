using System.Text.Json;
using TechnologyPractice.Services;

namespace TechnologyPractice.Middleware;

public class BlackListMiddleware
{
	private readonly RequestDelegate _next;

	public BlackListMiddleware(RequestDelegate next)
	{
		_next = next;
	}

	public async Task InvokeAsync(HttpContext context, BlackListService blackListService)
	{
		var text = context.Request.Query["Text"];

		if (blackListService.Check(text))
		{
			context.Response.StatusCode = StatusCodes.Status400BadRequest;
			context.Response.ContentType = "application/json";
			await context.Response.WriteAsync
			(
				JsonSerializer.Serialize
				(
					$"Введенная строка содержится в черном списке: {blackListService.BlackListToString()}"
				)
			);
			return;
		}

		await _next(context);
	}
}
