using Microsoft.Extensions.Options;
using TechnologyPractice.Services.Config;

namespace TechnologyPractice.Services;

public class RequestLimitService
{
	private static SemaphoreSlim _semaphore;

	public RequestLimitService(IOptions<Settings> options)
	{
		_semaphore = new SemaphoreSlim(options.Value.ParallelLimit);
	}

	public async Task<bool> TryAcquireAsync() => await _semaphore.WaitAsync(0);

	public void Release() => _semaphore.Release();
}
