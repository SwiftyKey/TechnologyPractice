using TechnologyPractice.Services.Sorts;

namespace TechnologyPractice.Tests;

public static class TestsData
{
	public static TestCaseData[] IncorrectChars { get; set; } =
	{
		new TestCaseData("AvfsfB", "Некорректные символы: A, B").SetName("Uppercase chars"),
		new TestCaseData("0ab1cb2", "Некорректные символы: 0, 1, 2").SetName("Numbers"),
		new TestCaseData("абыcb", "Некорректные символы: а, б, ы").SetName("Russian chars"),
		new TestCaseData("fa,_sfs;", "Некорректные символы: ,, _, ;").SetName("Other chars"),
		new TestCaseData("Ab9ыФи,s", "Некорректные символы: A, 9, ы, Ф, и, ,").SetName("All cases together")
	};

	public static TestCaseData[] Counter { get; set; } =
	{
		new TestCaseData("abfe", new Dictionary<char, int>
		{
			{ 'a', 1 },
			{ 'b', 1 },
			{ 'f', 1 },
			{ 'e', 1 }
		}).SetName("Counter for string with even length"),
		new TestCaseData("abbce", new Dictionary<char, int>
		{
			{ 'a', 2 },
			{ 'b', 4 },
			{ 'c', 2 },
			{ 'e', 2 }
		}).SetName("Counter for string with odd length")
	};

	public static TestCaseData[] Sorts { get; set; } =
	{
		new TestCaseData("bfeada", new QuickSort(), "aabdef").SetName("Sorting a string using QuickSort"),
		new TestCaseData("sjhfsa", new TreeSort(), "afhjss").SetName("Sorting a string using TreeSort")
	};
}
