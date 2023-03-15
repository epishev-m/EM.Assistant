namespace EM.Assistant
{

using Foundation;
using UnityEngine;

public sealed class CheatFieldViewFactory
{
	private readonly CheatFieldViewPrefabs _prefabs;

	#region CheatFieldViewFactory

	public CheatFieldViewFactory(CheatFieldViewPrefabs prefabs)
	{
		_prefabs = prefabs;
	}

	public Result<ICheatFieldView> Create(IFieldViewModel viewModel,
		Transform parent)
	{
		Requires.NotNullParam(viewModel, nameof(viewModel));
		Requires.NotNullParam(parent, nameof(parent));

		ICheatFieldView cheatFieldView = viewModel switch
		{
			InfoFieldViewModel => Object.Instantiate(_prefabs.InfoCheatFieldViewPrefab, parent, true),
			BoolFieldViewModel => Object.Instantiate(_prefabs.BoolCheatFieldViewPrefab, parent, true),
			IntFieldViewModel => Object.Instantiate(_prefabs.IntCheatFieldView, parent, true),
			LongFieldViewModel => Object.Instantiate(_prefabs.LongCheatFieldView, parent, true),
			FloatFieldViewModel => Object.Instantiate(_prefabs.FloatCheatFieldView, parent, true),
			DoubleFieldViewModel => Object.Instantiate(_prefabs.DoubleCheatFieldView, parent, true),
			TextFieldViewModel => Object.Instantiate(_prefabs.TextCheatFieldView, parent, true),
			Vector2FieldViewModel => Object.Instantiate(_prefabs.Vector2CheatFieldView, parent, true),
			Vector3FieldViewModel => Object.Instantiate(_prefabs.Vector3CheatFieldView, parent, true),
			Vector4FieldViewModel => Object.Instantiate(_prefabs.Vector4CheatFieldView, parent, true),
			RectFieldViewModel => Object.Instantiate(_prefabs.RectCheatFieldView, parent, true),
			SliderFieldViewModel => Object.Instantiate(_prefabs.SliderCheatFieldView, parent, true),
			IntSliderFieldViewModel => Object.Instantiate(_prefabs.IntSliderCheatFieldView, parent, true),
			MinMaxSliderFieldViewModel => Object.Instantiate(_prefabs.MinMaxSliderCheatFieldView, parent, true),
			IntMinMaxSliderFieldViewModel => Object.Instantiate(_prefabs.IntMinMaxSliderCheatFieldView, parent, true),
			ButtonFieldViewModel => Object.Instantiate(_prefabs.ButtonCheatFieldView, parent, true),
			Button2FieldViewModel => Object.Instantiate(_prefabs.Button2CheatFieldView, parent, true),
			Button3FieldViewModel => Object.Instantiate(_prefabs.Button3CheatFieldView, parent, true),
			_ => null
		};

		if (cheatFieldView == null)
		{
			return new ErrorResult<ICheatFieldView>($"Type {viewModel.GetType()} not supported");
		}

		return new SuccessResult<ICheatFieldView>(cheatFieldView);
	}

	#endregion
}

}