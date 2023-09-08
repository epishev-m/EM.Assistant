namespace EM.Assistant.Editor.Legacy
{

using UnityEditor;
using UnityEditor.AnimatedValues;

public sealed class AssistantComponentGroupBox : IAssistantComponent
{
	private readonly IAssistantComponent _component;

	private readonly AnimBool _showExtraFields = new(false);

	#region IAssistantWindowComponent

	public string Name => _component.Name;

	public void Prepare(EditorWindow window)
	{
		_showExtraFields.valueChanged.AddListener(window.Repaint);
		_component.Prepare(window);
	}

	public void OnGUI()
	{
		using (new EditorVerticalGroup("GroupBox"))
		{
			using (var fadeGroup = new EditorFadeGroup(Name, _showExtraFields))
			{
				if (!fadeGroup.IsVisible)
				{
					return;
				}

				EditorGUI.indentLevel++;
				_component.OnGUI();
				EditorGUI.indentLevel--;
			}
		}
	}

	#endregion

	#region AssistantWindowComponentGroupBox

	public AssistantComponentGroupBox(IAssistantComponent component)
	{
		_component = component;
	}

	public void Show()
	{
		_showExtraFields.target = true;
	}

	public void Hide()
	{
		_showExtraFields.target = false;
	}

	#endregion
}

}