using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace TechnologyPractice.Models.Validation;

public class LowercaseEnglishLettersAttribute : ValidationAttribute
{
	private readonly Regex _incorrectLetters = new (@"[^a-z]");

	public override bool IsValid(object? value)
	{
		var letters = _incorrectLetters.Matches((string)value);

		if (letters.Count == 0)
			return true;

		ErrorMessage = $"Некорректные символы: {string.Join(", ", letters.Select(x => x.Value).ToList())}";
		return false;
	}
}
