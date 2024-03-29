namespace EM.Assistant.Editor
{

using UnityEditor;
using UnityEngine;

public static class EditorLayoutUtility
{
	public static void Line()
	{
		EditorGUILayout.LabelField("", GUI.skin.horizontalSlider);
	}

	public static void ToolbarSearch(ref string filter,
		float space = 0f)
	{
		using (new EditorHorizontalGroup(space))
		{
			filter = GUILayout.TextField(filter, GUI.skin.FindStyle("ToolbarSeachTextField"));

			if (GUILayout.Button(string.Empty, GUI.skin.FindStyle("ToolbarSeachCancelButton")))
			{
				filter = string.Empty;
				GUI.FocusControl(null);
			}
		}
	}
}

}