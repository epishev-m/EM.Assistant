using UnityEngine;
using UnityEngine.UIElements;

namespace EM.Assistant.Editor
{

public abstract class AssistantComponent : VisualElement
{
	private Foldout _foldout;

	#region AssistantComponent

	protected AssistantComponent()
	{
		Initialize();
		Compose();
	}

	public abstract string Name { get; }

	protected VisualElement Root => _foldout;

	public void Show()
	{
		_foldout?.SetValueWithoutNotify(true);
	}

	public void Hide()
	{
		_foldout?.SetValueWithoutNotify(false);
	}

	protected virtual void OnInitialized()
	{
	}

	protected virtual void OnComposed()
	{
	}

	private void Initialize()
	{
		_foldout = new Foldout()
			.SetStylePadding(5)
			.SetStyleMargin(5, 5, 0, 0)
			.SetText(Name)
			.SetStyleBorderWidth(1)
			.SetStyleBorderColor(Color.gray);

		OnInitialized();
	}

	private void Compose()
	{
		Add(_foldout);
		OnComposed();
	}

	#endregion
}

}