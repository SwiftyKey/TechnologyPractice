namespace TechnologyPractice.Services.Sorts;

public class QuickSort : ISort
{
	private static int Partition(char[] data, int start, int end)
	{
		var pivot = data[end];
		var storeIndex = start;

		for (int i = start; i < end; i++)
			if (data[i] < pivot)
			{
				(data[i], data[storeIndex]) = (data[storeIndex], data[i]);
				storeIndex++;
			}

		(data[end], data[storeIndex]) = (data[storeIndex], data[end]);

		return storeIndex;
	}

	private static char[] Sorting(char[] data, int start, int end)
	{
		if (start >= end) return data;

		var pivotIndex = Partition(data, start, end);
		Sorting(data, start, pivotIndex - 1);
		Sorting(data, pivotIndex + 1, end);

		return data;
	}

	public string Sorting(string data)
	{
		return new string(Sorting(data.ToArray(), 0, data.Length - 1));
	}

	public override string ToString() => nameof(QuickSort);
}
