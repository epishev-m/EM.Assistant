namespace EM.Assistant
{

using System;
using System.Collections.Generic;
using Foundation;

public sealed class CheatBinding : Binding,
	ICheatBindingLifeTime,
	ICheatBindingGroup,
	ICheatBindingInfo,
	ICheatBinding
{
	#region ICheatBinding

	ICheatBinding ICheatBinding.AddField<T>(T field)
		where T : class
	{
		Requires.ValidOperation(LifeTime != LifeTime.External, this);
		Requires.NotNullParam(field, nameof(field));

		return To(field) as ICheatBinding;
	}

	ICheatBinding ICheatBinding.AddButton(string label,
		Action action)
	{
		Requires.ValidOperation(LifeTime != LifeTime.External, this);

		var buttonItem = new CheatButton(label, action);

		return To(buttonItem) as ICheatBinding;
	}

	#endregion

	#region ICheatBindingInfo

	public string Info { get; private set; }

	ICheatBinding ICheatBindingInfo.SetInfo(string info)
	{
		Requires.ValidOperation(Groups != null, this);
		Requires.ValidOperation(Info == null, this);

		Info = info;

		return this;
	}

	#endregion

	#region ICheatBindingGroup

	public IEnumerable<string> Groups { get; private set; }

	ICheatBindingInfo ICheatBindingGroup.SetGroups(params string[] groups)
	{
		Requires.ValidOperation(LifeTime != LifeTime.External, this);
		Requires.ValidOperation(Groups == null, this);
		Requires.NotNullParam(groups, nameof(groups));

		Groups = groups;

		return this;
	}

	#endregion

	#region ICheatBindingLifeTime

	public LifeTime LifeTime { get; private set; } = LifeTime.External;

	ICheatBindingGroup ICheatBindingLifeTime.InGlobal()
	{
		Requires.ValidOperation(LifeTime == LifeTime.External, this);

		LifeTime = LifeTime.Global;

		return this;
	}

	ICheatBindingGroup ICheatBindingLifeTime.InLocal()
	{
		Requires.ValidOperation(LifeTime == LifeTime.External, this);

		LifeTime = LifeTime.Local;

		return this;
	}

	#endregion

	#region Binding

	public CheatBinding(object key,
		object name,
		Resolver resolver) : base(key, name, resolver)
	{
	}

	#endregion
}

}