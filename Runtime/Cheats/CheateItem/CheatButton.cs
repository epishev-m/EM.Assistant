namespace EM.Assistant
{

using System;

public sealed class CheatButton : ICheatItem
{
	public readonly string Label;

	public readonly Action Action;

	#region CheatButton

	public CheatButton(string label,
		Action action)
	{
		Label = label;
		Action = action;
	}

	#endregion
}
}