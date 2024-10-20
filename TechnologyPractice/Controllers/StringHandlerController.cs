using Microsoft.AspNetCore.Mvc;
using TechnologyPractice.Services;

namespace TechnologyPractice.Controllers;

[Route("api/controller")]
[ApiController]
public class StringHandlerController : Controller
{
	[HttpGet()]
	[ProducesResponseType(StatusCodes.Status400BadRequest)]
	public ActionResult<string> Get(string input)
	{
		return Ok(StringHandler.Reverse(input));
	}
}
