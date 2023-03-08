namespace EM.Assistant
{

public sealed class CheatSliderField : ICheatItem
{
	public readonly string Label;

	public readonly float LeftValue;

	public readonly float RightValue;

	public float Value;

	#region CheatSliderField

	public CheatSliderField(string label,
		float leftValue,
		float rightValue,
		float defaultValue = 0)
	{
		Label = label;
		LeftValue = leftValue;
		RightValue = rightValue;
		Value = defaultValue;
	}

	#endregion
}

}