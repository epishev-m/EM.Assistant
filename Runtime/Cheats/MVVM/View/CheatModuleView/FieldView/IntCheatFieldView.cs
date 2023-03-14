namespace EM.Assistant
{

using TMPro;
using UnityEngine;

public sealed class IntCheatFieldView : CheatFieldView<IntFieldViewModel>
{
	[SerializeField]
	private TextMeshProUGUI _label;

	[SerializeField]
	private TMP_InputField _inputField;

	#region CheatFieldView

	protected override void OnInitialize()
	{
		Subscribe(ViewModel.Value, UpdateValue);
		Subscribe(ViewModel.Label, UpdateLabel);
		Subscribe(_inputField.onValueChanged, SetValue);
	}

	#endregion

	#region IntCheatFieldView

	private void UpdateValue(int value)
	{
		_inputField.SetTextWithoutNotify(value.ToString());
	}

	private void UpdateLabel(string value)
	{
		_label.text = value;
	}

	private void SetValue(string value)
	{
		if (int.TryParse(value, out var intValue))
		{
			ViewModel.SetValue(intValue);
		}
	}

	#endregion
}

}