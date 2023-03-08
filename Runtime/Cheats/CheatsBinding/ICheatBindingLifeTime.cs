namespace EM.Assistant
{

using Foundation;

public interface ICheatBindingLifeTime
{
	LifeTime LifeTime { get; }

	ICheatBindingGroup InGlobal();

	ICheatBindingGroup InLocal();
}

}