namespace EM.Assistant
{

using UnityEngine;

public sealed class CheatVector3Field : ICheatItem
{
	public Vector3 Value;

	public readonly string Label;

	#region CheatVector3Field

	public CheatVector3Field(string label,
		Vector3 defaultValue = new())
	{
		Label = label;
		Value = defaultValue;
	}

	#endregion
}

}