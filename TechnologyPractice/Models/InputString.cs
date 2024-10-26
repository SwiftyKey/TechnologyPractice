using System.ComponentModel.DataAnnotations;

namespace TechnologyPractice.Models;

public class InputString
{
	[Required]
	[LowercaseEnglishLetters]
	public string Text { get; set; }
}
