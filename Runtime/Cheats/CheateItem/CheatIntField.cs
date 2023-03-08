namespace EM.Assistant
{

public sealed class CheatIntField : ICheatItem
{
	public int Value;

	public readonly string Label;

	#region CheatIntField

	public CheatIntField(string label,
		int defaultValue = 0)
	{
		Label = label;
		Value = defaultValue;
	}

	#endregion
}

}