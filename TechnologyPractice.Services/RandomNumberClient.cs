using Microsoft.Extensions.Options;
using System.Text.RegularExpressions;
using TechnologyPractice.Services.Config;

namespace TechnologyPractice.Services;

public class RandomNumberClient
{
	private readonly Regex _rg = new(@"\d+");
	private string Url { get; set; } = "";
	private readonly HttpClient _httpClient;

	public RandomNumberClient(IHttpClientFactory httpClientFactory, IOptions<AppConfig> options)
	{
		_httpClient = httpClientFactory.CreateClient();
		Url = options.Value.RandomApi;
	}

	public async Task<int> GetValue(int maxValue)
	{
		var response = await _httpClient.GetAsync(Url + maxValue);
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
