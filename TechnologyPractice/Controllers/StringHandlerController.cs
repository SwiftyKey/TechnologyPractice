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
	public ActionResult<string> Get([FromQuery] RequestModel input)
	{
		var processedString = StringHandler.Reverse(input.Text);
		var response = new ResponseModel()
		{
			ProcessedString = processedString,
			Counter = StringHandler.GetCountSymbols(processedString)
		};
		return Ok(response);
	}
}
