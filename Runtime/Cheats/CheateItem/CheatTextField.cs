namespace EM.Assistant
{

public sealed class CheatTextField : ICheatItem
{
	public string Value;

	public readonly string Label;

	#region CheatTextField

	public CheatTextField(string label,
		string defaultValue = "")
	{
		Label = label;
		Value = defaultValue;
	}

	#endregion
}

}