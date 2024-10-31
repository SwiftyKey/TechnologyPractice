using System.ComponentModel.DataAnnotations;
using TechnologyPractice.Models;
using TechnologyPractice.Services;
using TechnologyPractice.Services.Sorts;

namespace TechnologyPractice.Tests;

[TestFixture]
public class Tests
{
	private readonly StringHandler _stringHandler = new (null);

	[TestCase("a", "aa", TestName = "IfStringLengthIsOne_ReturnsDoubledString")]
	[TestCase("", "", TestName = "IfStringIsEmpty_ReturnsEmptyString")]
	[TestCase("ab", "ab", TestName = "IfStringLengthIsTwo_ReturnsSourceString")]
	[TestCase("abcdef", "cbafed", TestName = "IfStringLengthIsEven_ReturnsExpected")]
	[TestCase("abcde", "edcbaabcde", TestName = "IfStringLengthIsOdd_ReturnsExpected")]
	public void ReverseTest(string text, string expected)
	{
		var result = _stringHandler.Reverse(text);

		Assert.That(result, Is.EqualTo(expected));
	}

	[TestCaseSource(typeof(TestsData), nameof(TestsData.IncorrectChars))]
	public void IncorrectCharsTest(string text, string errorMessage)
	{
		var model = new RequestModel() { Text = text, SortName = "TreeSort" };
		var context = new ValidationContext(model);
		var results = new List<ValidationResult>();

		Validator.TryValidateObject(model, context, results, true);

		foreach(var error in results)
			Assert.That(error.ErrorMessage, Is.EqualTo(errorMessage));
	}

	[TestCaseSource(typeof(TestsData), nameof(TestsData.Counter))]
	public void CounterTest(string text, Dictionary<char, int> counter)
	{
		var processString = _stringHandler.Reverse(text);
		var result = _stringHandler.GetCountSymbols(processString);

		Assert.That(result, Is.EqualTo(counter));
	}

	[TestCase("bcda", "a", TestName = "IfStringLengthIsEvenWithOneVowel_ReturnsVowelChar")]
	[TestCase("a", "aa", TestName = "IfStringLengthIsOneWithOneVowel_ReturnsDoubledVowelChar")]
	[TestCase("bcdaf", "adcbbcda", TestName = "IfStringLengthIsOddWithOneVowel_ReturnsExpectedSubstring")]
	[TestCase("abcda", "adcbaabcda", TestName = "IfStringLengthIsEvenWithVowelAtEnds_ReturnsExpectedSubstring")]
	[TestCase("abybfe", "ybae", TestName = "IfStringLengthIsEven_ReturnsExpectedSubstring")]
	public void SubstringTest(string text, string expected)
	{
		var processString = _stringHandler.Reverse(text);
		var result = _stringHandler.GetLargestSubstring(processString);

		Assert.That(result, Is.EqualTo(expected));
	}

	[TestCaseSource(typeof(TestsData), nameof(TestsData.Sorts))]
	public void SortTest(string text, ISort sort, string expected)
	{
		var processString = _stringHandler.Reverse(text);
		var result = new string(sort.Sorting(processString));

		Assert.That(result, Is.EqualTo(expected));
	}
}