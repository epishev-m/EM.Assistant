using System;
using UnityEngine;
using UnityEngine.UIElements;

namespace EM.Assistant.Editor
{

public static class VisualElementExtensions
{
	public static Foldout SetText(this Foldout textElement,
		string text)
	{
		textElement.text = text;

		return textElement;
	}

	public static T SetText<T>(this T textElement,
		string text)
		where T : TextElement
	{
		textElement.text = text;

		return textElement;
	}

	public static T SetStyleBorderWidth<T>(this T visualElement,
		float value)
		where T : VisualElement
	{
		visualElement.style.borderBottomWidth = new StyleFloat(value);
		visualElement.style.borderTopWidth = new StyleFloat(value);
		visualElement.style.borderLeftWidth = new StyleFloat(value);
		visualElement.style.borderRightWidth = new StyleFloat(value);

		return visualElement;
	}
	
	public static T SetStyleBorderColor<T>(this T visualElement,
		Color value)
		where T : VisualElement
	{
		visualElement.style.borderBottomColor = new StyleColor(value);
		visualElement.style.borderTopColor = new StyleColor(value);
		visualElement.style.borderLeftColor = new StyleColor(value);
		visualElement.style.borderRightColor = new StyleColor(value);

		return visualElement;
	}

	public static T AddValueChangedCallback<T, TValue>(this T control,
		Action<TValue> callback)
		where T : INotifyValueChanged<TValue>
	{
		control.RegisterValueChangedCallback(evt =>
		{
			callback?.Invoke(evt.newValue);
		});

		return control;
	}

	public static T SetValue<T, TValue>(this T control,
		TValue value)
		where T : BaseField<TValue>
	{
		control.value = value;

		return control;
	}

	public static T AddChild<T>(this T visualElement,
		VisualElement element)
		where T : VisualElement
	{
		visualElement.Add(element);

		return visualElement;
	}

	public static T RemoveChild<T>(this T visualElement,
		VisualElement element)
		where T : VisualElement
	{
		if (element.parent != null)
		{
			visualElement.Remove(element);
		}

		return visualElement;
	}

	public static T SetEnable<T>(this T visualElement,
		bool value)
		where T : VisualElement
	{
		visualElement.SetEnabled(value);

		return visualElement;
	}

	public static T SetStylePadding<T>(this T visualElement,
		float value)
		where T : VisualElement
	{
		visualElement.style.paddingBottom = new StyleLength(value);
		visualElement.style.paddingTop = new StyleLength(value);
		visualElement.style.paddingLeft = new StyleLength(value);
		visualElement.style.paddingRight = new StyleLength(value);

		return visualElement;
	}

	public static T SetStylePadding<T>(this T visualElement,
		float bottom,
		float top,
		float left,
		float right)
		where T : VisualElement
	{
		visualElement.style.paddingBottom = new StyleLength(bottom);
		visualElement.style.paddingTop = new StyleLength(top);
		visualElement.style.paddingLeft = new StyleLength(left);
		visualElement.style.paddingRight = new StyleLength(right);

		return visualElement;
	}

	public static T SetStyleMargin<T>(this T visualElement,
		float value)
		where T : VisualElement
	{
		visualElement.style.marginBottom = new StyleLength(value);
		visualElement.style.marginTop = new StyleLength(value);
		visualElement.style.marginLeft = new StyleLength(value);
		visualElement.style.marginRight = new StyleLength(value);

		return visualElement;
	}

	public static T SetStyleMargin<T>(this T visualElement,
		float bottom,
		float top,
		float left,
		float right)
		where T : VisualElement
	{
		visualElement.style.marginBottom = new StyleLength(bottom);
		visualElement.style.marginTop = new StyleLength(top);
		visualElement.style.marginLeft = new StyleLength(left);
		visualElement.style.marginRight = new StyleLength(right);

		return visualElement;
	}

	public static T SetStyleJustifyContent<T>(this T visualElement,
		Justify value)
		where T : VisualElement
	{
		visualElement.style.justifyContent = new StyleEnum<Justify>(value);

		return visualElement;
	}

	public static T SetStyleMinHeight<T>(this T visualElement,
		float value)
		where T : VisualElement
	{
		visualElement.style.minHeight = new StyleLength(value);

		return visualElement;
	}

	public static T SetStyleMinWidth<T>(this T visualElement,
		float value)
		where T : VisualElement
	{
		visualElement.style.minWidth = new StyleLength(value);

		return visualElement;
	}

	public static T SetStyleFlexDirection<T>(this T visualElement,
		FlexDirection value)
		where T : VisualElement
	{
		visualElement.style.flexDirection = new StyleEnum<FlexDirection>(value);

		return visualElement;
	}

	public static T SetStyleFlexGrow<T>(this T visualElement,
		float value)
		where T : VisualElement
	{
		visualElement.style.flexGrow = new StyleFloat(value);

		return visualElement;
	}

	public static T SetStyleFlexBasisPercent<T>(this T visualElement,
		float value)
		where T : VisualElement
	{
		visualElement.style.flexBasis = new StyleLength(Length.Percent(value));

		return visualElement;
	}
}

}