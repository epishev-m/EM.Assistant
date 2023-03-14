namespace EM.Assistant
{

using Foundation;

public sealed class InfoFieldViewModel : IFieldViewModel
{
	private readonly RxProperty<string> _info = new();

	private readonly InfoCheatFieldModel _model;

	#region IFieldViewModel

	void IFieldViewModel.Initialize()
	{
	}

	void IFieldViewModel.Release()
	{
	}

	void IFieldViewModel.UpdateAllRxProperties()
	{
		_info.Value = _model.Info;
	}

	#endregion

	#region InfoFieldViewModel

	public InfoFieldViewModel(InfoCheatFieldModel model)
	{
		_model = model;
	}

	public IRxProperty<string> Info => _info;

	#endregion
}

}