namespace EM.Assistant
{

using GameKit;
using IoC;

public sealed class CheatsInstaller : IInstaller
{
	#region IInstaller

	public void InstallBindings(IDiContainer diContainer)
	{
		diContainer.Bind<ICheatBinder>()
			.InGlobal()
			.To<CheatBinder>()
			.ToSingleton();

		diContainer.Bind<CheatsModel>()
			.InGlobal()
			.To<CheatsModel>()
			.ToSingleton();

		diContainer.Bind<Cheats>()
			.InGlobal()
			.To<Cheats>()
			.ToSingleton();

		diContainer.Bind<CheatTest>()
			.InGlobal()
			.To<CheatTest>()
			.ToSingleton();

		diContainer.Bind<CheatsRouter>()
			.InGlobal()
			.To<CheatsRouter>()
			.ToSingleton();

		diContainer.Bind<CheatsViewModel>()
			.InLocal()
			.To<CheatsViewModel>();

		diContainer.Resolve<Cheats>()
			.Add<CheatTest>();
	}

	#endregion
}

}