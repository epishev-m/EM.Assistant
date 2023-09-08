using UnityEditor;
using UnityEditor.AddressableAssets;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.UIElements;

namespace EM.Assistant.Editor
{

public abstract class ScriptableObjectAssistantComponent<T> : AssistantComponent
	where T : ScriptableObject
{
	protected string ConfigPath;

	protected T Config;

	private VisualElement _buttonsPanel;

	private ObjectField _objectField;

	#region AssistantComponent

	protected override void OnInitialized()
	{
		base.OnInitialized();
		CreateButtons();
		LoadSettings();
		EditorApplication.update += UpdatePath;
	}

	protected override void OnComposed()
	{
		base.OnComposed();
		Root.AddChild(_buttonsPanel);
	}

	#endregion

	#region ScriptableObjectAssistantComponent

	private string ConfigPathKey => $"AssistantWindow.{Name}.{nameof(ConfigPath)}";

	protected abstract string GetCreatePath();

	protected abstract string GetSelectPath();

	protected virtual void SetConfig(T config)
	{
		Config = config;
		_objectField.value = Config;
	}

	private void CreateButtons()
	{
		_objectField = new ObjectField()
			.SetStyleFlexBasisPercent(72)
			.SetEnable(false);

		var buttonSelect = new Button(OnSelectButtonClicked)
			.SetStyleFlexBasisPercent(14)
			.SetText("Select");

		var buttonCreate = new Button(OnCreateButtonClicked)
			.SetStyleFlexBasisPercent(14)
			.SetText("Create");

		_buttonsPanel = new VisualElement()
			.SetStyleFlexDirection(FlexDirection.Row)
			.SetStyleJustifyContent(Justify.SpaceAround)
			.SetStyleMargin(10, 0, 0, 0)
			.AddChild(buttonSelect)
			.AddChild(buttonCreate)
			.AddChild(_objectField);
	}

	private void OnSelectButtonClicked()
	{
		SelectConfig();
		SetAddressableFlag();
	}

	private void OnCreateButtonClicked()
	{
		CreateConfig();
		SetAddressableFlag();
	}

	private void SelectConfig()
	{
		var path = GetSelectPath();

		if (string.IsNullOrWhiteSpace(path))
		{
			return;
		}

		path = "Assets" + path.Remove(0, Application.dataPath.Length);
		var config = AssetDatabase.LoadAssetAtPath<T>(path);
		SetConfig(config);
	}

	private void CreateConfig()
	{
		var path = GetCreatePath();

		if (string.IsNullOrWhiteSpace(path))
		{
			return;
		}

		var config = ScriptableObject.CreateInstance<T>();
		AssetDatabase.CreateAsset(config, path);
		AssetDatabase.SaveAssets();
		EditorUtility.FocusProjectWindow();
		Selection.activeObject = config;
		SetConfig(config);
	}

	private void SetAddressableFlag()
	{
		var path = AssetDatabase.GetAssetPath(Config);
		var guiID = AssetDatabase.AssetPathToGUID(path);
		var settings = AddressableAssetSettingsDefaultObject.Settings;
		var assetEntry = settings.CreateOrMoveEntry(guiID, settings.DefaultGroup);
		assetEntry.address = Config.name;
	}

	private void LoadSettings()
	{
		ConfigPath = EditorPrefs.GetString(ConfigPathKey);

		if (string.IsNullOrWhiteSpace(ConfigPath))
		{
			return;
		}

		Config = AssetDatabase.LoadAssetAtPath(ConfigPath, typeof(T)) as T;
		_objectField.value = Config;
	}

	private void UpdatePath()
	{
		if (Config == null)
		{
			return;
		}

		var path = AssetDatabase.GetAssetPath(Config);

		if (path == ConfigPath)
		{
			return;
		}

		ConfigPath = path;
		EditorPrefs.SetString(ConfigPathKey, path);
	}

	#endregion
}

}