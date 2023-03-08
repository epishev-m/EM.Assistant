namespace EM.Assistant
{

public sealed class CheatIntSliderField : ICheatItem
{
	public readonly string Label;

	public readonly int LeftValue;

	public readonly int RightValue;

	public int Value;

	#region CheatIntSliderField

	public CheatIntSliderField(string label,
		int leftValue,
		int rightValue,
		int defaultValue = 0)
	{
		Label = label;
		LeftValue = leftValue;
		RightValue = rightValue;
		Value = defaultValue;
	}

	#endregion
}

}