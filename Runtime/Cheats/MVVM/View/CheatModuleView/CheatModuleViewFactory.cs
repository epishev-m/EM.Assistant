namespace EM.Assistant
{

using Foundation;
using UnityEngine;

public sealed class CheatModuleViewFactory : IFactory<CheatModuleView>
{
	private readonly Transform _parent;

	private readonly CheatModuleView _cheatModuleViewPrefab;

	#region IFactory

	public Result<CheatModuleView> Create()
	{
		var cheatView = Object.Instantiate(_cheatModuleViewPrefab, _parent, true);

		return new SuccessResult<CheatModuleView>(cheatView);
	}

	#endregion

	#region CheatViewFactory

	public CheatModuleViewFactory(Transform parent,
		CheatModuleView cheatModuleViewPrefab)
	{
		_parent = parent;
		_cheatModuleViewPrefab = cheatModuleViewPrefab;
	}

	#endregion
}

}