namespace TechnologyPractice.Models;

public class ResponseModel
{
	public string ProcessedString { get; set; }
	public IDictionary<char, int> Counter { get; set; }
	public string LargestSubstring { get; set; }
	public string SortedString { get; set; }
	public string TruncatedString { get; set; }
}
