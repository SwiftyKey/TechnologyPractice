using System.Diagnostics;
using System.Text.RegularExpressions;
using TechnologyPractice.Services.Sorts;

namespace TechnologyPractice.Services;

public class StringHandler
{
	private readonly RandomNumberClient _randomNumberClient;

	public StringHandler(RandomNumberClient randomNumberClient)
	{
		_randomNumberClient = randomNumberClient;
	}

	public bool IsEven(int length) => length % 2 == 0;

	public string ReverseEvenString(string str)
	{
		string firstPart = str[..(str.Length / 2)];
		string secondPart = str[(str.Length / 2)..];

		return new string(firstPart.Reverse().Concat(secondPart.Reverse()).ToArray());
	}

	public string ReverseOddString(string str)
	{
		return new string(str.Reverse().ToArray()) + str;
	}

	public string Reverse(string source)
	{
		string result;

		if (IsEven(source.Length)) result = ReverseEvenString(source);
		else result = ReverseOddString(source);

		return result;
	}

	public Dictionary<char, int> GetCountSymbols(string text)
	{
		var counter = new Dictionary<char, int>();
		foreach (char c in text.ToHashSet())
			counter[c] = text.Count(x => x == c);

		return counter;
	}

	public string GetLargestSubstring(string text)
	{
		Regex rg = new(@"[aeiouy][a-z]*[aeiouy]|[aeiouy]");
		return rg.Match(text).Value;
	}

	public string Sort(string text, string sortName)
	{
		var sort = (ISort)Activator.CreateInstance(Type.GetType("TechnologyPractice.Services.Sorts." + sortName));
		return sort.Sorting(text);
	}

	public async Task<string> Truncate(string text)
	{
		var index = await _randomNumberClient.GetValue(text.Length);
		Debug.WriteLine($"Random index: {index}");
		return text.Remove(index, 1);
	}
}
