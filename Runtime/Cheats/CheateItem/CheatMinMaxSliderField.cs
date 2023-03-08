namespace EM.Assistant
{

public sealed class CheatMinMaxSliderField : ICheatItem
{
	public readonly string Label;

	public readonly float MinLimit;

	public readonly float MaxLimit;

	public float MinValue;

	public float MaxValue;

	#region CheatMinMaxSliderField

	public CheatMinMaxSliderField(string label,
		float minLimit,
		float maxLimit)
	{
		Label = label;
		MinLimit = minLimit;
		MaxLimit = maxLimit;
		MinValue = MinLimit;
		MaxValue = MaxLimit;
	}

	#endregion
}

}