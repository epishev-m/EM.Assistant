namespace EM.Assistant
{

using System;
using System.Collections.Generic;
using Foundation;
using IoC;

public sealed class Cheats : IDisposable
{
#if UNITY_EDITOR
	public static Cheats Instance { get; set; }
#endif

	private readonly IDiContainer _diContainer;

	private readonly ICheatBinder _cheatBinder;

	#region IDisposable

	public void Dispose()
	{
		Instance = null;
	}

	#endregion
	
	#region Cheats

	public Cheats(IDiContainer diContainer,
		ICheatBinder cheatBinder)
	{
		_diContainer = diContainer;
		_cheatBinder = cheatBinder;

#if UNITY_EDITOR
		Requires.Null(Instance, nameof(Instance));

		Instance = this;
#endif
	}

	public Cheats Add<T>()
		where T : class, ICheat
	{
		var cheat = _diContainer.Resolve<T>();
		cheat.Registration(_cheatBinder);

		return this;
	}

	public IEnumerable<string> GetNames()
	{
		return _cheatBinder.GetNames();
	}

	public IEnumerable<string> GetGroupsByName(string name)
	{
		return _cheatBinder.GetGroupsByName(name);
	}

	public IEnumerable<ICheatItem> GetItemsByName(string name)
	{
		return _cheatBinder.GetItemsByName(name);
	}

	public string GetInfoByName(string name)
	{
		return _cheatBinder.GetInfoByName(name);
	}

	#endregion
}

}