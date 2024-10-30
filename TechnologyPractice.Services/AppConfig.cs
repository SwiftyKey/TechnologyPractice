namespace TechnologyPractice.Services.Config;

public class AppConfig
{
	public string RandomApi { get; set; } = "";
	public Settings? Settings { get; set; }
}

public class Settings
{
	public ICollection<string>? BlackList { get; set; }
	public int ParallelLimit { get; set; }
}