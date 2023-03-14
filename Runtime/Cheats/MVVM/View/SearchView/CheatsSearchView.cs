namespace EM.Assistant
{

public sealed class CheatsSearchView : SearchView
{
	public override void Initialize(ICheatsViewModel viewModel)
	{
		_inputField.onValueChanged.AddListener(viewModel.SetFilterVisibleCheats);
	}
}

}