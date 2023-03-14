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
			Cheats.CheatsModel = null;
			EditorGUILayout.HelpBox("Cheats are only available in playmode!", MessageType.Info);

			return;
		}

		if (Cheats.CheatsModel == null)
		{
			EditorGUILayout.HelpBox("cheats are not created!", MessageType.Info);

			return;
		}

		using (new EditorVerticalGroup())
		{
			_info = EditorGUILayout.ToggleLeft("Info", _info);

			EditorGUILayout.Space();
			EditorGUILayout.Space();

			var names = Cheats.CheatsModel.GetNames();

			foreach (var name in names)
			{
				var items = Cheats.CheatsModel.GetFieldsByName(name);
				OnGuiCheat(name, items);
			}
		}
	}

	#endregion

	#region CheatsAssistantWindowComponent

	private void OnGuiCheat(string cheatName, IEnumerable<ICheatFieldModel> items)
	{
		using (new EditorVerticalGroup())
		{
			EditorGUILayout.LabelField(cheatName, EditorStyles.boldLabel);

			foreach (var item in items)
			{
				OnGuiItem(item);
			}
		}
	}

	private void OnGuiItem(ICheatFieldModel fieldModel)
	{
		switch (fieldModel)
		{
			case InfoCheatFieldModel field:
				OnGuiInfoField(field);
				break;
			case IntCheatFieldModel field:
				OnGuiIntField(field);
				break;
			case FloatCheatFieldModel field:
				OnGuiFloatField(field);
				break;
			case LongCheatFieldModel field:
				OnGuiLongField(field);
				break;
			case DoubleCheatFieldModel field:
				OnGuiDoubleField(field);
				break;
			case Vector2CheatFieldModel field:
				OnGuiVector2Field(field);
				break;
			case Vector3CheatFieldModel field:
				OnGuiVector3Field(field);
				break;
			case Vector4CheatFieldModel field:
				OnGuiVector4Field(field);
				break;
			case SliderCheatFieldModel field:
				OnGuiSliderField(field);
				break;
			case IntSliderCheatFieldModel field:
				OnGuiIntSliderField(field);
				break;
			case MinMaxSliderCheatFieldModel field:
				OnGuiMinMaxSliderField(field);
				break;
			case IntMinMaxSliderCheatFieldModel field:
				OnGuiIntMinMaxSliderField(field);
				break;
			case RectCheatFieldModel field:
				OnGuiRectField(field);
				break;
			case TextCheatFieldModel field:
				OnGuiTextField(field);
				break;
			case ButtonCheatFieldModel button:
				OnGuiButton(button);
				break;
			case Button2CheatFieldModel button:
				OnGuiButton2(button);
				break;
			case Button3CheatFieldModel button:
				OnGuiButton3(button);
				break;
			default:
				throw new InvalidOperationException();
		}
	}

	private void OnGuiInfoField(InfoCheatFieldModel fieldModel)
	{
		if (_info)
		{
			EditorGUILayout.HelpBox(fieldModel.Info, MessageType.Info);
		}
	}

	private static void OnGuiIntField(IntCheatFieldModel fieldModel)
	{
		fieldModel.Value = EditorGUILayout.IntField(fieldModel.Label, fieldModel.Value);
	}

	private static void OnGuiFloatField(FloatCheatFieldModel field)
	{
		field.Value = EditorGUILayout.FloatField(field.Label, field.Value);
	}

	private static void OnGuiLongField(LongCheatFieldModel fieldModel)
	{
		fieldModel.Value = EditorGUILayout.LongField(fieldModel.Label, fieldModel.Value);
	}

	private static void OnGuiDoubleField(DoubleCheatFieldModel fieldModel)
	{
		fieldModel.Value = EditorGUILayout.DoubleField(fieldModel.Label, fieldModel.Value);
	}

	private static void OnGuiVector2Field(Vector2CheatFieldModel fieldModel)
	{
		fieldModel.Value = EditorGUILayout.Vector2Field(fieldModel.Label, fieldModel.Value);
	}

	private static void OnGuiVector3Field(Vector3CheatFieldModel field)
	{
		field.Value = EditorGUILayout.Vector3Field(field.Label, field.Value);
	}

	private static void OnGuiVector4Field(Vector4CheatFieldModel field)
	{
		field.Value = EditorGUILayout.Vector4Field(field.Label, field.Value);
	}

	private static void OnGuiSliderField(SliderCheatFieldModel fieldModel)
	{
		fieldModel.Value = EditorGUILayout.Slider(fieldModel.Label, fieldModel.Value, fieldModel.MinValue, fieldModel.MaxValue);
	}

	private static void OnGuiIntSliderField(IntSliderCheatFieldModel fieldModel)
	{
		fieldModel.Value = EditorGUILayout.IntSlider(fieldModel.Label, fieldModel.Value, fieldModel.MinLimit, fieldModel.MaxLimit);
	}

	private static void OnGuiMinMaxSliderField(MinMaxSliderCheatFieldModel fieldModel)
	{
		using (new EditorVerticalGroup())
		{
			var minValue = fieldModel.MinValue;
			var maxValue = fieldModel.MaxValue;
			EditorGUILayout.MinMaxSlider(fieldModel.Label, ref minValue, ref maxValue, fieldModel.MinLimit, fieldModel.MaxLimit);
			fieldModel.MinValue = minValue;
			fieldModel.MaxValue = maxValue;

			using (new EditorHorizontalGroup())
			{
				fieldModel.MinValue = EditorGUILayout.FloatField("Min Value:", fieldModel.MinValue);
				fieldModel.MaxValue = EditorGUILayout.FloatField("Max Value:", fieldModel.MaxValue);
			}
		}
	}

	private static void OnGuiIntMinMaxSliderField(IntMinMaxSliderCheatFieldModel model)
	{
		using (new EditorVerticalGroup())
		{
			var minValue = (float) model.MinValue;
			var maxValue = (float) model.MaxValue;
			EditorGUILayout.MinMaxSlider(model.Label, ref minValue, ref maxValue, model.MinLimit, model.MaxLimit);

			if (maxValue - minValue < model.MinDistance)
			{
				if (minValue + model.MinDistance <= model.MaxLimit)
				{
					maxValue = minValue + model.MinDistance;
				}
				else
				{
					minValue = maxValue - model.MinDistance;
				}
			}

			model.MinValue = (int) minValue;
			model.MaxValue = (int) maxValue;

			using (new EditorHorizontalGroup())
			{
				model.MinValue = EditorGUILayout.IntField("Min Value:", model.MinValue);
				model.MaxValue = EditorGUILayout.IntField("Max Value:", model.MaxValue);
			}
		}
	}

	private static void OnGuiRectField(RectCheatFieldModel field)
	{
		field.Value = EditorGUILayout.RectField(field.Label, field.Value);
	}

	private static void OnGuiTextField(TextCheatFieldModel field)
	{
		field.Value = EditorGUILayout.TextField(field.Label, field.Value);
	}

	private static void OnGuiButton(ButtonCheatFieldModel fieldModel)
	{
		using (new EditorHorizontalGroup())
		{
			GUILayout.Space(17);

			if (GUILayout.Button(fieldModel.Label))
			{
				fieldModel.Action?.Invoke();
			}
		}
	}

	private static void OnGuiButton2(Button2CheatFieldModel fieldModel)
	{
		using (new EditorHorizontalGroup())
		{
			GUILayout.Space(17);

			if (GUILayout.Button(fieldModel.Label1))
			{
				fieldModel.Action1?.Invoke();
			}

			if (GUILayout.Button(fieldModel.Label2))
			{
				fieldModel.Action2?.Invoke();
			}
		}
	}

	private static void OnGuiButton3(Button3CheatFieldModel fieldModel)
	{
		using (new EditorHorizontalGroup())
		{
			GUILayout.Space(17);

			if (GUILayout.Button(fieldModel.Label1))
			{
				fieldModel.Action1?.Invoke();
			}

			if (GUILayout.Button(fieldModel.Label2))
			{
				fieldModel.Action2?.Invoke();
			}

			if (GUILayout.Button(fieldModel.Label3))
			{
				fieldModel.Action3?.Invoke();
			}
		}
	}

	#endregion
}

}