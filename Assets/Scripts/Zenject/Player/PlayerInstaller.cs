using Player.PlayerStateMachine;
using Player.PlayerStateMachine.State;
using Zenject;

public class PlayerInstaller : Installer<PlayerInstaller>
{
    public override void InstallBindings()
    {
        Container.Bind<FlightState>().AsSingle();
        Container.Bind<RunState>().AsSingle();
        Container.Bind<IdleState>().AsSingle();
        Container.Bind<WinState>().AsSingle();
        
        Container.BindInterfacesAndSelfTo<PlayerStateMachine>().AsSingle().NonLazy();
    }
}