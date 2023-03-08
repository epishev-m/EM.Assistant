namespace EM.Assistant
{

public interface ICheatBindingInfo
{
	string Info { get; }

	ICheatBinding SetInfo(string info);
}

}