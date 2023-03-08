namespace EM.Assistant
{

using System;

public interface ICheatBinding
{
	ICheatBinding AddField<T>(T field)
		where T : class;

	ICheatBinding AddButton(string label, Action action);
}

}