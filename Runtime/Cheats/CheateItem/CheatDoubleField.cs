namespace EM.Assistant
{

public sealed class CheatDoubleField : ICheatItem
{
	public double Value;

	public readonly string Label;

	#region CheatDoubleField

	public CheatDoubleField(string label,
		double defaultValue = 0)
	{
		Label = label;
		Value = defaultValue;
	}

	#endregion
}

}