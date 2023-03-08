namespace EM.Assistant
{

using System.Collections.Generic;
using System.Linq;
using Foundation;

public class CheatBinder : Binder,
	ICheatBinder
{
	#region ICheatBinder

	public IEnumerable<string> GetNames()
	{
		var names = Bindings.Keys.Select(key => (string) key.Item1);

		return names;
	}

	public IEnumerable<ICheatItem> GetItemsByName(string name)
	{
		var binding = GetBinding(name);
		var values = binding?.Values.Select(value => (ICheatItem) value);

		return values;
	}

	public IEnumerable<string> GetGroupsByName(string name)
	{
		var binding = GetBinding(name) as CheatBinding;

		return binding?.Groups;
	}

	public string GetInfoByName(string name)
	{
		var binding = GetBinding(name) as CheatBinding;

		return binding?.Info;
	}

	public ICheatBindingLifeTime Bind(string name)
	{
		return base.Bind(name) as ICheatBindingLifeTime;
	}

	public void Unbind(string name)
	{
		base.Unbind(name);
	}

	public void Unbind(LifeTime lifeTime)
	{
		Unbind(binding =>
		{
			var diBinding = (CheatBinding) binding;
			var result = diBinding.LifeTime == lifeTime;

			return result;
		});
	}

	#endregion

	#region Binder

	protected override IBinding GetRawBinding(object key,
		object name)
	{
		return new CheatBinding(key, name, BindingResolver);
	}

	#endregion
}

}