namespace EM.Assistant.Editor
{

using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;

public abstract class AssistantWindowBase : EditorWindow
{
	private readonly List<AssistantComponentGroupBox> _components = new();

	private Vector2 _scrollPos;

	private string _filter = string.Empty;

	#region EditorWindow

	private void OnEnable()
	{
		CreateComponents();

		foreach (var component in _components)
		{
			component.Prepare(this);
		}
	}

	private void OnGUI()
	{
		OnGuiTopPanel();
		OnGuiComponents();
	}

	#endregion

	#region AssistantWindowBase

	protected abstract IEnumerable<IAssistantComponent> GetWindowComponents();

	private void CreateComponents()
	{
		_components.Clear();
		var components = GetWindowComponents();

		foreach (var component in components)
		{
			_components.Add(new AssistantComponentGroupBox(component));
		}
	}

	private void OnGuiTopPanel()
	{
		using (new EditorVerticalGroup("GroupBox"))
		{
			OnGuiButtons();
			EditorGUILayout.Space();
			OnGuiSearch();
		}
	}

	private void OnGuiButtons()
	{
		using (new EditorHorizontalGroup())
		{
			if (GUILayout.Button("Show All"))
			{
				_components.ForEach(c => c.Show());
			}

			if (GUILayout.Button("Hide All"))
			{
				_components.ForEach(c => c.Hide());
			}
		}
	}

	private void OnGuiSearch()
	{
		EditorLayoutUtility.ToolbarSearch(ref _filter);
	}

	private void OnGuiComponents()
	{
		using (new EditorScrollView(ref _scrollPos))
		{
			var filter = _filter.ToLower();

			foreach (var component in _components.Where(component => component.Name.ToLower().Contains(filter)))
			{
				component.OnGUI();
			}
		}
	}

	#endregion
}

}