namespace EM.Assistant
{

public sealed class CheatLongField : ICheatItem
{
	public long Value;

	public readonly string Label;

	#region CheatLongField

	public CheatLongField(string label,
		long defaultValue = 0)
	{
		Label = label;
		Value = defaultValue;
	}

	#endregion
}

}