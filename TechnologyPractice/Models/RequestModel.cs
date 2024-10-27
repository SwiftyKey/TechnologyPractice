using System.ComponentModel.DataAnnotations;
using TechnologyPractice.Models.Validation;

namespace TechnologyPractice.Models;

public class RequestModel
{
	[Required]
	[LowercaseEnglishLetters]
	public string Text { get; set; }

	[Required]
	[SortNames]
	public string SortName { get; set; }
}
