using System.Diagnostics;
using System.Text.RegularExpressions;
using TechnologyPractice.Services.Sorts;

namespace TechnologyPractice.Services;

public static class StringHandler
{
	public static bool IsEven(int length) => length % 2 == 0;

	public static string ReverseEvenString(string str)
	{
		string firstPart = str[..(str.Length / 2)];
		string secondPart = str[(str.Length / 2)..];

		return new string(firstPart.Reverse().Concat(secondPart.Reverse()).ToArray());
	}

	public static string ReverseOddString(string str)
	{
		return new string(str.Reverse().ToArray()) + str;
	}

	public static string Reverse(string source)
	{
		string result;

		if (IsEven(source.Length)) result = ReverseEvenString(source);
		else result = ReverseOddString(source);

		return result;
	}

	public static Dictionary<char, int> GetCountSymbols(string text)
	{
		var counter = new Dictionary<char, int>();
		foreach (char c in text.ToHashSet())
			counter[c] = text.Count(x => x == c);

		return counter;
	}

	public static string GetLargestSubstring(string text)
	{
		Regex rg = new(@"[aeiouy][a-z]*[aeiouy]|[aeiouy]");
		return rg.Match(text).Value;
	}

	public static string Sort(string text, string sortName)
	{
		var sort = (ISort)Activator.CreateInstance(Type.GetType("TechnologyPractice.Services.Sorts." + sortName));
		return sort.Sorting(text);
	}

	public static async Task<string> Truncate(string text, HttpClient client)
	{

		var index = await RandomNumberClient.GetValue(text.Length, client);
		Debug.WriteLine($"Random index: {index}");
		return text.Remove(index, 1);
	}
}
