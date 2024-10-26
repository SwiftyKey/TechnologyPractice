using System.ComponentModel.DataAnnotations;

namespace TechnologyPractice.Models;

public class RequestModel
{
	[Required]
	[LowercaseEnglishLetters]
	public string Text { get; set; }
}
