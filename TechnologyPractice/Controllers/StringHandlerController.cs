using Microsoft.AspNetCore.Mvc;
using TechnologyPractice.Models;
using TechnologyPractice.Services;

namespace TechnologyPractice.Controllers;

[Route("api/controller")]
[ApiController]
public class StringHandlerController : Controller
{
	[HttpGet()]
	[ProducesResponseType(StatusCodes.Status400BadRequest)]
	public async Task<ActionResult<string>> Get([FromQuery] RequestModel input, [FromServices] IHttpClientFactory httpClientFactory)
	{
		var processedString = StringHandler.Reverse(input.Text);
		var httpClient = httpClientFactory.CreateClient();

		var response = new ResponseModel()
		{
			ProcessedString = processedString,
			Counter = StringHandler.GetCountSymbols(processedString),
			LargestSubstring = StringHandler.GetLargestSubstring(processedString),
			SortedString = StringHandler.Sort(processedString, input.SortName),
			TruncatedString = await StringHandler.Truncate(processedString, httpClient)
		};
		return Ok(response);
	}
}
