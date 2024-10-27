using System.Text.RegularExpressions;

namespace TechnologyPractice.Services;

public static class RandomNumberClient
{
	private static readonly Regex _rg = new(@"\d+");
	public static string Url { get; set; } = "http://www.randomnumberapi.com/api/v1.0/random?max=";

	public static async Task<int> GetValue(int maxValue, HttpClient client)
	{
		var response = await client.GetAsync(Url + maxValue);
		int value;

		if (response.IsSuccessStatusCode)
        {
			string result = await response.Content.ReadAsStringAsync();

			value = int.Parse(_rg.Match(result).Value);
		}
		else
			value = new Random().Next(maxValue);

		return value;
    }
}
