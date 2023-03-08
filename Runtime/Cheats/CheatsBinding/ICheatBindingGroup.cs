namespace EM.Assistant
{

using System.Collections.Generic;

public interface ICheatBindingGroup
{
	IEnumerable<string> Groups { get; }

	ICheatBindingInfo SetGroups(params string[] groups);
}

}