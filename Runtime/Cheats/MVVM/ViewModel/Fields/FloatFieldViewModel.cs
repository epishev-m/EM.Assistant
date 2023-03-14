namespace EM.Assistant
{

using Foundation;

public sealed class FloatFieldViewModel : IFieldViewModel
{
	private readonly RxProperty<float> _value = new();

	private readonly RxProperty<string> _label = new();

	private readonly FloatCheatFieldModel _model;

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

	#region FloatFieldViewModel

	public FloatFieldViewModel(FloatCheatFieldModel model)
	{
		_model = model;
	}

	public IRxProperty<float> Value => _value;

	public IRxProperty<string> Label => _label;

	public void SetValue(float value)
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