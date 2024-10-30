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
	public async Task<ActionResult<string>> Get
	(
		[FromQuery] RequestModel input,
		[FromServices] StringHandler stringHandler
	)
	{
		var processedString = stringHandler.Reverse(input.Text);

		var response = new ResponseModel()
		{
			ProcessedString = processedString,
			Counter = stringHandler.GetCountSymbols(processedString),
			LargestSubstring = stringHandler.GetLargestSubstring(processedString),
			SortedString = stringHandler.Sort(processedString, input.SortName),
			TruncatedString = await stringHandler.Truncate(processedString)
		};
		return Ok(response);
	}
}
