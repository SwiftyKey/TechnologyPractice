using Microsoft.Extensions.Options;
using TechnologyPractice.Services.Config;

namespace TechnologyPractice.Services;

public class BlackListService
{
	private readonly Settings _settings;

	public BlackListService(IOptions<Settings> options)
	{
		_settings = options.Value;
	}

	public bool Check(string text) => _settings.BlackList.Contains(text);

	public string BlackListToString() => string.Join(", ", _settings.BlackList);
}
