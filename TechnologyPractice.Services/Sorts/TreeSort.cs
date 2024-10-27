namespace TechnologyPractice.Services.Sorts;

internal class BinaryTree
{
	public char Data { get; set; }
	public BinaryTree? Left { get; set; } = null;
	public BinaryTree? Right { get; set; } = null;

	public BinaryTree(char data) => Data = data;

	public void Insert(BinaryTree node)
	{
		if (node.Data <= Data)
		{
			if (Left == null) Left = node;
			else Left.Insert(node);
		}
		else
		{
			if (Right == null) Right = node;
			else Right.Insert(node);
		}
	}

	public char[] Transform(ICollection<char>? elements = null)
	{
		elements ??= new List<char>();

		Left?.Transform(elements);
		elements.Add(Data);
		Right?.Transform(elements);

		return elements.ToArray();
	}
}

public class TreeSort : ISort
{
	public string Sorting(string data)
	{
		var tree = new BinaryTree(data[0]);
		foreach (var item in data[1..])
			tree.Insert(new BinaryTree(item));

		return new string(tree.Transform());
	}

	public override string ToString() => nameof(TreeSort);
}
