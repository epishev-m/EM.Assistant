namespace EM.Assistant.Editor.Legacy
{

using System;
using System.IO;
using System.Text;
using Newtonsoft.Json;
using UnityEditor;
using UnityEngine;

public abstract class ProjectSettingsAssistantComponent<T> : IAssistantComponent
	where T : class, new()
{
	protected T Settings;

	#region IAssistantComponent

	public abstract string Name { get; }

	public void Prepare(EditorWindow _)
	{
		Load();
	}

	public void OnGUI()
	{
		OnGuiTopPanel();

		if (Settings != null)
		{
			OnGUIConfig();
		}
	}

	#endregion

	#region ProjectSettingsAssistantComponent

	protected abstract string DirectoryPath { get; }

	protected abstract void OnGUIConfig();

	private void OnGuiTopPanel()
	{
		using (new EditorVerticalGroup(17, "GroupBox"))
		{
			OnGuiCreateButton();
			OnGUIButtons();
		}
	}

	private void OnGuiCreateButton()
	{
		if (Settings == null)
		{
			EditorGUILayout.HelpBox("File not found. Create new settings.", MessageType.Warning);
		}
		else
		{
			OnGuiOutputPath();
		}
	}

	private void OnGuiOutputPath()
	{
		using (new EditorHorizontalGroup())
		{
			var filePath = DirectoryPath + Name + ".json";
			GUI.enabled = false;
			EditorGUILayout.TextField(filePath);
			GUI.enabled = true;

			if (GUILayout.Button("Show in Explorer", GUILayout.Width(120)))
			{
				var fullPath = Path.GetFullPath(filePath);
				ShowInExplorer(fullPath);
			}
		}
	}

	private void OnGUIButtons()
	{
		if (Settings != null)
		{
			return;
		}

		EditorGUILayout.Space();

		using (new EditorHorizontalGroup(17))
		{
			if (GUILayout.Button("Create"))
			{
				Settings = Activator.CreateInstance<T>();
				Save();
			}
		}
	}

	protected void Save()
	{
		if (Settings == null)
		{
			return;
		}

		try
		{
			JsonSerializerSettings jsonSettings = new()
			{
				Formatting = Formatting.Indented
			};

			var json = JsonConvert.SerializeObject(Settings, jsonSettings);
			var filePath = DirectoryPath + Name + ".json";
			using var outputFile = new StreamWriter(filePath, false, Encoding.UTF8);
			outputFile.Write(json);
		}
		catch (IOException e)
		{
			Debug.LogError("File write error: " + e.Message);
		}
	}

	private void Load()
	{
		var filePath = DirectoryPath + Name + ".json";

		if (!File.Exists(filePath))
		{
			return;
		}

		JsonSerializerSettings jsonSettings = new()
		{
			ObjectCreationHandling = ObjectCreationHandling.Replace,
		};

		try
		{
			using var streamReader = new StreamReader(filePath);
			var json = streamReader.ReadToEnd();
			Settings = JsonConvert.DeserializeObject<T>(json, jsonSettings);
		}
		catch (IOException e)
		{
			Debug.LogError("File read error: " + e.Message);
		}
	}

	private static void ShowInExplorer(string path)
	{
		switch (Application.platform)
		{
			case RuntimePlatform.WindowsEditor:
				System.Diagnostics.Process.Start("explorer.exe", "/select," + path.Replace('/', '\\'));
				break;
			case RuntimePlatform.OSXEditor:
				System.Diagnostics.Process.Start("open", "-R " + path);
				break;
			default:
				throw new ArgumentOutOfRangeException();
		}
	}

	#endregion
}

}