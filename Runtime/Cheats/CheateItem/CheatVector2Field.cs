namespace EM.Assistant
{

using UnityEngine;

public sealed class CheatVector2Field : ICheatItem
{
	public Vector2 Value;

	public readonly string Label;

	#region CheatVector2Field

	public CheatVector2Field(string label,
		Vector2 defaultValue = new())
	{
		Label = label;
		Value = defaultValue;
	}

	#endregion
}

}