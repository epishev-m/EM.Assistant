namespace EM.Assistant
{

public sealed class CheatFloatField : ICheatItem
{
	public float Value;

	public readonly string Label;

	#region CheatFloatField

	public CheatFloatField(string label,
		float defaultValue = 0)
	{
		Label = label;
		Value = defaultValue;
	}

	#endregion
}

}