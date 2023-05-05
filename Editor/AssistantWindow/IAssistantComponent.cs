namespace EM.Assistant.Editor
{

using UnityEditor;

public interface IAssistantComponent
{
	string Name { get; }

	void Prepare(EditorWindow window);

	void OnGUI();
}

}