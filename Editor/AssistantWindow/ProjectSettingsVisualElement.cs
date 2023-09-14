using System;
using System.IO;
using System.Text;
using UnityEngine;
using UnityEngine.UIElements;
using YamlDotNet.Serialization;

namespace EM.Assistant.Editor
{

public abstract class ProjectSettingsVisualElement<T> : VisualElement
	where T : class
{
	private T _settings;

	private HelpBox _helpBox;

	private Button _buttonCreate;

	private VisualElement _filePath;

	public event Action OnCreated;

	#region ProjectSettingsVisualElement

	protected ProjectSettingsVisualElement()
	{
		Load();
		Initialize();
		Compose();
	}

	public T Settings => _settings;

	protected abstract string FilePath { get; }

	public void Save()
	{
		if (_settings == null)
		{
			return;
		}

		try
		{
			var yaml = new SerializerBuilder().Build().Serialize(_settings);
			using var outputFile = new StreamWriter(FilePath, false, Encoding.UTF8);
			outputFile.Write(yaml);
		}
		catch (IOException e)
		{
			Debug.LogError("File write error: " + e.Message);
		}
	}

	public void Load()
	{
		if (!File.Exists(FilePath))
		{
			return;
		}

		try
		{
			using var streamReader = new StreamReader(FilePath);
			var yaml = streamReader.ReadToEnd();
			_settings = new DeserializerBuilder()
				.Build()
				.Deserialize<T>(yaml);
		}
		catch (IOException e)
		{
			Debug.LogError("File read error: " + e.Message);
		}
	}
	
	private void Initialize()
	{
		CreateHelpBox();
		CreateCreateButton();
		CreateFilePath();
	}

	private void Compose()
	{
		if (_settings == null)
		{
			this.AddChild(_helpBox)
				.AddChild(_buttonCreate);
		}
		else
		{
			this.AddChild(_filePath);
		}
	}

	private void ReCompose()
	{
		this.RemoveChild(_helpBox)
			.RemoveChild(_buttonCreate)
			.AddChild(_filePath);
	}

	private void CreateHelpBox()
	{
		_helpBox = new HelpBox("File not found. Create new settings.", HelpBoxMessageType.Info)
			.SetStyleMargin(10);
	}

	private void CreateCreateButton()
	{
		_buttonCreate = new Button(OnButtonCreateClicked)
			.SetText("Create");
	}

	private void CreateFilePath()
	{
		var settingsPath = new TextField()
			.SetStyleFlexBasisPercent(75)
			.SetEnable(false);

		settingsPath.value = FilePath;

		var showInExplorerButton = new Button(OnShowInExplorerButtonClicked)
			.SetStyleFlexBasisPercent(25)
			.SetStyleMargin(0, 0, 10, 0)
			.SetText("Show in Explorer");

		_filePath = new VisualElement()
			.SetStyleFlexDirection(FlexDirection.Row)
			.SetStyleJustifyContent(Justify.SpaceAround)
			.AddChild(settingsPath)
			.AddChild(showInExplorerButton);
	}

	private void OnButtonCreateClicked()
	{
		_settings = Activator.CreateInstance<T>();
		Save();
		ReCompose();
		OnCreated?.Invoke();
	}

	private void OnShowInExplorerButtonClicked()
	{
		switch (Application.platform)
		{
			case RuntimePlatform.WindowsEditor:
				System.Diagnostics.Process.Start("explorer.exe", "/select," + FilePath.Replace('/', '\\'));
				break;
			case RuntimePlatform.OSXEditor:
				System.Diagnostics.Process.Start("open", "-R " + FilePath);
				break;
			default:
				throw new ArgumentOutOfRangeException();
		}
	}

	#endregion
}

}