using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine.UIElements;

namespace EM.Assistant.Editor
{

public abstract class AssistantWindow : EditorWindow
{
	private readonly List<AssistantComponent> _components = new();

	private VisualElement _buttonsPanel;

	private VisualElement _searchPanel;

	private ScrollView _scrollView;

	#region EditorWindow

	private void CreateGUI()
	{
		Initialize();
		Compose();
	}

	#endregion

	#region AssistantWindow

	protected abstract IEnumerable<AssistantComponent> GetWindowComponents();

	private void Initialize()
	{
		CreateButtons();
		CreateToolbarSearch();
		CreateComponents();
	}

	private void Compose()
	{
		rootVisualElement.Add(new VisualElement()
			.SetStylePadding(10)
			.AddChild(_buttonsPanel)
			.AddChild(_searchPanel)
			.AddChild(_scrollView)
		);
	}

	private void CreateButtons()
	{
		var buttonSelect = new Button(OnShowAllButtonClicked)
			.SetText("Show All")
			.SetStyleFlexBasisPercent(50);

		var buttonCreate = new Button(OnHideAllButtonClicked)
			.SetText("Hide All")
			.SetStyleFlexBasisPercent(50);

		_buttonsPanel = new VisualElement()
			.SetStyleFlexDirection(FlexDirection.Row)
			.SetStyleJustifyContent(Justify.SpaceAround)
			.SetStyleMinHeight(22)
			.AddChild(buttonSelect)
			.AddChild(buttonCreate);
	}

	private void CreateToolbarSearch()
	{
		var toolbarSearch = new ToolbarSearchField()
			.SetStyleFlexBasisPercent(100)
			.AddValueChangedCallback<ToolbarSearchField, string>(OnToolbarSearchValueChanged);

		_searchPanel = new VisualElement()
			.SetStyleFlexDirection(FlexDirection.Row)
			.SetStyleJustifyContent(Justify.SpaceAround)
			.SetStyleMinHeight(22)
			.AddChild(toolbarSearch);
	}

	private void CreateComponents()
	{
		_scrollView = new ScrollView()
			.SetStylePadding(5);

		_components.Clear();
		var components = GetWindowComponents();

		foreach (var component in components)
		{
			_scrollView.Add(component);
			_components.Add(component);
		}
	}

	private void OnShowAllButtonClicked()
	{
		_components.ForEach(c => c.Show());
	}

	private void OnHideAllButtonClicked()
	{
		_components.ForEach(c => c.Hide());
	}

	private void OnToolbarSearchValueChanged(string value)
	{
		var filter = value.ToLower();

		foreach (var component in _components)
		{
			if (component.parent != null)
			{
				_scrollView.Remove(component);
			}
		}

		foreach (var component in _components.Where(component => component.Name.ToLower().Contains(filter)))
		{
			_scrollView.Add(component);
		}
	}

	#endregion
}

}