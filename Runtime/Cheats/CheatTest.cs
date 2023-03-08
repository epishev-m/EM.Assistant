namespace EM.Assistant
{

using UnityEngine;

public sealed class CheatTest : ICheat
{
	private readonly CheatIntField _cheatIntField = new("Int");

	private readonly CheatLongField _cheatLongField = new("Long");

	private readonly CheatFloatField _cheatFloatField = new("Float");

	private readonly CheatDoubleField _cheatDoubleField = new("Double");

	private readonly CheatTextField _cheatTextField = new("Text");

	private readonly CheatVector2Field _cheatVector2Field = new("Vector2");

	private readonly CheatVector3Field _cheatVector3Field = new("Vector3");

	private readonly CheatVector4Field _cheatVector4Field = new("Vector4");

	private readonly CheatRectField _cheatRectField = new("Rect");

	private readonly CheatSliderField _cheatSliderField = new("Slider", 0f, 1f);

	private readonly CheatIntSliderField _cheatIntSliderField = new("IntSlider", 0, 10);

	private readonly CheatMinMaxSliderField _cheatMinMaxSliderField = new("min_max_slider", 1f, 2f);

	#region ICheat

	public void Registration(ICheatBinder cheatBinder)
	{
		cheatBinder.Bind("Cheat Int")
			.InGlobal()
			.SetGroups("base", "int")
			.SetInfo("Выводит значение Int в консоль!")
			.AddField(_cheatIntField)
			.AddButton("Log", () => Debug.Log(_cheatIntField.Value));

		cheatBinder.Bind("Cheat Long")
			.InGlobal()
			.SetGroups("base", "int")
			.SetInfo("Выводит значение Long в консоль!")
			.AddField(_cheatLongField)
			.AddButton("Log", () => Debug.Log(_cheatLongField.Value));

		cheatBinder.Bind("Cheat Float")
			.InGlobal()
			.SetGroups("base", "Singl")
			.SetInfo("Выводит значение Float в консоль!")
			.AddField(_cheatFloatField)
			.AddButton("Log", () => Debug.Log(_cheatFloatField.Value));

		cheatBinder.Bind("Cheat Double")
			.InGlobal()
			.SetGroups("base", "Singl")
			.SetInfo("Выводит значение Double в консоль!")
			.AddField(_cheatDoubleField)
			.AddButton("Log", () => Debug.Log(_cheatDoubleField.Value));

		cheatBinder.Bind("Cheat Text")
			.InGlobal()
			.SetGroups("base")
			.SetInfo("Выводит значение Text в консоль!")
			.AddField(_cheatTextField)
			.AddButton("Log", () => Debug.Log(_cheatTextField.Value));

		cheatBinder.Bind("Cheat Vector2")
			.InGlobal()
			.SetGroups("Combined", "Vector")
			.SetInfo("Выводит значение Vector2 в консоль!")
			.AddField(_cheatVector2Field)
			.AddButton("Log", () => Debug.Log(_cheatVector2Field.Value));

		cheatBinder.Bind("Cheat Vector3")
			.InGlobal()
			.SetGroups("Combined", "Vector")
			.SetInfo("Выводит значение Vector3 в консоль!")
			.AddField(_cheatVector3Field)
			.AddButton("Log", () => Debug.Log(_cheatVector3Field.Value));

		cheatBinder.Bind("Cheat Vector4")
			.InGlobal()
			.SetGroups("Combined", "Vector")
			.SetInfo("Выводит значение Vector4 в консоль!")
			.AddField(_cheatVector4Field)
			.AddButton("Log", () => Debug.Log(_cheatVector4Field.Value));

		cheatBinder.Bind("Cheat Rect")
			.InGlobal()
			.SetGroups("Combined")
			.SetInfo("Выводит значение Rect в консоль!")
			.AddField(_cheatRectField)
			.AddButton("Log", () => Debug.Log(_cheatRectField.Value));

		cheatBinder.Bind("Cheat Slider")
			.InGlobal()
			.SetGroups("Slider")
			.SetInfo("Выводит значение Slider в консоль!")
			.AddField(_cheatSliderField)
			.AddButton("Log", () => Debug.Log(_cheatSliderField.Value));

		cheatBinder.Bind("Cheat IntSlider")
			.InGlobal()
			.SetGroups("Slider")
			.SetInfo("Выводит значение IntSlider в консоль!")
			.AddField(_cheatIntSliderField)
			.AddButton("Log", () => Debug.Log(_cheatIntSliderField.Value));

		cheatBinder.Bind("Cheat MinMaxSlider")
			.InGlobal()
			.SetGroups("Combined", "Slider")
			.SetInfo("Выводит значение MinMaxSlider в консоль!")
			.AddField(_cheatMinMaxSliderField)
			.AddButton("Log Min", () => Debug.Log(_cheatMinMaxSliderField.MinValue))
			.AddButton("Log Max", () => Debug.Log(_cheatMinMaxSliderField.MaxValue));
	}

	#endregion
}

}