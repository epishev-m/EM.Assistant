namespace EM.Assistant
{

public sealed class GroupsSearchView : SearchView
{
	public override void Initialize(ICheatsViewModel viewModel)
	{
		_inputField.onValueChanged.AddListener(viewModel.SetFilterVisibleGroups);
	}
}

}