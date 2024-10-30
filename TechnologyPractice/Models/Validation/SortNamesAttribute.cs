using System.ComponentModel.DataAnnotations;

namespace TechnologyPractice.Models.Validation;

public class SortNamesAttribute : ValidationAttribute
{
	private List<string> _names = new () { "QuickSort", "TreeSort" };

	public override bool IsValid(object? value)
	{
		if (_names.Contains((string) value))
			return true;

		ErrorMessage = $"Ожидаемые имена сортировок: {string.Join(", ", _names)}";
		return false;
	}
}
