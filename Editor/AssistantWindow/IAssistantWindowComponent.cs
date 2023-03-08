namespace EM.Assistant.Editor
{

public interface IAssistantWindowComponent
{
	string Name
	{
		get;
	}

	void Prepare();

	void OnGUI();
}

}