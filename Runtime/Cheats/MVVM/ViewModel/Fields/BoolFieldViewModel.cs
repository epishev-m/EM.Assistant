namespace EM.Assistant
{

using Foundation;

public sealed class BoolFieldViewModel : IFieldViewModel
{
	private readonly RxProperty<bool> _value = new();

	private readonly RxProperty<string> _label = new();

	private readonly BoolCheatFieldModel _model;

	#region IFieldViewModel

	void IFieldViewModel.Initialize()
	{
		_model.OnChanged += OnChangeModel;
	}

	void IFieldViewModel.Release()
	{
		_model.OnChanged -= OnChangeModel;
	}

	void IFieldViewModel.UpdateAllRxProperties()
	{
		OnChangeModel();
	}

	#endregion

	#region IntFieldViewModel

	public BoolFieldViewModel(BoolCheatFieldModel model)
	{
		_model = model;
	}

	public IRxProperty<bool> Value => _value;

	public IRxProperty<string> Label => _label;

	public void SetValue(bool value)
	{
		_value.SetValueWithoutNotify(value);
		_model.SetValueWithoutNotify(value);
	}

	private void OnChangeModel()
	{
		_label.Value = _model.Label;
		_value.Value = _model.Value;
	}

	#endregion
}

}