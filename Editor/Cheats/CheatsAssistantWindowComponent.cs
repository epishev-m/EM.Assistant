namespace EM.Assistant.Editor
{

using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using Foundation.Editor;

public sealed class CheatsAssistantWindowComponent : IAssistantWindowComponent
{
	private bool _info;

	#region IAssistantWindowComponent

	public string Name => "Cheats";

	public void Prepare()
	{
	}

	public void OnGUI()
	{
		if (!Application.isPlaying)
		{
			Cheats.Instance = null;
			EditorGUILayout.HelpBox("Cheats are only available in playmode!", MessageType.Info);

			return;
		}

		if (Cheats.Instance == null)
		{
			EditorGUILayout.HelpBox("cheats are not created!", MessageType.Info);

			return;
		}

		using (new EditorVerticalGroup())
		{
			_info = EditorGUILayout.ToggleLeft("Info", _info);

			EditorGUILayout.Space();
			EditorGUILayout.Space();

			var names = Cheats.Instance.GetNames();

			foreach (var name in names)
			{
				var info = Cheats.Instance.GetInfoByName(name);
				var items = Cheats.Instance.GetItemsByName(name);
				OnGuiCheat(name, info, items);
			}
		}
	}

	#endregion

	#region CheatsAssistantWindowComponent

	private void OnGuiCheat(string cheatName, string info, IEnumerable<ICheatItem> items)
	{
		using (new EditorVerticalGroup())
		{
			EditorGUILayout.LabelField(cheatName, EditorStyles.boldLabel);

			if (_info)
			{
				EditorGUILayout.HelpBox(info, MessageType.Info);
			}

			foreach (var item in items)
			{
				OnGuiItem(item);
			}
		}
	}

	private static void OnGuiItem(ICheatItem item)
	{
		switch (item)
		{
			case CheatIntField field:
				OnGuiIntField(field);
				break;
			case CheatFloatField field:
				OnGuiFloatField(field);
				break;
			case CheatLongField field:
				OnGuiLongField(field);
				break;
			case CheatDoubleField field:
				OnGuiDoubleField(field);
				break;
			case CheatVector2Field field:
				OnGuiVector2Field(field);
				break;
			case CheatVector3Field field:
				OnGuiVector3Field(field);
				break;
			case CheatVector4Field field:
				OnGuiVector4Field(field);
				break;
			case CheatSliderField field:
				OnGuiSliderField(field);
				break;
			case CheatIntSliderField field:
				OnGuiIntSliderField(field);
				break;
			case CheatMinMaxSliderField field:
				OnGuiMinMaxSliderField(field);
				break;
			case CheatRectField field:
				OnGuiRectField(field);
				break;
			case CheatTextField field:
				OnGuiTextField(field);
				break;
			case CheatButton button:
				OnGuiButton(button);
				break;
			default:
				throw new InvalidOperationException();
		}
	}

	private static void OnGuiIntField(CheatIntField field)
	{
		field.Value = EditorGUILayout.IntField(field.Label, field.Value);
	}

	private static void OnGuiFloatField(CheatFloatField field)
	{
		field.Value = EditorGUILayout.FloatField(field.Label, field.Value);
	}

	private static void OnGuiLongField(CheatLongField field)
	{
		field.Value = EditorGUILayout.LongField(field.Label, field.Value);
	}

	private static void OnGuiDoubleField(CheatDoubleField field)
	{
		field.Value = EditorGUILayout.DoubleField(field.Label, field.Value);
	}

	private static void OnGuiVector2Field(CheatVector2Field field)
	{
		field.Value = EditorGUILayout.Vector2Field(field.Label, field.Value);
	}

	private static void OnGuiVector3Field(CheatVector3Field field)
	{
		field.Value = EditorGUILayout.Vector3Field(field.Label, field.Value);
	}

	private static void OnGuiVector4Field(CheatVector4Field field)
	{
		field.Value = EditorGUILayout.Vector4Field(field.Label, field.Value);
	}

	private static void OnGuiSliderField(CheatSliderField field)
	{
		field.Value = EditorGUILayout.Slider(field.Label, field.Value, field.LeftValue, field.RightValue);
	}

	private static void OnGuiIntSliderField(CheatIntSliderField field)
	{
		field.Value = EditorGUILayout.IntSlider(field.Label, field.Value, field.LeftValue, field.RightValue);
	}

	private static void OnGuiMinMaxSliderField(CheatMinMaxSliderField field)
	{
		using (new EditorVerticalGroup())
		{
			EditorGUILayout.MinMaxSlider(field.Label, ref field.MinValue, ref field.MaxValue, field.MinLimit, field.MaxLimit);

			using (new EditorHorizontalGroup())
			{
				field.MinValue = EditorGUILayout.FloatField("Min Value:", field.MinValue);
				field.MaxValue = EditorGUILayout.FloatField("Max Value:", field.MaxValue);
			}
		}
	}

	private static void OnGuiRectField(CheatRectField field)
	{
		field.Value = EditorGUILayout.RectField(field.Label, field.Value);
	}

	private static void OnGuiTextField(CheatTextField field)
	{
		field.Value = EditorGUILayout.TextField(field.Label, field.Value);
	}

	private static void OnGuiButton(CheatButton button)
	{
		using (new EditorHorizontalGroup())
		{
			GUILayout.Space(17);

			if (GUILayout.Button(button.Label))
			{
				button.Action?.Invoke();
			}
		}
	}

	#endregion
}

}