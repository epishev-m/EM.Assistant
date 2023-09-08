namespace EM.Assistant.Editor.Legacy
{

using UnityEditor;

public interface IAssistantComponent
{
	string Name { get; }

	void Prepare(EditorWindow window);

	void OnGUI();
}

}