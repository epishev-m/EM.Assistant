namespace EM.Assistant
{

using UnityEngine;

public sealed class CheatRectField : ICheatItem
{
	public Rect Value;

	public readonly string Label;

	#region CheatRectField

	public CheatRectField(string label,
		Rect defaultValue = new())
	{
		Label = label;
		Value = defaultValue;
	}

	#endregion
}

}