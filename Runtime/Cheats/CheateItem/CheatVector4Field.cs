namespace EM.Assistant
{

using UnityEngine;

public sealed class CheatVector4Field : ICheatItem
{
	public Vector4 Value;

	public readonly string Label;

	#region CheatVector4Field

	public CheatVector4Field(string label,
		Vector4 defaultValue = new())
	{
		Label = label;
		Value = defaultValue;
	}

	#endregion
}

}