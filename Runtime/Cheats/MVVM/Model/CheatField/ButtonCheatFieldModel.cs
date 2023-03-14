namespace EM.Assistant
{

using System;

public sealed class ButtonCheatFieldModel : ICheatFieldModel
{
	public readonly string Label;

	public readonly Action Action;

	#region CheatButton

	public ButtonCheatFieldModel(string label,
		Action action)
	{
		Label = label;
		Action = action;
	}

	#endregion
}
}